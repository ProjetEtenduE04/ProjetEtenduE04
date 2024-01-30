using Clinique2000_DataAccess.Data;
using Clinique2000_DataAccess.Seeds;
using Google;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Initializer
{
    public class DbInitialiser:IdbInitialiser
    {
        private readonly CliniqueDbContext _db;

        public DbInitialiser(CliniqueDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                    //ModelBuilderDataGenerator.GenerateData();
                }

            }
            catch (Exception ex) { }
            // Créer les rôles suivants si aucun rôle ne figure dans la bd 
            //if (!_roleManager.RoleExistsAsync(AppConstants.AdminCliniqueRole).GetAwaiter().GetResult()) 
            //{ 
            //    _roleManager.CreateAsync(new IdentityRole(AppConstants.AdminCliniqueRole)) 
            //        .GetAwaiter().GetResult(); 

            //    _roleManager.CreateAsync(new IdentityRole(AppConstants.MedicinRole)) 
            //                    .GetAwaiter().GetResult(); 

            //    _roleManager.CreateAsync(new IdentityRole(AppConstants.PatientRole)) 
            //                    .GetAwaiter().GetResult(); 


            //ApplicationUser user2 = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "aeromexico@Skylink.com"); 
            //_userManager.AddToRoleAsync(user2, AppConstants.ClientRole) 
            //    .GetAwaiter().GetResult(); 



        }
    }
}
