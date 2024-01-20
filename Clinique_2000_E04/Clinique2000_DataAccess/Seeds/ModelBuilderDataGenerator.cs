using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Clinique2000_Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clinique2000_DataAccess.Data
{
    public static class ModelBuilderDataGenerator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
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
                   CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df222",
                   
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
                   CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df222",
               }

            );

            #endregion
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
                }
            );

            #endregion
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "7cc96785-8933-4eac-8d7f-a289b28df223",
                    UserName = "bit@gmail.com",
                    NormalizedUserName = "BIT@GMAIL.COM",
                    Email = "bit@gmail.com",
                    NormalizedEmail = "BIT@GMAIL.COM",
                    EmailConfirmed = true,
                });
        }
    }
}
