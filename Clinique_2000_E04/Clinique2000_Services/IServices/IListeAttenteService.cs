using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_Services.IServices
{
    public interface IListeAttenteService : IServiceBaseAsync<ListeAttente>
    {
        Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente);
        Task<ListeAttente> ModifierListeAttenteAsync(ListeAttente listeAttente);
        bool PeutSupprimmer(ListeAttente listeAttente);
        Task SupprimmerListeAttente(ListeAttente listeAttente);
        bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueID, int? listeAttenteID = null);
        bool ListeAttenteIsValid(ListeAttente listeAttente);
        bool VerifierSiListeAttenteEstCree(ListeAttente listeAttente);
        bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente);
        bool VerifierSiHeureOuvertureValide(ListeAttente listeAttente);
        bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente);
        Task GenererPlagesHorairesAsync(int ID);
        Task<ListeAttenteVM> GetListeAttenteOrdonnee(int listeAttenteID);
        Task<ListeAttenteVM> GetListeSalleAttenteOrdonnee(int listeAttenteID);
        Task<ListeAttenteVM> AppelerProchainPatient(int consultaionID, int employeCliniqueID);
        Task<ListeAttenteVM> TerminerConsultationEtAppellerProchainPatient(int consultaionID, int employeCliniqueID);
        Task<ListeAttenteVM> TerminerConsultation(int consultaionID);
        Task AnnulerConsultationAsync(Patient patient);
    }
}
