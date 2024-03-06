using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
