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
                  TempsMoyenConsultation = 30
               }
               );

            #endregion

        }
    }
}

