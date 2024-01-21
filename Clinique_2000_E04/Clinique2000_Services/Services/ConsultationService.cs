using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    /// <summary>
    /// Service de gestion des consultations.
    /// </summary>
    public class ConsultationService : ServiceBaseAsync<Consultation>, IConsultationService
    {
        private readonly CliniqueDbContext _context;
        private readonly IPatientService _servicePatient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initialise une nouvelle instance du service de consultation.
        /// </summary>
        /// <param name="context">Le contexte de base de données.</param>
        /// <param name="servicePatient">Le service de gestion des patients.</param>
        /// <param name="httpContextAccessor">L'accessoir HTTP pour accéder au contexte de la requête.</param>
        public ConsultationService(CliniqueDbContext context, IPatientService servicePatient, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _servicePatient = servicePatient;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Réserve une consultation pour un patient.
        /// </summary>
        /// <param name="consultationId">L'identifiant de la consultation à réserver.</param>
        /// <exception cref="ValidationException">En cas d'échec des vérifications.</exception>
        public async Task ReserverConsultationAsync(int consultationId)
        {
            // Récupérer la consultation existante depuis la base de données
            var consultation = await _context.Consultations.FindAsync(consultationId);

            if (consultation == null)
            {
                throw new ValidationException("Consultation introuvable.");
            }

            var patientId = await ObtenirIdPatientAsync();

            // Vérifier si le patient a déjà une consultation planifiée
            if (await PatientAConsultationPlanifieeAsync(patientId))
            {
                throw new ValidationException("Le patient a déjà une consultation planifiée.");
            }

            if (await ListeAttenteOuverteAsync(consultationId) == false)
            {
                throw new ValidationException("La liste d'attente est fermée.");
            }

            consultation.PatientID = patientId;
            consultation.StatutConsultation = StatutConsultation.EnAttente;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Récupère de manière asynchrone la plage horaire et la liste d'attente associées à un identifiant de consultation donné.
        /// Lance une ValidationException si la consultation, la plage horaire ou la liste d'attente ne peuvent être trouvées.
        /// </summary>
        /// <param name="consultationId">L'identifiant de la consultation.</param>
        /// <returns>Un tuple contenant les objets PlageHoraire et ListeAttente associés.</returns>
        public async Task<(PlageHoraire, ListeAttente)> ObtenirPlageHoraireEtListeAttenteAsync(int consultationId)
        {
            if (consultationId == null)
            {
                throw new ValidationException("Consultation introuvable.");
            }

            Consultation consultation = await _context.Consultations.FindAsync(consultationId);

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
        /// Vérifie si la liste d'attente est ouverte pour une consultation donnée.
        /// </summary>
        /// <param name="consultationId">L'identifiant de la consultation.</param>
        /// <returns>true si la liste d'attente est ouverte, sinon false.</returns>
        public async Task<bool> ListeAttenteOuverteAsync(int consultationId)
        {
            var tuple = await ObtenirPlageHoraireEtListeAttenteAsync(consultationId);
            ListeAttente listeAttente = tuple.Item2;

            // Vérifie si la liste d'attente est ouverte
            return listeAttente != null && listeAttente.IsOuverte;
        }

        private async Task<int> ObtenirIdPatientAsync()
        {
            var userId = ObtenirIdUtilisateur();
            return await ObtenirIdPatientDepuisUtilisateurAsync(userId);
        }

        private string ObtenirIdUtilisateur()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<int> ObtenirIdPatientDepuisUtilisateurAsync(string userId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
            return patient?.PatientId ?? 0; // Retourne 0 ou un ID de patient valide
        }

        /// <summary>
        /// Vérifie si un patient a une consultation planifiée en attente.
        /// </summary>
        /// <param name="patientId">L'identifiant du patient.</param>
        /// <returns>true si le patient a une consultation planifiée en attente, sinon false.</returns>
        public async Task<bool> PatientAConsultationPlanifieeAsync(int patientId)
        {
            if (await _context.Consultations
                .AnyAsync(c => c.PatientID == patientId && c.StatutConsultation == StatutConsultation.EnAttente))
            {
                throw new ValidationException("Vous avez déjà une consultation planifiée.");
            }
            else
                return false;
        }
    }
}
