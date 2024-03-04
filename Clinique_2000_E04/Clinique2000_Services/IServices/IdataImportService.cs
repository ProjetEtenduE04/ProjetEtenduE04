﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.IServices
{
    public interface IdataImportService
    {
        Task ImporterDonneesDuFichierCSVasync(string filePath);
        Task<bool> ShouldImportDataAsync();
    }
}
