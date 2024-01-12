using Clinique2000_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Clinique2000_DataAccess.Data
{
    public class CliniqueDbContext : IdentityDbContext
    {
        // Définissez ici les DbSets pour vos entités.
        // public DbSet<Entity> TableName { get ; set ; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientACharge> PatientACharges { get; set; }
        public DbSet<Personne> Personnes { get; set; }

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
            modelBuilder.Entity<Personne>().ToTable("Personne");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<PatientACharge>().ToTable("PatientACharge");

        }


    }
}
