using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;
using Clinique2000_Utility.Enum;
using System.ComponentModel.DataAnnotations;

namespace Clinique2000_Services.Services
{
    public class ListeAttenteService : ServiceBaseAsync<ListeAttente>, IListeAttenteService
    {

        private readonly CliniqueDbContext _context;
        
        public ListeAttenteService (CliniqueDbContext context): base(context)
        {
            _context = context;
        }
        
        public async Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente)
        {
           if( listeAttente.DateEffectivite== null)
                listeAttente.DateEffectivite=DateTime.Now.Date;

            if (VerifierSiListeAttenteExisteMemeJourClinique(listeAttente.DateEffectivite, listeAttente.CliniqueID))
           

            await CreerAsync(listeAttente);
            return listeAttente;
        }

        public bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueId)
        {
            if(_context.ListeAttentes.Any(l => l.DateEffectivite == dateEffectivite && l.CliniqueID == cliniqueId))
            {
                throw new ValidationException("Il existe déjà une liste d'attente dans la meme clinique pour la meme  date.");
            }
            return true;
        }

        public bool ListeAttenteIsValid(ListeAttente listeAttente)
        {
            if (!VerifierSiDateEffectiviteValide(listeAttente) ||
                !VerifierSiHeureOuvertureValide(listeAttente) ||
                !VerifierSiListeAttenteEstCree(listeAttente) ||
                !VerifierSiNbMedecinsDisponibles(listeAttente))
            {
                return false;
            }

            
            return true;
        }


        public bool VerifierSiListeAttenteEstCree(ListeAttente listeAttente)
        {
            return _context.ListeAttentes.Any(l => l.DateEffectivite == listeAttente.DateEffectivite && l.CliniqueID == listeAttente.CliniqueID)
                        ? true
                        : throw new ValidationException("Il faut créer une liste d'attente avant");
        }

        public  bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente)
        {
            return listeAttente.NbMedecinsDispo >= 1
                    ? true
                    : throw new ValidationException("On doit avoir au moins un medecin disponible.");
        }

        public bool VerifierSiHeureOuvertureValide( ListeAttente listeAttente)
        {
                return listeAttente.HeureOuverture < listeAttente.HeureFermeture
                         ? true
                         : throw new ValidationException("L'heure d'ouverture doit etre inférieure à l'heure de fermeture.");

        }
        public bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente)
        {

            return listeAttente.DateEffectivite >= DateTime.Now.Date
                   ? true
                   : throw new ValidationException("La date d'effectivité n'est pas valide. Elle doit être postérieure à la date actuelle.");


        }

        public async Task GenererPlagesHorairesAsync(ListeAttente listeAttente )
        {
            if(!ListeAttenteIsValid(listeAttente))
            {
                throw new Exception("Liste d'attente invalide");
            }
            
            DateTime heureDebut = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureOuverture);
            DateTime finService = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureFermeture);
            PlageHoraire plageHoraire;
            Consultation consultation;
            while (heureDebut < finService)
            {
                DateTime nouvelleHeureFin = heureDebut.AddMinutes((double)listeAttente.Clinique.TempsMoyenConsultation);  
                plageHoraire = new PlageHoraire
                {
                    HeureDebut = heureDebut,
                    HeureFin = nouvelleHeureFin,
                    ListeAttente= listeAttente
                    
                   
                };

                for (int i = 0; i < listeAttente.NbMedecinsDispo; i++)
                {
                    consultation = new Consultation
                    {
                        HeureDateDebutPrevue = heureDebut,
                        HeureDateFinPrevue = nouvelleHeureFin,
                        StatutConsultation = StatutConsultation.EnAttente,
                        PlageHoraireID = plageHoraire.PlageHoraireID,
                        PatientID= null,
                        
                    };
                    _context.Consultations.Add(consultation);

                }
                _context.PlagesHoraires.Add(plageHoraire);


                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();
            
         
        }





    }   
}
