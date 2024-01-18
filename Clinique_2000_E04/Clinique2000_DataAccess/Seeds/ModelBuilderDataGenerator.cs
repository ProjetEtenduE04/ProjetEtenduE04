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
                   AdresseID = 1
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
                   AdresseID = 2
               }

            );

            #endregion
            #region Adresse 
            builder.Entity<Adresse>().HasData(
                new Adresse()
                {
                    AdresseID = 1,
                    Rue = "123 rue de la clinique",
                    Ville = "Montréal",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "H1H 1H1",
                },
                new Adresse()
                {
                    AdresseID = 2,
                    Rue = "777 rue de la Cegep",
                    Ville = "Longueuil",
                    Province = "Québec",
                    Pays = "Canada",
                    CodePostal = "A1A 1A1",
                }
            );

            #endregion
        }
    }
}
