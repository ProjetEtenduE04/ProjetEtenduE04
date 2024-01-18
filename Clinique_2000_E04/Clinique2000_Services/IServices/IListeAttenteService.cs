using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_Services.IServices
{
    public interface IListeAttenteService:IServiceBaseAsync<ListeAttente>
    {
        Task GenererPlagesHorairesAsync(int ID);
        Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente);
        bool ListeAttenteIsValid(ListeAttente listeAttente);
        bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueID, int? listeAttenteID = null);
        bool VerifierSiListeAttenteEstCree(ListeAttente listeAttente);
        bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente);
        bool VerifierSiHeureOuvertureValide(ListeAttente listeAttente);
        bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente);

        Task<ListeAttente> ModifierListeAttenteAsync(ListeAttente listeAttente);
        Task SupprimmerListeAttente(ListeAttente listeAttente);
        bool PeutSupprimmer(ListeAttente listeAttente);


    }
}
