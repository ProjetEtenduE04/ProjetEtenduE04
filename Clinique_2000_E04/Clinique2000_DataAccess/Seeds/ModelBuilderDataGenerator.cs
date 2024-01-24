
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
                    Numero = "7-756",
                    Rue = "rue de la Clinique",
                    Ville = "Montréal",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "H1H 1H1",

                },
                new Adresse()
                {
                    AdresseID = 2,
                    Numero = "2-66",
                    Rue = "rue de la Cegep",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "A1A 1A1",
                },
                 new Adresse()
                 {
                     AdresseID = 3,
                     Numero = "123",
                     Rue = "rue de la Santé",
                     Ville = "Sherbrooke",
                     Province = "Québec",
                     Pays = "Canada",
                     CodePostal = "J1J 1J1",
                 },
    new Adresse()
    {
        AdresseID = 4,
        Numero = "456",
        Rue = "rue de l'Hôpital",
        Ville = "Laval",
        Province = "Québec",
        Pays = "Canada",
        CodePostal = "L2L 2L2",
    },
    new Adresse()
    {
        AdresseID = 5,
        Numero = "789",
        Rue = "rue de la Thérapie",
        Ville = "Gatineau",
        Province = "Québec",
        Pays = "Canada",
        CodePostal = "G3G 3G3",
    },
    new Adresse()
    {
        AdresseID = 6,
        Numero = "012",
        Rue = "rue de la Médecine",
        Ville = "Québec",
        Province = "Québec",
        Pays = "Canada",
        CodePostal = "Q4Q 4Q4",
    }
            );

            #endregion

            #region Clinique

            builder.Entity<Clinique>().HasData(
             new Clinique()
             {
                 CliniqueID = 1,
                 NomClinique = "CliniqueA",
                 Courriel = "test@clinique2000.com",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(17, 0, 0),
                 TempsMoyenConsultation = 30,
                 EstActive = true,
                 AdresseID = 1,
                 NumTelephone = "(438) 333-5555",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",

             },
             new Clinique()
             {
                 CliniqueID = 2,
                 NomClinique = "CliniqueB",
                 Courriel = "Test2@test.com",
                 HeureOuverture = new TimeSpan(8, 0, 0),
                 HeureFermeture = new TimeSpan(17, 0, 0),
                 TempsMoyenConsultation = 30,
                 EstActive = true,
                 AdresseID = 2,
                 NumTelephone = "(438) 333-7777",
                 CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
             }

          );



            builder.Entity<Clinique>().HasData(new Clinique()
            {
                CliniqueID = 3,
                NomClinique = "Clinique3",
                Courriel = "contact@clinique3.com",
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                TempsMoyenConsultation = 30,
                EstActive = true,
                AdresseID = 3,
                NumTelephone = "(100) 100-1030",
                CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
            });
            builder.Entity<Clinique>().HasData(new Clinique()
            {
                CliniqueID = 4,
                NomClinique = "Clinique4",
                Courriel = "contact@clinique4.com",
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                TempsMoyenConsultation = 30,
                EstActive = true,
                AdresseID = 4,
                NumTelephone = "(100) 100-1040",
                CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
            });
            builder.Entity<Clinique>().HasData(new Clinique()
            {
                CliniqueID = 5,
                NomClinique = "Clinique5",
                Courriel = "contact@clinique5.com",
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                TempsMoyenConsultation = 30,
                EstActive = true,
                AdresseID = 5,
                NumTelephone = "(100) 100-1050",
                CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
            });
            builder.Entity<Clinique>().HasData(new Clinique()
            {
                CliniqueID = 6,
                NomClinique = "Clinique6",
                Courriel = "contact@clinique6.com",
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                TempsMoyenConsultation = 30,
                EstActive = true,
                AdresseID = 6,
                NumTelephone = "(100) 100-1060",
                CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",
            });
            #endregion
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 1,
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
                ListeAttenteID = 2,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 3,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(3),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 4,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(4),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 5,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(5),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 6,
                CliniqueID = 3, // You can set the CliniqueID here if needed, otherwise remove this line
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(6),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            // Generate 6 ListeAttente objects for Clinique with CliniqueID 4
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 7,
                CliniqueID = 4,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 8,
                CliniqueID = 4,
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
                CliniqueID = 4,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(3),
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
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 14,
                CliniqueID = 5,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 30,
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 15,
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
                Nom = "Patient1Nom",
                Prenom = "Patient1Prenom",
                Genre = "Genre1",
                NAM = "NAM1",
                CodePostal = "A1A 1A1",
                DateDeNaissance = new DateTime(1990, 1, 1),
                Age = 32,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df223" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 2,
                Nom = "Patient2Nom",
                Prenom = "Patient2Prenom",
                Genre = "Genre2",
                NAM = "NAM2",
                CodePostal = "B2B 2B2",
                DateDeNaissance = new DateTime(1995, 5, 5),
                Age = 27,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 3,
                Nom = "Patient3Nom",
                Prenom = "Patient3Prenom",
                Genre = "Genre3",
                NAM = "NAM3",
                CodePostal = "C3C 3C3",
                DateDeNaissance = new DateTime(1985, 10, 10),
                Age = 36,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3" // Replace with the corresponding UserId
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 4,
                Nom = "Patient4Nom",
                Prenom = "Patient4Prenom",
                Genre = "Genre4",
                NAM = "NAM4",
                CodePostal = "D4D 4D4",
                DateDeNaissance = new DateTime(1980, 8, 8),
                Age = 42,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g4" // Replace with the corresponding UserId
            });
        }
    }
}
