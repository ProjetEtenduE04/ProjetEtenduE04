using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Services.Services
{
    public class ListeAttenteService : ServiceBaseAsync<ListeAttente>, IListeAttenteService
    {

        private readonly CliniqueDbContext _context;

        public ListeAttenteService (CliniqueDbContext context): base(context)
        {
            _context = context;
        }



        public async Task GenererPlagesHorairesAsync(ListeAttente listeAttente)
        {
            DateTime heureDebut = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureOuverture);
            DateTime finService = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureFermeture);

            while (heureDebut < finService)
            {
                DateTime nouvelleHeureFin = heureDebut.AddMinutes(listeAttente.dureeConsultationMinutes);//ajouer la duree de consultation a classe ListeAttente    

                for (int i = 0; i < listeAttente.NbMedecinsDispo; i++)
                {
                    var plageHoraire = new PlageHoraire
                    {
                        HeureDebut = heureDebut,
                        HeureFin = nouvelleHeureFin
                    };
                    _context.PlagesHoraires.Add(PlageHoraire);
                }

                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();
        }

        
        }
        

    
}
