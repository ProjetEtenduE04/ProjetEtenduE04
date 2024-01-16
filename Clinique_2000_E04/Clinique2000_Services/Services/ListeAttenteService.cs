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

        public Task ReserverConsultation(Consultation consultation, Patient patient)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// Cette methode s'occupe de cr�er une consultation
        ///// </summary>
        ///// <param name="patient"></param>
        ///// <param name="plagehoraire"></param>
        ///// <returns></returns>
        //public async Task ReserverConsultation(Patient patient, PlageHoraire plagehoraire)
        //{
        //    var consultation = new Consultation();

        //    if (PeutReserver(patient))    //On verifie ici que le patient n'a pas deja une consultation en attente.
        //    {
        //        //on cree la consultation
        //        consultation.StatutConsultation = StatutConsultation.EnAttente;
        //        consultation.Patient = patient;
        //        consultation.HeureDateDebutPrevue = plagehoraire.Consultations.Where(x => x.Patient == patient).First().HeureDateDebutPrevue;
        //        consultation.HeureDateFinPrevue = plagehoraire.Consultations.Where(x => x.Patient == patient).First().HeureDateFinPrevue;
        //        consultation.HeureDateDebutReele = null;
        //        consultation.HeureDateFinReele = null;

        //        _context.Consultations.Add(consultation);
        //        _context.SaveChanges();
        //    }
        //    throw new ValidationException("Une consultation est deja en attente. Veuillez annuller celle-ci afin d'en demander une nouvelle.");


        //}

          
        ///// <summary>
        ///// Cette methode recoit une consultation et un patient, assigne le patient a la consultation,
         ///// </summary>  
        ///// <param name="consultation"></param>
        ///// <param name="patient"></param>
        ///// <returns></returns>     
        ///// <exception cref="ValidationException"></exception>
        //public async Task ReserverConsultation(Consultation consultation,Patient patient/*,Medecin medecin*/)
        //{

        //    if (PeutReserver(consultation.Patient,consultation) && consultation.StatutConsultation==StatutConsultation.DisponiblePourReservation)    //On verifie ici que le patient n'a pas deja une consultation en attente, et que la Consultation est disponible
        //    {          //        //on change le statut de la consultation a EnAttente
        //        consultation.StatutConsultation = StatutConsultation.EnAttente;
        //        consultation.Patient = patient;
        //        /*consultation.medecin= medecin*/
        //        consultation.HeureDateDebutReele = null;
        //        consultation.HeureDateFinReele = null;
        //        _context.Update(consultation);
        //        _context.SaveChanges();
        //    }
        //    else
        //    throw new ValidationException("Une consultation est deja en attente. Veuillez annuller celle-ci afin d'en demander une nouvelle.");

 


         /// <summary>    
        /// Cette methode verifie si le patient a deja une demande de consultation en attente
        /// </summary>
        /// <param name="patient"></param>     
        /// <returns> Si deja consultation en attente, retourne false, sinon, retourne true </returns>
        //public bool PeutReserver(Patient patient, Consultation consultation)
        //{
        //    if(patient.consultation != null && consultation.StatutConsultation == StatutConsultation.DisponiblePourReservation)
        //    {
        //        return true;
        //    }
        //    return false;
        //}


    }
}
