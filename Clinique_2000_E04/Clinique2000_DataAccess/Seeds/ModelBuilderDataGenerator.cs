
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Clinique2000_Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace Clinique2000_DataAccess.Seeds
{
    public static class ModelBuilderDataGenerator
    {
        public static void GenerateData(ModelBuilder builder)
        {


            #region Adresse 
            builder.Entity<Adresse>().HasData(
                new Adresse()
                {
                    AdresseID = 1,
                    Numero = "505",
                    Rue = "Rue Adoncour",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "J4G 2M6",

                },
                new Adresse()
                {
                    AdresseID = 2,
                    Numero = "1615",
                    Rue = "Blvd Jacques-Cartier",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "J4M 2X1",
                },
                new Adresse()
                {
                    AdresseID = 3,
                    Numero = "1144",
                    Rue = "Rue Saint-Laurent",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "J4K 1E2",
                },
                new Adresse()
                {
                    AdresseID = 4,
                    Numero = "3141",
                    Rue = "Blvd Taschereau",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "J4V 2H2",
                },
                new Adresse()
                {
                    AdresseID = 5,
                    Numero = "895",
                    Rue = "Rue De la Gauchetière",
                    Ville = "Montreal",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "H3B 4G1",
                },
                new Adresse()
                {
                    AdresseID = 6,
                    Numero = "5580",
                    Rue = " Ch. de Chambly B",
                    Ville = "Saint-Hubert",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "J3Y 3P5",
                    }
            );

            #endregion

            #region Clinique

            builder.Entity<Clinique>().HasData(
             new Clinique()
             {
                 CliniqueID = 1,
                 NomClinique = "Clinique Adoncour",
                 Courriel = "contact@adoncour.ca",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(17, 0, 0),
                 TempsMoyenConsultation = 30,
                 EstActive = true,
                 AdresseID = 1,
                 NumTelephone = "(450) 646-4445",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",

             },
             new Clinique()
             {
                 CliniqueID = 2,
                 NomClinique = "Clinique Pierre-Boucher",
                 Courriel = "contact@pboucher.ca",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(22, 0, 0),
                 TempsMoyenConsultation = 30,
                 EstActive = true,
                 AdresseID = 2,
                 NumTelephone = "(450) 468-6223",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
             },
             new Clinique()
             {
                 CliniqueID = 3,
                 NomClinique = "Clinique Medicale Urgence Camu",
                 Courriel = "contact@camu.ca",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(18, 0, 0),
                 TempsMoyenConsultation = 20,
                 EstActive = true,
                 AdresseID = 3,
                 NumTelephone = "(450) 679-4333",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223"
             },
             new Clinique()
             {
                 CliniqueID = 4,
                 NomClinique = "Medical Clinic GMF La Cigogne",
                 Courriel = "contact@cigogne.ca",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(20, 0, 0),
                 TempsMoyenConsultation = 40,
                 EstActive = true,
                 AdresseID = 4,
                 NumTelephone = "(450) 466-7892",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
             },
             new Clinique()
             {
                 CliniqueID = 5,
                 NomClinique = "Clinique Medicale en Route",
                 Courriel = "contact@cmenroute.ca",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(16, 0, 0),
                 TempsMoyenConsultation = 10,
                 EstActive = true,
                 AdresseID = 5,
                 NumTelephone = "(514) 954-1444",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
             },
             new Clinique()
             {
                 CliniqueID = 6,
                 NomClinique = "Centre Médical Chambly Latour",
                 Courriel = "contact@chambly.com",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(16, 0, 0),
                 TempsMoyenConsultation = 15,
                 EstActive = true,
                 AdresseID = 6,
                 NumTelephone = "(450) 926-2236",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
             }
          );
            #endregion
            #region ListeAttente
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 1,
                CliniqueID = 1, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 2,
                CliniqueID = 2, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(8, 30, 0),
                NbMedecinsDispo = 1,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 3,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 4,
                CliniqueID = 4, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 5,
                CliniqueID = 5, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 6,
                CliniqueID =6, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            // Generate 6 ListeAttente objects for Clinique with CliniqueID 4
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 7,
                CliniqueID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 8,
                CliniqueID = 2,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 9,
                CliniqueID = 3,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 10,
                CliniqueID = 4,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(4),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 11,
                CliniqueID = 4,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(5),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 12,
                CliniqueID = 4,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(6),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });
            // Generate 6 ListeAttente objects for Clinique with CliniqueID 5
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 13,
                CliniqueID = 5,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(3),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 14,
                CliniqueID = 6,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(4),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 15,
                CliniqueID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(3),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 16,
                CliniqueID = 5,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(4),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 17,
                CliniqueID = 5,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(5),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 18,
                CliniqueID = 5,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(6),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });


            // Generate 6 ListeAttente objects for Clinique with CliniqueID 6
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 19,
                CliniqueID = 6,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 20,
                CliniqueID = 6,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 21,
                CliniqueID = 6,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(3),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 22,
                CliniqueID = 6,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(4),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 23,
                CliniqueID = 6,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(5),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 24,
                CliniqueID = 6,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(6),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });
            #endregion
            #region ApplicationUser
            // Create ApplicationUser objects
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df223",
                UserName = "patient1@example.com",
                NormalizedUserName = "PATIENT1@EXAMPLE.COM",
                Email = "patient1@example.com",
                NormalizedEmail = "PATIENT1@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                UserName = "patient2@example.com",
                NormalizedUserName = "PATIENT2@EXAMPLE.COM",
                Email = "patient2@example.com",
                NormalizedEmail = "PATIENT2@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                UserName = "patient3@example.com",
                NormalizedUserName = "PATIENT3@EXAMPLE.COM",
                Email = "patient3@example.com",
                NormalizedEmail = "PATIENT3@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                UserName = "patient4@example.com",
                NormalizedUserName = "PATIENT4@EXAMPLE.COM",
                Email = "patient4@example.com",
                NormalizedEmail = "PATIENT4@EXAMPLE.COM",
                EmailConfirmed = true,


            });


            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 1,
                Nom = "Eastwood",
                Prenom = "Clint",
                Genre = "Masculin",
                NAM = "EASC 2342 4332",
                CodePostal = "J4J 1Z4",
                DateDeNaissance = new DateTime(1990, 1, 1),
                Age = 32,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df223" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 2,
                Nom = "Blunt",
                Prenom = "Emily",
                Genre = "Féminine",
                NAM = "BLUE 4232 4332",
                CodePostal = "J4J 1V2",
                DateDeNaissance = new DateTime(1995, 5, 5),
                Age = 27,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 3,
                Nom = "Brando",
                Prenom = "Marlon",
                Genre = "Masculin",
                NAM = "MARB 3244 2233",
                CodePostal = "J4J 1G4",
                DateDeNaissance = new DateTime(1985, 10, 10),
                Age = 36,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 4,
                Nom = "Portman",
                Prenom = "Natalie",
                Genre = "Féminine",
                NAM = "PORT 3443 3433",
                CodePostal = "J4J 1H6",
                DateDeNaissance = new DateTime(1980, 8, 8),
                Age = 42,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g4" // Replace with the corresponding UserId
            });
            #endregion          
        }
    }
}
