using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Data
{
    public class CliniqueDbContext:DbContext
    {
        // Définissez ici les DbSets pour vos entités.
        // public DbSet<Entity> TableName { get ; set ; }


         public DbSet<ListeAttente>? ListeAttentes { get ; set ; }

        public CliniqueDbContext(DbContextOptions<CliniqueDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CliniqueDbContext).Assembly);
        }
    }
}
