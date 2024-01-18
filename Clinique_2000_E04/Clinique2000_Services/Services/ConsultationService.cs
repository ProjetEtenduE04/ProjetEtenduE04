using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Enum;
using MessagePack.Formatters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class ConsultationService:ServiceBaseAsync<Consultation>, IConsultationService
    {

        private readonly CliniqueDbContext _context;

        public ConsultationService(CliniqueDbContext context):base(context)
        {
            _context = context;
        }






        public async Task ReserverConsultationAsync(int patientId, int ConsultationId)
        {
            // recuperer les objets plagehoraire, listeattente et consultation reliés a la consultation en question
            var consultation = await _context.Consultations.FindAsync(ConsultationId);
            var tuple = GetPlageHoraireEtListeAttenteParConsultationIdAsync(ConsultationId);
            PlageHoraire plagehoraire = tuple.Result.Item1;
            ListeAttente listeattente = tuple.Result.Item2;

            //On verifie que la liste d'Attente est ouverte
            if (VerifierPlageHoraireValideEtListeAttenteOuverte(ConsultationId) == false)
            {
                throw new ValidationException("Plage horaire non disponible ou liste d'attente fermée.");
            }

            // Vérifier si le patient a déjà une consultation active
            if (VerifierSiPatientAdejaConsultationEnAttente(ConsultationId, patientId) == false)
            {
                throw new ValidationException("Vous possédez une consultation en attente, veuillez annuler celle-ci pour en demander une nouvelle.");
            }
            else

                //// Réserver la consultation
                //consultation = Consultation
                //{
                //    PatientID = patientId,
                //    PlageHoraireID = plageHoraireId,
                //    StatutConsultation = StatutConsultation.EnAttente,
                //    //MedecinID = 1,
                //};


                // Réserver la consultation
                consultation.StatutConsultation = StatutConsultation.EnAttente;
                consultation.PatientID = patientId;
                consultation.HeureDateDebutPrevue = plagehoraire.HeureDebut;
                consultation.HeureDateFinPrevue = plagehoraire.HeureFin;
                consultation.StatutConsultation = StatutConsultation.EnAttente;
                consultation.PlageHoraireID = plagehoraire.PlageHoraireID;




            _context.Consultations.Update(consultation);
            await _context.SaveChangesAsync();

           
        }






        /// <summary>
        /// Récupère de manière asynchrone la plage horaire et la liste d'attente associées à un identifiant de consultation donné.
        /// Lance une ValidationException si la consultation, la plage horaire ou la liste d'attente ne peuvent être trouvées.
        /// </summary>
        /// <param name="consultationId">L'identifiant de la consultation.</param>
        /// <returns>Un tuple contenant les objets PlageHoraire et ListeAttente associés.</returns>
        public async Task<(PlageHoraire, ListeAttente)> GetPlageHoraireEtListeAttenteParConsultationIdAsync(int consultationId)
        {
            var consultation = await _context.Consultations.FindAsync(consultationId);
            if (consultation == null)
            {
                throw new ValidationException("Consultation introuvable.");
            }

            var plageHoraire = await _context.PlagesHoraires.FindAsync(consultation.PlageHoraireID);
            if (plageHoraire == null)
            {
                throw new ValidationException("Plage horaire non trouvée.");
            }

            var listeAttente = await _context.ListeAttentes.FindAsync(plageHoraire.ListeAttenteID);
            if (listeAttente == null)
            {
                throw new ValidationException("Liste d'attente non trouvée.");
            }

            return (plageHoraire, listeAttente);
        }

        /// <summary>
        /// Cette methode prend une consultationId et un patientID en parametre afin de déterminer si le patient a deja une consultation en attente.
        /// Si c'est le cas, une erreur de validation est envoyee, sinon, il est elligible pour demander une consultation.
        /// </summary>
        /// <param name="consultationId"></param>
        /// <param name="patientID"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public bool VerifierSiPatientAdejaConsultationEnAttente(int consultationId, int patientID)
        {

            return _context.Consultations.Any(c => c.PatientID == patientID && c.StatutConsultation == StatutConsultation.EnAttente)
                ? true
                : false;
        }


        /// <summary>
        /// Cette methode verifie que la liste d'attente dans laquelle l'utilisateur essaie de reserver une consultation est ouverte,
        /// et que la plageHoraire choisie est pas null
        /// </summary>
        /// <param name="plageHoraireId"></param>
        /// <param name="listeattenteId"></param>
        /// <returns> false et ue erreur de validation, ou true</returns>
        /// <exception cref="ValidationException"></exception>
        public bool VerifierPlageHoraireValideEtListeAttenteOuverte(int ConsultationID)
        {

            var tuple = GetPlageHoraireEtListeAttenteParConsultationIdAsync(ConsultationID);
            PlageHoraire plagehoraire = tuple.Result.Item1;
            ListeAttente listeattente = tuple.Result.Item2;

            if (plagehoraire == null || listeattente.IsOuverte == false)
            {
                return false;
            }
            else
                return true;

        }








    }
}
