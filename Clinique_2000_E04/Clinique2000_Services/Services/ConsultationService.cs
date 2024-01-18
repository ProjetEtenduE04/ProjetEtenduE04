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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Clinique2000_Services.Services
{
    public class ConsultationService : ServiceBaseAsync<Consultation>, IConsultationService
    {
        private readonly CliniqueDbContext _context;
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConsultationService(CliniqueDbContext context, IPatientService patientService, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _patientService = patientService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Réserve une consultation pour un patient.
        /// </summary>
        /// <param name="consultationId">L'identifiant de la consultation à réserver.</param>
        /// <exception cref="ValidationException">En cas d'échec des vérifications.</exception>
        public async Task ReserverConsultationAsync(int consultationId)
        {
            // Retrieve the existing consultation from the database
            var consultation = await _context.Consultations.FindAsync(consultationId);

            if (consultation == null)
            {
                throw new ValidationException("Consultation introuvable.");
            }

            var patientId = await ObtenirPatientId();

            // Vérifier si le patient a déjà une consultation planifiée
            if (await PatientAConsultationPlanifiee(patientId))
            {
                throw new ValidationException("Le patient a déjà une consultation planifiée.");
            }

            if (!await ListeAttenteEstOuverte(consultationId))
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
        public async Task<(PlageHoraire, ListeAttente)> GetPlageHoraireEtListeAttenteParConsultationIdAsync(int consultationId)
        {
            if (consultationId == null)
            {
                throw new ValidationException("Consultation introuvable.");
            }

            Consultation consultationn = await _context.Consultations.FindAsync(consultationId);

            var plageHoraire = await _context.PlagesHoraires.FindAsync(consultationn.PlageHoraireID);
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
        public async Task<bool> ListeAttenteEstOuverte(int consultationId)
        {
            var tuple = await GetPlageHoraireEtListeAttenteParConsultationIdAsync(consultationId);
            ListeAttente listeAttente = tuple.Item2;

            // Vérifie si la liste d'attente est ouverte
            return listeAttente != null && listeAttente.IsOuverte;
        }

        private async Task<int> ObtenirPatientId()
        {
            var userId = GetUserId();
            return await GetPatientIdFromUserId(userId);
        }

        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        private async Task<int> GetPatientIdFromUserId(string userId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
            return patient?.PatientId ?? 0; // Retourne 0 ou un ID de patient valide
        }

        /// <summary>
        /// Vérifie si un patient a une consultation planifiée en attente.
        /// </summary>
        /// <param name="patientId">L'identifiant du patient.</param>
        /// <returns>true si le patient a une consultation planifiée en attente, sinon false.</returns>
        public async Task<bool> PatientAConsultationPlanifiee(int patientId)
        {
            return await _context.Consultations
                .AnyAsync(c => c.PatientID == patientId && c.StatutConsultation == StatutConsultation.EnAttente);
        }

    
    }
}
