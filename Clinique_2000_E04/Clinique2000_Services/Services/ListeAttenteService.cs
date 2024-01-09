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
using Microsoft.AspNetCore.Mvc;
using MessagePack.Formatters;

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
                throw new ValidationException("Il existe déjà une liste d'attente dans la meme clinique pour la meme  date.");
            }

            if (!VerifierSiDateEffectiviteValide(listeAttente) || !VerifierSiHeureOuvertureValide(listeAttente) )
            {
                throw new ValidationException("La liste n'est pas valide");
            }
            else { 
            await CreerAsync(listeAttente);
            return listeAttente;
            }
        }

        public bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueId)
        {
            if (_context.ListeAttentes.Any(l => l.DateEffectivite == dateEffectivite && l.CliniqueID == cliniqueId))
            {
                throw new ValidationException("Il existe déjà une liste d'attente dans la meme clinique pour la meme  date.");
            }
            return false;
        }

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
                        : throw new ValidationException("Il faut créer une liste d'attente avant");
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
                     : throw new ValidationException("L'heure d'ouverture doit etre inférieure à l'heure de fermeture.");

        }
        public bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente)
        {

            return listeAttente.DateEffectivite >= DateTime.Now.Date
                   ? true
                   : throw new ValidationException("La date d'effectivité n'est pas valide. Elle doit être postérieure à la date actuelle.");


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
            //Consultation consultation;
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

                    };
                    _context.Consultations.Add(consultation);

                }
                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();

        }




        //Consultation Logic


        /// <summary>
        /// Cette methode recupere un patient specifique par son ID
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns> Patient specifique et ses infos </returns>
        public async Task<Patient> RecupererInfosPatient(int PatientID)
        {
            Patient patient = await _context.Patients.Where(x => x.PatientId == PatientID).FirstOrDefaultAsync();
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            return patient;
        }



        /// <summary>
        /// Cette methode s'occupe de créer une consultation
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="plagehoraire"></param>
        /// <returns></returns>
        public async Task ReserverConsultation(Patient patient, PlageHoraire plagehoraire)
        {
            var consultation = new Consultation();

            if (PeutReserver(patient))    //On verifie ici que le patient n'a pas deja une consultation en attente.
            {
                //on cree la consultation
                consultation.StatutConsultation = StatutConsultation.EnAttente;
                consultation.Patient = patient;
                consultation.HeureDateDebutPrevue = plagehoraire.Consultations.Where(x => x.Patient == patient).First().HeureDateDebutPrevue;
                consultation.HeureDateFinPrevue = plagehoraire.Consultations.Where(x => x.Patient == patient).First().HeureDateFinPrevue;
                consultation.HeureDateDebutReele = null;
                consultation.HeureDateFinReele = null;

                _context.Consultations.Add(consultation);
                _context.SaveChanges();
            }
            throw new ValidationException("Une consultation est deja en attente. Veuillez annuller celle-ci afin d'en demander une nouvelle.");


        }

        /// <summary>
        /// Cette methode verifie si le patient a deja une demande de consultation en attente
        /// </summary>
        /// <param name="patient"></param>
        /// <returns> Si deja consultation en attente, retourne false, sinon, retourne true </returns>
        public bool PeutReserver(Patient patient)
        {
            if(patient.Consultation != null)
            {
                return true;
            }
            return false;
        }








    }
}
