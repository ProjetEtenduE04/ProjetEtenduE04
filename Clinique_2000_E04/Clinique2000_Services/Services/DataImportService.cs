using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class DataImportService:IdataImportService
{
    private readonly CliniqueDbContext _context;

    public DataImportService(CliniqueDbContext context)
    {
        _context = context;
    }

public async Task ImporterDonneesDuFichierCSVasync(string filePath)
{
    var adresses = await LireFichierCSVasync(filePath);
    // Use BulkInsert to insert all addresses at once
    _context.BulkInsert(adresses);
}

    private async Task<List<AdressesQuebecVM>> LireFichierCSVasync(string filePath)
    {
        var adresses = new List<AdressesQuebecVM>();
        using (var reader = new StreamReader(filePath))
        {
            string line;
            await reader.ReadLineAsync(); // Skip the header line
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var values = line.Split(',');
                if (values.Length >= 6)
                {
                    var adresse = new AdressesQuebecVM
                    {
                        PostalCode = values[0],
                        City = values[1],
                        ProvinceAbbr = values[2],
                        TimeZone = int.Parse(values[3], CultureInfo.InvariantCulture),
                        Latitude = double.Parse(values[4], CultureInfo.InvariantCulture),
                        Longitude = double.Parse(values[5], CultureInfo.InvariantCulture)
                    };
                    adresses.Add(adresse);
                }
            }
        }
        return adresses;
    }

    public async Task<bool> ShouldImportDataAsync()
    {
        return !await _context.AdressesQuebec.AnyAsync();
    }
}

