using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class AdresseService : ServiceBaseAsync<Adresse>, IAdresseService
    {
        private readonly CliniqueDbContext _context;

        public AdresseService(CliniqueDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> VerifierCodePostalValideAsync(string codePostal)
        {
            var regex = new Regex(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$");
            if (!regex.IsMatch(codePostal))
            {
                throw new ValidationException("Le format du code postal n'est pas valide (Ex: A1A 1A1).");
            }

            return true;
        }
    }
}
