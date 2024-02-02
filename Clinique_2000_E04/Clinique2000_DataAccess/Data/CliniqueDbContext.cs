using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Clinique2000_DataAccess.Seeds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Data
{
    public class CliniqueDbContext : IdentityDbContext
    {
        // Définissez ici les DbSets pour vos entités.
        // public DbSet<Entity> TableName { get ; set ; }


        public DbSet<AdressesQuebec> AdressesQuebec { get; set; }
        public DbSet<ListeAttente> ListeAttentes { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientACharge> PatientACharges { get; set; }
        public DbSet<PlageHoraire> PlagesHoraires { get; set; }
        public DbSet<Clinique> Cliniques { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public CliniqueDbContext(DbContextOptions<CliniqueDbContext> options) : base(options) { }
        public DbSet< EmployesClinique> EmployesClinique{ get; set; }
       

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

            // Seed data using the HasData method
            ModelBuilderDataGenerator.GenerateData(modelBuilder);
        }


    }
}
