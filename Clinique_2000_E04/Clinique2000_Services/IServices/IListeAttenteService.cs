using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;

namespace Clinique2000_Services.IServices
{
    public interface IListeAttenteService:IServiceBaseAsync<ListeAttente>
    {
        Task GenererPlagesHorairesAsync(ListeAttente listeAttente);
        Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente);
        bool ListeAttenteIsValid(ListeAttente listeAttente);
        bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueId);
        bool VerifierSiListeAttenteEstCree(ListeAttente listeAttente);
        bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente);
        bool VerifierSiHeureOuvertureValide(ListeAttente listeAttente);
        bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente);
       
    }
}
