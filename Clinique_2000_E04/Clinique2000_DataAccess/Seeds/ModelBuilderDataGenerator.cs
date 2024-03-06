
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Clinique2000_Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using Clinique2000_Utility.Enum;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

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
                    Rue = "Rue De la Gauchetiére",
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
                 HeureFermeture = new TimeSpan(15, 0, 0),
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
                 EstActive = false,
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
                 EstActive = false,
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
                 EstActive = false,
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
                CliniqueID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(1),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(14, 0, 0),
                NbMedecinsDispo = 2,
                
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
                
            });

            // Generate 6 ListeAttente objects for Clinique with CliniqueID 4
            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 7,
                CliniqueID = 2,
                IsOuverte = true,
                DateEffectivite = DateTime.Now.AddDays(2),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                
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
                
            });

            builder.Entity<ListeAttente>().HasData(new ListeAttente()
            {
                ListeAttenteID = 15,
                CliniqueID = 1,
                IsOuverte = false,
                DateEffectivite = DateTime.Now.AddDays(3),
                HeureOuverture = new TimeSpan(8, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 2,
                
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

            //builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            //{
            //    PlageHoraireID = 12,
            //    HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
            //    HeureFin = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
            //    ListeAttenteID = 1,
            //});

            //builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            //{
            //    PlageHoraireID = 13,
            //    HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
            //    HeureFin = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(30),
            //    ListeAttenteID = 1,
            //});

            //builder.Entity<PlageHoraire>().HasData(new PlageHoraire()
            //{
            //    PlageHoraireID = 14,
            //    HeureDebut = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(30),
            //    HeureFin = DateTime.Now.AddDays(1).Date.AddHours(15).AddMinutes(00),
            //    ListeAttenteID = 1,
            //});

           
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
                Genre = "Féminin",
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
                Genre = "Féminin",
                NAM = "PORT 3443 3433",
                CodePostal = "J4J 1H6",
                DateDeNaissance = new DateTime(1980, 8, 8),
                Age = 44,
                UserId = "g4d0a589-2b02-4d36-9a85-39c028a4g4g4"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 5,
                Nom = "Tremblay",
                Prenom = "Anne",
                Genre = "Male",
                NAM = "TREA 1234 4569",
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
                NAM = "LAVJ 1234 4570",
                CodePostal = "C1U 7Y0",
                DateDeNaissance = new DateTime(1996, 2, 27),
                Age = 28,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df226"
            });

            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 7,
                Nom = "Gagnon",
                Prenom = "Andrew",
                Genre = "Male",
                NAM = "GAGA 1234 4571",
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
                NAM = "GAUJ 1234 4572",
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
                NAM = "ROYS 1234 4573",
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
                NAM = "GAGJ 1234 4574",
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
                NAM = "BOUM 1234 4575",
                CodePostal = "F1G 2H4",
                DateDeNaissance = new DateTime(1978, 3, 21),
                Age = 46,
                UserId = "7cc96785-8933-4eac-8d7f-a289b28df211"
            });

          
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 12,
                Nom = "Couto",
                Prenom = "Anne",
                Genre = "Female",
                NAM = "COUA 1234 4576",
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
                NAM = "FORJ 1234 4577",
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
                NAM = "FORM 1234 4578",
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
                NAM = "MORC 1234 4579",
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
                NAM = "ROYC 1234 4580",
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
                NAM = "GAUL 1234 4581",
                CodePostal = "M1F 6Z2",
                DateDeNaissance = new DateTime(1958, 11, 26),
                Age = 66,
                UserId = "e2b8f367-6c94-4a3e-b5a6-45dabec4d217"
            });

           
            builder.Entity<Patient>().HasData(new Patient()
            {
                PatientId = 18,
                Nom = "Couto",
                Prenom = "Marie",
                Genre = "Male",
                NAM = "COUM 1234 4582",
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
                NAM = "MORM 1234 4583",
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
                NAM = "ROYM 1234 4584",
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
                NAM = "ROYM 1234 4585",
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
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(00),
                //HeureDateFinPrevue= DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 1,
                PatientID = 1,
                
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 2,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 1,
                PatientID = 2,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 3,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 2,
                PatientID = 3,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 4,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(8).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 2,
                PatientID = 4,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 5,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 3,
                PatientID = 5,
            });
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 6,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 3,
                PatientID = 6,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 7,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 4,
                PatientID = 7,
            });

                builder.Entity<Consultation>().HasData(new Consultation()
                {
                ConsultationID = 8,
                    //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(9).AddMinutes(30),
                    //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                    StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 4,
                PatientID = 8,
            });
            
            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 9,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 5,
                PatientID = 9,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 10,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 5,
                PatientID = 10,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 11,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                StatutConsultation = StatutConsultation.EnAttente,
                PlageHoraireID = 6,
                PatientID = 11,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 12,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(10).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 6,
                //PatientID = 12,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 13,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 7,
                //PatientID = 13,
            });


            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 14,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(11).AddMinutes(30),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 7,
                //PatientID = 14,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 15,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 8,
                //PatientID = 15,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 16,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 8,
                //PatientID = 16,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 17,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 9,
                //PatientID = 17,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 18,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(12).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 9,
               /* PatientID = 18,*/
            });

                builder.Entity<Consultation>().HasData(new Consultation()
                {
                ConsultationID = 19,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                    StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 10,
                //PatientID = 19,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 20,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(00),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 10,
                //PatientID = 20,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 21,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 11,
                //PatientID = 21,
            });

            builder.Entity<Consultation>().HasData(new Consultation()
            {
                ConsultationID = 22,
                //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(13).AddMinutes(30),
                //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
                StatutConsultation = StatutConsultation.DisponiblePourReservation,
                PlageHoraireID = 11,

            });
            //builder.Entity<Consultation>().HasData(new Consultation()
            //{
            //    ConsultationID = 23,
            //    //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
            //    //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(30),
            //    StatutConsultation = StatutConsultation.DisponiblePourReservation,
            //    PlageHoraireID = 12,

            //});

            //builder.Entity<Consultation>().HasData(new Consultation()
            //{
            //    ConsultationID = 24,
            //    //HeureDateDebutPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(00),
            //    //HeureDateFinPrevue = DateTime.Now.AddDays(1).Date.AddHours(14).AddMinutes(30),
            //    StatutConsultation = StatutConsultation.DisponiblePourReservation,
            //    PlageHoraireID = 12,

            //});
            #endregion Consultation

            #region EmployesClinique
            builder.Entity<EmployesClinique>().HasData(new EmployesClinique()
            {
                EmployeCliniqueID = 1,
                EmployeCliniqueNom = "Tremblay",
                EmployeCliniquePrenom = "Mark",
                EmployeCliniqueCourriel = "numcliniquetest@gmail.com",
                EmployeCliniquePosition  = EmployeCliniquePosition.Medecin,
                CliniqueID = 1,

            }) ;

            builder.Entity<EmployesClinique>().HasData(new EmployesClinique()
            {
                EmployeCliniqueID = 2,
                EmployeCliniqueNom = "Dubois",
                EmployeCliniquePrenom = "Monique",
                EmployeCliniqueCourriel = "testproject2132@gmail.com",
                EmployeCliniquePosition = EmployeCliniquePosition.Medecin,
                CliniqueID = 1,

            });

            builder.Entity<EmployesClinique>().HasData(new EmployesClinique()
            {
                EmployeCliniqueID = 3,
                EmployeCliniqueNom = "Beton",
                EmployeCliniquePrenom = "Sylvie",
                EmployeCliniqueCourriel = "sylviebeton98@gmail.com",
                EmployeCliniquePosition = EmployeCliniquePosition.Receptionniste,
                CliniqueID = 1,

            });
            builder.Entity<EmployesClinique>().HasData(new EmployesClinique()
            {
                EmployeCliniqueID = 4,
                EmployeCliniqueNom = "Bostan",
                EmployeCliniquePrenom = "Max",
                EmployeCliniqueCourriel = "clinique597@gmail.com",
                EmployeCliniquePosition = EmployeCliniquePosition.Receptionniste,
                CliniqueID = 1,

            });


            #endregion
        }
    }
}
