using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Clinique2000_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize/*(Roles = "Admin")*/]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IClinique2000Services _services { get; set; }

        public AdminController(
            IClinique2000Services service,
            UserManager<IdentityUser> userManager
        )
        {
            _services = service;
            _userManager = userManager;
        }

        /// <summary>
        /// Présentement une vue vide
        /// TODO: Ajouter un dashboard?
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Approbation(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ApprobationVM approbationVM = new ApprobationVM
            {
                Param = id
            };

            if (id == "clinique")
            {
                approbationVM.ApprobationCliniquesVM = new ApprobationCliniquesVM
                {
                    Cliniques = await _services.admin.ApprobationCliniqueListe()
                };
                return View(approbationVM);
            }
            if (id == "utilisateur")
            {
                approbationVM.ApprobationUtilisateursVM = new ApprobationUtilisateursVM
                {
                    Utilisateurs = await _services.admin.ApprobationUtilisateurListe()
                };
                return View(approbationVM);
            }
            if (id == "cliniquesrefusees")
            {
                approbationVM.ApprobationCliniquesRefuseesVM = new ApprobationCliniquesRefuseesVM
                {
                    CliniquesRefusees = await _services.admin.ListeCliniquesRefusees()
                };
                return View(approbationVM);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Approbation(ApprobationVM approbationVM)
        {
            ;
            if (ModelState.IsValid)
            {
                if (approbationVM.Param == "clinique")
                {
                    await _services.admin.ApprobationCliniqueListe();
                }
            }

            return RedirectToAction(nameof(Approbation));
        }

        [HttpGet]
        public async Task<IActionResult> ApprobationClinique(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Approbation", "Admin");
            }

            await _services.admin.ApprobationCliniqueParID(id);

            return RedirectToAction("Approbation", new { id = "clinique" });
        }

        [HttpGet]
        public async Task<IActionResult> RefuserClinique(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Approbation", "Admin");
            }

            await _services.admin.RefuserCliniqueParID(id);

            return RedirectToAction("Approbation", new { id = "clinique" });
        }

        [HttpGet]
        public async Task<IActionResult> ApprobationUtilisateur(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Approbation", "Admin");
            }

            await _services.admin.ApprobationUtilisateurParID(id);

            return RedirectToAction("Approbation", new { id = "utilisateur" });
        }

        [HttpGet]
        public async Task<IActionResult> RefuserUtilisateur(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Approbation", "Admin");
            }

            await _services.admin.RefuserUtilisateurParID(id);

            return RedirectToAction("Approbation", new { id = "utilisateur" });
        }

        [HttpGet]
        public ActionResult DownloadDatabaseBackup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadDatabaseBackupPOT()
        {
            try
            {
                var backupFilePath = _services.backup.GenerateDatabaseBackupScript();

                if (!string.IsNullOrEmpty(backupFilePath))
                {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(backupFilePath);
                    return File(fileBytes, "application/sql", Path.GetFileName(backupFilePath));
                }
                else
                {
                    return NotFound("Backup file not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        public async Task<IActionResult> ExportDataAsyncGet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ExportDataAsyncPOST()
        {
            // Define the list of table names based on your classes/DB schema
            var tableNames = new List<string> {
            "Adresse",
            "AdressesQuebec",
            "ApplicationUser", // Note: ApplicationUser might not directly map to a table if it's part of Identity Framework.
            "Clinique",
            "Consultation",
            "Critique",
            "DetailsConsultation",
            "EmployesClinique",
            "ListeAttente",
            "Patient",
            "PatientACharge",
            "Personne", // Note: Personne being an abstract class may not have a direct table unless implemented by derived classes.
            "PlageHoraire"
            // Ensure the table names here match exactly with those in your database.
             };

            foreach (var tableName in tableNames)
            {
                string exportFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exports", $"{tableName}.csv");

                string bcpCommand = _services.backup.GenerateExportCommand(tableName, exportFilePath);

                // Execute the BCP command
                ExecuteBcpCommand(bcpCommand);
            }

            return View("ExportSuccessful"); // Ensure you have a view named "ExportSuccessful" to notify the user of completion.
        }

        private void ExecuteBcpCommand(string command)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (System.Diagnostics.Process proc = new System.Diagnostics.Process { StartInfo = procStartInfo })
            {
                proc.Start();
                // Consider adding logging or error handling here to capture command execution status
            }
        }
    }
}

