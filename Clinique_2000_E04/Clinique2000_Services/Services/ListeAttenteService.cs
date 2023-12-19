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

     

        public async Task GenererPlagesHorairesAsync(ListeAttente listeAttente )
        {
            
            DateTime heureDebut = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureOuverture);
            DateTime finService = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureFermeture);
            PlageHoraire plageHoraire;
            while (heureDebut < finService)
            {
                DateTime nouvelleHeureFin = heureDebut.AddMinutes((double)listeAttente.Clinique.TempsMoyenConsultation);  

                for (int i = 0; i < listeAttente.NbMedecinsDispo; i++)
                {
                    plageHoraire = new PlageHoraire
                    {
                        HeureDebut = heureDebut,
                        HeureFin = nouvelleHeureFin
                    };
                    _context.PlagesHoraires.Add(plageHoraire);
                    listeAttente.PlagesHoraires.Add(plageHoraire);
                }

                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();
            
         
        }

        }
        

    
}
