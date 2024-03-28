using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Clinique2000_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Clinique2000_Utility.Constants;

namespace Clinique2000_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppConstants.SuperAdminRole)]
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


        /// <summary>
        /// Générer une sauvegarde de la base de données
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> BackupDatabase()
        {
            try
            {
                // Appel du service de sauvegarde
                await _services.backup.BackupDatabaseAsync();

                TempData[AppConstants.Success] = "La sauvegarde de la base de données a été effectuée avec succès!";

            }
            catch (Exception ex)
            {
                TempData[AppConstants.Error] = $"Erreur de sauvegarde : {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
