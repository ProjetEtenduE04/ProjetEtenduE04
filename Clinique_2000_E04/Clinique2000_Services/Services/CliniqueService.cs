using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class CliniqueService : ServiceBaseAsync<Clinique>, ICliniqueService
    {
        private readonly CliniqueDbContext _context;

        public CliniqueService(CliniqueDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtient les listes d'attentes (la vue pour les patients)
        /// </summary>
        /// <param name="clinicId">ID de clinique qui a choisi</param>
        /// <param name="isOuvert"> filtre selon l'etat pour affichie seulement les listes d'attentes sont ouvert</param>
        /// <returns>Les listes d'attentes sont ouvert pour un clinique a choisi</returns>
        /// 
       

        public async Task<IList<ListeAttente>> GetListeAttentePourPatientAsync(int clinicId, bool? isOuvert)
        {
            IQueryable<ListeAttente> query = _context.Set<ListeAttente>();

            if (!isOuvert.HasValue)
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);
            }
            else if (isOuvert.Value)
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);
            }
            else
            {
                query = query
                    .Where(la => la.Clinique.CliniqueID == clinicId && !la.IsOuverte)
                    .OrderBy(x => x.DateEffectivite);
            }

            return await query.ToListAsync();
        }
    }
}
