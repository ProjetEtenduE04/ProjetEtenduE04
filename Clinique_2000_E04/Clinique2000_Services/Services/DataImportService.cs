﻿//using Clinique2000_Core.Models;
//using Clinique2000_DataAccess.Data;
//using Clinique2000_Services.IServices;
//using EFCore.BulkExtensions;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//public class DataImportService : IdataImportService
//{
//    private readonly CliniqueDbContext _context;

//    public DataImportService(CliniqueDbContext context)
//    {
//        _context = context;
//    }

//    public async Task ImporterDonneesDuFichierCSVasync(string filePath)
//    {
//        var adresses = await LireFichierCSVasync(filePath);
//        // Utilise la librairie Bulk pour inserer les adresses d'un seul coup
//        _context.BulkInsert(adresses);
//    }

//    public async Task<List<AdressesQuebec>> LireFichierCSVasync(string filePath)
//    {
//        var adresses = new List<AdressesQuebec>();
//        using (var reader = new StreamReader(filePath))
//        {
//            string line;
//            await reader.ReadLineAsync(); // Saute la premiere ligne
//            while ((line = await reader.ReadLineAsync()) != null)
//            {
//                var values = line.Split(',');
//                if (values.Length >= 6)
//                {
//                    var adresse = new AdressesQuebec
//                    {
//                        PostalCode = values[0],
//                        City = values[1],
//                        ProvinceAbbr = values[2],
//                        TimeZone = int.Parse(values[3], CultureInfo.InvariantCulture),
//                        Latitude = double.Parse(values[4], CultureInfo.InvariantCulture),
//                        Longitude = double.Parse(values[5], CultureInfo.InvariantCulture)
//                    };
//                    adresses.Add(adresse);
//                }
//            }
//        }
//        return adresses;
//    }

//    public async Task<bool> ShouldImportDataAsync()
//    {
//        return !await _context.AdressesQuebec.AnyAsync();
//    }
//}

