using Clinique2000_DataAccess.Data;
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
                if (_db.Database.GetPendingMigrations().Count() > 0) { _db.Database.Migrate(); }
            }
            catch (Exception ex) { }




        }
    }
}
