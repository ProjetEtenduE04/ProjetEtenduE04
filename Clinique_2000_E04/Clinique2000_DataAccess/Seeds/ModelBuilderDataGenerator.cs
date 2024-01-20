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
            #region Adresse 
            builder.Entity<Adresse>().HasData(
               new Adresse()
               {
                   AdresseID = 1,
                   Rue = "123 Main Street",
                   Ville = "Montreal",
                   Province = "Quebec",
                   Pays = "Canada",
                   CodePostal = "H2X 1Y6"
               },
                    new Adresse()
                    {
                        AdresseID = 2,
                        Rue = "Rue ABC",
                        Ville = "Brossard",
                        Province = "Quebec",
                        Pays = "Canada",
                        CodePostal = "J3Y 1Y5"
                    }
            );
            #endregion

            #region Clinique 
            builder.Entity<Clinique>().HasData(
               new Clinique()
               {
                   CliniqueID = 1,
                   NomClinique = "Ma Clinique Générale",
                   Courriel = "anieewon@gmail.com",
                   HeureOuverture = new TimeSpan(8, 0, 0),
                   HeureFermeture = new TimeSpan(18, 0, 0),
                   TempsMoyenConsultation = 30,
                   EstActive = true,
                   AdresseID = 1
               },
                new Clinique()
                {
                    CliniqueID = 2,
                    NomClinique = "Apple CLinique",
                    Courriel = "nguyenhonganh.hn29@gmail.com",
                    HeureOuverture = new TimeSpan(9, 0, 0),
                    HeureFermeture = new TimeSpan(17, 0, 0),
                    TempsMoyenConsultation = 45,
                    EstActive = false,
                    AdresseID = 2
                }
            );
            #endregion
        }
    }
}