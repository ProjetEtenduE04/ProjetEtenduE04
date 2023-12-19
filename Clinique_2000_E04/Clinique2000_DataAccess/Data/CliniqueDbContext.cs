using Clinique2000_Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Core.Models;

namespace Clinique2000_DataAccess.Data
{
    public class CliniqueDbContext : DbContext
    {
        // Définissez ici les DbSets pour vos entités.
        // public DbSet<Entity> TableName { get ; set ; }
        public DbSet<ListeAttente> listeAttentes { get; set; }
        public DbSet<PlageHoraire> PlagesHoraires{ get; set; }


        public DbSet<ListeAttente> ListeAttentes { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientACharge> PatientACharges { get; set; }
        public DbSet<Personne> Personnes { get; set; }




        public CliniqueDbContext(DbContextOptions<CliniqueDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CliniqueDbContext).Assembly);
            modelBuilder.Entity<Personne>().ToTable("Personne");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<PatientACharge>().ToTable("PatientACharge");

        }


    }
}
