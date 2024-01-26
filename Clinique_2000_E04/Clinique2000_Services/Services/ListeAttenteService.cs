using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Clinique2000_Utility.Enum;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Clinique2000_Services.Services
{
    public class ListeAttenteService : ServiceBaseAsync<ListeAttente>, IListeAttenteService
    {

        private readonly CliniqueDbContext _context;

        public ListeAttenteService(CliniqueDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente)
        {


            if (VerifierSiListeAttenteExisteMemeJourClinique(listeAttente.DateEffectivite, listeAttente.CliniqueID))
            {
                throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.");
            }

            if (!VerifierSiDateEffectiviteValide(listeAttente) || !VerifierSiHeureOuvertureValide(listeAttente))
            {
                throw new ValidationException("La liste n'est pas valide");
            }
            else {
                await CreerAsync(listeAttente);
                return listeAttente;
            }
        }

        /// <summary>
        /// Cette methode s occupe de faire les verifications lors d'une creation de liste d'attente, puis faire la creation elle meme
        /// si une des verifications echoue, elle renvoie une erreur de validation 
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<ListeAttente> ModifierListeAttenteAsync(ListeAttente listeAttente)
        {
            if (VerifierSiListeAttenteExisteMemeJourClinique(listeAttente.DateEffectivite, listeAttente.CliniqueID, listeAttente.ListeAttenteID))
            {
                throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.");
            }

            if (!VerifierSiDateEffectiviteValide(listeAttente) || !VerifierSiHeureOuvertureValide(listeAttente))
            {
                throw new ValidationException("La liste n'est pas valide");
            }
            else
            {
                await EditerAsync(listeAttente);
                return listeAttente;
            }
        }

        /// <summary>
        /// Cette methode verifie que la liste dattente passee en parametre est pas ouverte
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        public bool PeutSupprimmer(ListeAttente listeAttente)
        {
            if (listeAttente.IsOuverte == false)
                return true;
            else
                return false;
  
        }


        /// <summary>
        /// Cette methode supprimme une liste d'attente de la base de donnees
        /// et sauvegarde les changements
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task SupprimmerListeAttente(ListeAttente listeAttente)
        {

             _context.ListeAttentes.Remove(listeAttente);
            await _context.SaveChangesAsync();
          
        }

        /// <summary>
        /// Cette methode Verifie s'il existe deja une liste d'attente dans la meme clinique pour la meme date.
        /// </summary>
        /// <param name="dateEffectivite"></param>
        /// <param name="cliniqueID"></param>
        /// <param name="listeAttenteID"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueID, int? listeAttenteID = null)
        {
            var query = _context.ListeAttentes.Where(la => la.DateEffectivite == dateEffectivite && la.CliniqueID == cliniqueID);

            if (listeAttenteID.HasValue)
            {
                query = query.Where(la => la.ListeAttenteID != listeAttenteID.Value);
                return query.Any();
            }
            else
            {
                return query.Any()
             ? throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.")
             : false;
            }
        }
        /// <summary>
        /// Verifie le nombree de Medecins et l existance de la liste d'attente avent d'ajouter les plages horaires. 
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        public bool ListeAttenteIsValid(ListeAttente listeAttente)
        {
           
                if (!VerifierSiListeAttenteEstCree(listeAttente) ||
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
                        : throw new ValidationException("Il faut creer une liste d'attente avant");
        }

        public bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente)
        {
            return listeAttente.NbMedecinsDispo >= 1
                    ? true
                    : throw new ValidationException("On doit avoir au moins un medecin disponible.");
        }

        public bool VerifierSiHeureOuvertureValide(ListeAttente listeAttente)
        {
            return listeAttente.HeureOuverture < listeAttente.HeureFermeture
                     ? true
                     : throw new ValidationException("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.");

        }
        public bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente)
        {

            return listeAttente.DateEffectivite >= DateTime.Now.Date
                   ? true
                   : throw new ValidationException("La date d'effectivite n'est pas valide. Elle doit etre posterieure a la date actuelle.");


        }

        public async Task GenererPlagesHorairesAsync(int ID)
        {
            var listeAttente = await _context.ListeAttentes.FindAsync(ID);
            if (!ListeAttenteIsValid(listeAttente))
            {
                throw new Exception("Liste d'attente invalide");
            }

            DateTime heureDebut = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureOuverture);
            DateTime finService = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureFermeture);
            PlageHoraire plageHoraire;
            
            while (heureDebut < finService)
            {
                DateTime nouvelleHeureFin = heureDebut.AddMinutes((double)listeAttente.Clinique.TempsMoyenConsultation);
                plageHoraire = new PlageHoraire
                {
                    HeureDebut = heureDebut,
                    HeureFin = nouvelleHeureFin,
                    ListeAttente= listeAttente

                };
                _context.PlagesHoraires.Add(plageHoraire);
                await _context.SaveChangesAsync();

                for (int i = 0; i < listeAttente.NbMedecinsDispo; i++)
                {
                    Consultation consultation = new Consultation
                    {
                        HeureDateDebutPrevue = heureDebut,
                        HeureDateFinPrevue = nouvelleHeureFin,
                        StatutConsultation = StatutConsultation.DisponiblePourReservation,
                        PlageHoraireID = plageHoraire.PlageHoraireID,
                        PatientID = null,
                        ///Salle=i++;

                    };
                    _context.Consultations.Add(consultation);

                }
                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();

        }


        public async Task<ListeAttenteVM> GetListeAttenteOrdonnee(int listeAttenteID)
        {
           var listeAttente = await _context.ListeAttentes
                                    .FirstOrDefaultAsync(la => la.ListeAttenteID== listeAttenteID);
            
            if (listeAttente == null)
            {
                throw new Exception("La liste d'attente n'existe pas");
            }


           var plagesHoraires = await _context.PlagesHoraires
                                      .Where(ph=> ph.ListeAttenteID == listeAttenteID)
                                      .OrderBy(ph => ph.PlageHoraireID)
                                      //.SkipWhile(ph => ph.Consultations.All(c => c.StatutConsultation != StatutConsultation.DisponiblePourReservation))
                                     
                                      .ToListAsync();

            
            var index = plagesHoraires.FindIndex(ph => ph.Consultations.Any(c => c.StatutConsultation == StatutConsultation.DisponiblePourReservation));
            if (index != -1)
            {
                plagesHoraires = plagesHoraires.Skip(index).ToList();
            }



            foreach (var plageHoraire in plagesHoraires)
            {
                plageHoraire.Consultations = await _context.Consultations
                                                           .Where(c => c.PlageHoraireID == plageHoraire.PlageHoraireID)
                                                           .OrderBy(c => c.ConsultationID)
                                                           .ToListAsync();
            }


            var listeAttenteVM = new ListeAttenteVM
            {
                ListeAttente = listeAttente,
                PlagesHoraires = plagesHoraires
            };

            return listeAttenteVM; 
        }



        public async Task<ListeAttenteVM> GetListeSalleAttenteOrdonnee(int listeAttenteID)
        {
            var listeAttente = await _context.ListeAttentes
                                    .FirstOrDefaultAsync(la => la.ListeAttenteID == listeAttenteID);

            if (listeAttente == null)
            {
                throw new Exception("La liste d'attente n'existe pas");
            }


            var plagesHoraires = await _context.PlagesHoraires
                                       .Where(ph => ph.ListeAttenteID == listeAttenteID).ToListAsync();


           List<Consultation> consultations = await _context.Consultations
                                                           .Where(c => c.PlageHorarie.ListeAttenteID == listeAttenteID && c.StatutConsultation == StatutConsultation.EnAttente)
                                                           .OrderBy(c => c.HeureDateDebutPrevue)
                                                           .ThenBy(c => c.Patient.Prenom)
                                                           .ThenBy(c => c.Patient.Nom)
                                                           .ToListAsync();
        
           

            var listeSalleAttente = new ListeAttenteVM
            {
                ListeAttente = listeAttente,
                PlagesHoraires = plagesHoraires,
                Consultations=consultations
                
            };

            return listeSalleAttente;





        }
    }
}
