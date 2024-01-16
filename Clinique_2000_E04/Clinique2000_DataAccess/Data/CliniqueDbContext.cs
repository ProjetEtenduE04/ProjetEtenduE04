using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;

namespace Clinique2000_DataAccess.Data
{
    public class CliniqueDbContext : IdentityDbContext
    {
        // Définissez ici les DbSets pour vos entités.
        // public DbSet<Entity> TableName { get ; set ; }
        
       

        public DbSet<ListeAttente> ListeAttentes { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientACharge> PatientACharges { get; set; }
        public DbSet<PlageHoraire> PlagesHoraires { get; set; }
        public DbSet<Clinique> Cliniques { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public CliniqueDbContext(DbContextOptions<CliniqueDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("scaffolding");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CliniqueDbContext).Assembly);
            modelBuilder.GenerateData();
        }


    }
}
