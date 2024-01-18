using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
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

        public Task<bool> VerifierExistenceCliniqueParId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
