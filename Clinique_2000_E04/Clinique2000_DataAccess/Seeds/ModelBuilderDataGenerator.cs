
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Clinique2000_Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Clinique2000_Utility.Enum;

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
                 NomClinique = "Clinique Médicale Horizon",
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
            #endregion ListeAttente


            #region PlageHoraire
            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 1,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(0),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 2,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 3,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(0),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 4,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(0),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 5,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(0),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 6,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                ListeAttenteID = 1,
            });
            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 7,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 8,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 9,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                ListeAttenteID = 1,
            });


            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 10,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 11,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                ListeAttenteID = 1,
            });

            builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            {
                PlageHoraireID = 12,
                HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                HeureFin = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
                ListeAttenteID = 1,
            });


            #endregion PlageHoraire

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

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                UserName = "patient5@example.com",
                NormalizedUserName = "PATIENT5@EXAMPLE.COM",
                Email = "patient5@example.com",
                NormalizedEmail = "PATIENT5@EXAMPLE.COM",
                EmailConfirmed = true,


            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df226",
                UserName = "patient6@example.com",
                NormalizedUserName = "PATIENT6@EXAMPLE.COM",
                Email = "patient6@example.com",
                NormalizedEmail = "PATIENT6@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                UserName = "patient7@example.com",
                NormalizedUserName = "PATIENT7@EXAMPLE.COM",
                Email = "patient7@example.com",
                NormalizedEmail = "PATIENT7@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                UserName = "patient8@example.com",
                NormalizedUserName = "PATIENT8@EXAMPLE.COM",
                Email = "patient8@example.com",
                NormalizedEmail = "PATIENT8@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                UserName = "patient9@example.com",
                NormalizedUserName = "PATIENT9@EXAMPLE.COM",
                Email = "patient9@example.com",
                NormalizedEmail = "PATIENT9@EXAMPLE.COM",
                EmailConfirmed = true,


            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                UserName = "patient10@example.com",
                NormalizedUserName = "PATIENT10@EXAMPLE.COM",
                Email = "patient10@example.com",
                NormalizedEmail = "PATIENT10@EXAMPLE.COM",
                EmailConfirmed = true,


            });
            
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df211",
                UserName = "patient11@example.com",
                NormalizedUserName = "PATIENT11@EXAMPLE.COM",
                Email = "patient11@example.com",
                NormalizedEmail = "PATIENT11@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                UserName = "patient12@example.com",
                NormalizedUserName = "PATIENT12@EXAMPLE.COM",
                Email = "patient12@example.com",
                NormalizedEmail = "PATIENT12@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                UserName = "patient13@example.com",
                NormalizedUserName = "PATIENT13@EXAMPLE.COM",
                Email = "patient13@example.com",
                NormalizedEmail = "PATIENT13@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                UserName = "patient14@example.com",
                NormalizedUserName = "PATIENT14@EXAMPLE.COM",
                Email = "patient14@example.com",
                NormalizedEmail = "PATIENT14@EXAMPLE.COM",
                EmailConfirmed = true,


            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                UserName = "patient15@example.com",
                NormalizedUserName = "PATIENT15@EXAMPLE.COM",
                Email = "patient15@example.com",
                NormalizedEmail = "PATIENT15@EXAMPLE.COM",
                EmailConfirmed = true,


            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df216",
                UserName = "patient16@example.com",
                NormalizedUserName = "PATIENT16@EXAMPLE.COM",
                Email = "patient16@example.com",
                NormalizedEmail = "PATIENT16@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                UserName = "patient17@example.com",
                NormalizedUserName = "PATIENT17@EXAMPLE.COM",
                Email = "patient17@example.com",
                NormalizedEmail = "PATIENT17@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                UserName = "patient18@example.com",
                NormalizedUserName = "PATIENT18@EXAMPLE.COM",
                Email = "patient18@example.com",
                NormalizedEmail = "PATIENT18@EXAMPLE.COM",
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                UserName = "patient19@example.com",
                NormalizedUserName = "PATIENT19@EXAMPLE.COM",
                Email = "patient19@example.com",
                NormalizedEmail = "PATIENT19@EXAMPLE.COM",
                EmailConfirmed = true,


            });


            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                UserName = "patient20@example.com",
                NormalizedUserName = "PATIENT20@EXAMPLE.COM",
                Email = "patient20@example.com",
                NormalizedEmail = "PATIENT20@EXAMPLE.COM",
                EmailConfirmed = true,


            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                UserName = "patient21@example.com",
                NormalizedUserName = "PATIENT21@EXAMPLE.COM",
                Email = "patient21@example.com",
                NormalizedEmail = "PATIENT21@EXAMPLE.COM",
                EmailConfirmed = true,


            });
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                UserName = "patient22@example.com",
                NormalizedUserName = "PATIENT22@EXAMPLE.COM",
                Email = "patient22@example.com",
                NormalizedEmail = "PATIENT22@EXAMPLE.COM",
                EmailConfirmed = true,


            });
            #endregion ApplicationUser


            #region Patient 
           
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 1,
                Nom = "Côté",
                Prenom = "Sophie",
                Genre = "Male",
                NAM = "NAM01",
                CodePostal = "U4O 0G3",
                DateDeNaissance = new DateTime(1959, 6, 26),
                Age = 65,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df223"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 2,
                Nom = "Gagnon",
                Prenom = "Sophie",
                Genre = "Female",
                NAM = "NAM02",
                CodePostal = "T8D 6T5",
                DateDeNaissance = new DateTime(1962, 5, 2),
                Age = 62,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 3,
                Nom = "Gagné",
                Prenom = "Louis",
                Genre = "Female",
                NAM = "NAM03",
                CodePostal = "L9A 3Z3",
                DateDeNaissance = new DateTime(1982, 7, 26),
                Age = 42,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 4,
                Nom = "Morin",
                Prenom = "Sophie",
                Genre = "Female",
                NAM = "NAM04",
                CodePostal = "H1R 9L8",
                DateDeNaissance = new DateTime(1965, 2, 4),
                Age = 59,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g4"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 5,
                Nom = "Tremblay",
                Prenom = "Anne",
                Genre = "Male",
                NAM = "NAM05",
                CodePostal = "V9S 1N2",
                DateDeNaissance = new DateTime(1971, 4, 29),
                Age = 53,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g5"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 6,
                Nom = "Lavoie",
                Prenom = "Jean",
                Genre = "Male",
                NAM = "NAM06",
                CodePostal = "C1U 7Y0",
                DateDeNaissance = new DateTime(1996, 2, 27),
                Age = 28,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df226"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 7,
                Nom = "Gagnon",
                Prenom = "André",
                Genre = "Male",
                NAM = "NAM07",
                CodePostal = "T5E 4Z2",
                DateDeNaissance = new DateTime(1991, 9, 19),
                Age = 33,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7"
            });

           
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 8,
                Nom = "Gauthier",
                Prenom = "Jean",
                Genre = "Female",
                NAM = "NAM08",
                CodePostal = "E9C 8W3",
                DateDeNaissance = new DateTime(1982, 10, 26),
                Age = 42,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38"
            });

       
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 9,
                Nom = "Roy",
                Prenom = "Sophie",
                Genre = "Male",
                NAM = "NAM09",
                CodePostal = "H4Z 0C5",
                DateDeNaissance = new DateTime(1995, 5, 5),
                Age = 29,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g9"
            });

            
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 10,
                Nom = "Gagnon",
                Prenom = "Julie",
                Genre = "Female",
                NAM = "NAM10",
                CodePostal = "D2R 4Q3",
                DateDeNaissance = new DateTime(1950, 9, 5),
                Age = 74,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g410"
            });

            
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 11,
                Nom = "Bouchard",
                Prenom = "Martin",
                Genre = "Male",
                NAM = "NAM11",
                CodePostal = "F1G 2H4",
                DateDeNaissance = new DateTime(1978, 3, 21),
                Age = 46,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df211"
            });

          
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 12,
                Nom = "Côté",
                Prenom = "Anne",
                Genre = "Female",
                NAM = "NAM12",
                CodePostal = "J3K 5L8",
                DateDeNaissance = new DateTime(1988, 7, 15),
                Age = 36,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d212"
            });

         
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 13,
                Nom = "Fortin",
                Prenom = "Julie",
                Genre = "Female",
                NAM = "NAM13",
                CodePostal = "K2L 6M8",
                DateDeNaissance = new DateTime(1992, 11, 30),
                Age = 32,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313"
            });

            
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 14,
                Nom = "Fortin",
                Prenom = "Martin",
                Genre = "Female",
                NAM = "NAM14",
                CodePostal = "X8F 4I7",
                DateDeNaissance = new DateTime(1994, 5, 29),
                Age = 30,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g414"
            });

         
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 15,
                Nom = "Morin",
                Prenom = "Claire",
                Genre = "Male",
                NAM = "NAM15",
                CodePostal = "S9K 3Z3",
                DateDeNaissance = new DateTime(1985, 4, 15),
                Age = 39,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g415"
            });

          
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 16,
                Nom = "Roy",
                Prenom = "Claire",
                Genre = "Male",
                NAM = "NAM16",
                CodePostal = "H3N 3Z8",
                DateDeNaissance = new DateTime(1985, 1, 8),
                Age = 39,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df216"
            });

            
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 17,
                Nom = "Gauthier",
                Prenom = "Louis",
                Genre = "Female",
                NAM = "NAM17",
                CodePostal = "M1F 6Z2",
                DateDeNaissance = new DateTime(1958, 11, 26),
                Age = 66,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d217"
            });

           
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 18,
                Nom = "Côté",
                Prenom = "Marie",
                Genre = "Male",
                NAM = "NAM18",
                CodePostal = "G3W 7Q1",
                DateDeNaissance = new DateTime(1950, 7, 29),
                Age = 74,
                UserId = "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318"
            });

          
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 19,
                Nom = "Morin",
                Prenom = "Michel",
                Genre = "Male",
                NAM = "NAM19",
                CodePostal = "D1D 3D9",
                DateDeNaissance = new DateTime(1975, 5, 24),
                Age = 49,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g419"
            });

            
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 20,
                Nom = "Roy",
                Prenom = "Martin",
                Genre = "Male",
                NAM = "NAM20",
                CodePostal = "M4F 2S8",
                DateDeNaissance = new DateTime(1955, 10, 2),
                Age = 69,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g420"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 21,
                Nom = "Roy",
                Prenom = "Matheo",
                Genre = "Male",
                NAM = "NAM20",
                CodePostal = "M4F 2S8",
                DateDeNaissance = new DateTime(1954, 10, 2),
                Age = 70,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g421"
            });



            #endregion Patient
            #region Consultation
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 1,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(00),
                HeureDateFinPrevue= DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 1,
                PatientID = 1,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 2,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 1,
                PatientID = 2,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 3,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 2,
                PatientID = 3,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 4,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 2,
                PatientID = 4,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 5,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 3,
                PatientID = 5,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 6,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 3,
                PatientID = 6,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 7,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 4,
                PatientID = 7,
            });

                builder.Entity<Consultation>().HasData(new Consultation()
                {
                ConsultationID = 8,
                    HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                    HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                    StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 4,
                PatientID = 8,
            });
            
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 9,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 5,
                PatientID = 9,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 10,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 6,
                PatientID = 10,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 11,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 7,
                PatientID = 11,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 12,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 7,
                PatientID = 12,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 13,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 8,
                PatientID = 13,
            });


            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 14,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 8,
                PatientID = 14,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 15,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 9,
                PatientID = 15,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 16,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 9,
                PatientID = 16,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 17,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 10,
                PatientID = 17,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 18,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 10,
                PatientID = 18,
            });

                builder.Entity<Consultation>().HasData(new Consultation()
                {
                ConsultationID = 19,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                    StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 11,
                PatientID = 19,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 20,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 11,
                PatientID = 20,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 21,
                HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 12,
                PatientID = 21,
            });


            #endregion Consultation

       
        }
    }
}
