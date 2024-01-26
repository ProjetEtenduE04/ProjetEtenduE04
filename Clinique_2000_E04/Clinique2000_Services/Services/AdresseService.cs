using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.EntityFrameworkCore;
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


        public async Task<double> CalculerDistanceEntre2CodesPostaux(string postalCode1, string postalCode2)
        {
            var location1 = await GetLocationByPostalCodeAsync(postalCode1);
            var location2 = await GetLocationByPostalCodeAsync(postalCode2);

            if (location1 == null || location2 == null)
            {
                throw new ArgumentException("One or both postal codes are invalid.");
            }

            return CalculerDistance(location1.Latitude, location1.Longitude, location2.Latitude, location2.Longitude);
        }

        public async Task<AdressesQuebec> GetLocationByPostalCodeAsync(string postalCode)
        {
            return await _context.AdressesQuebec.FirstOrDefaultAsync(a => a.PostalCode == postalCode);
        }

        private double CalculerDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // Radius of the Earth in kilometers
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            lat1 = ToRadians(lat1);
            lat2 = ToRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return Math.Round((R * c),2); // Distance in KM
        }

        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
