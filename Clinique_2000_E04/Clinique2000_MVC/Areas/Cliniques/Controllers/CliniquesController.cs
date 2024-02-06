using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Clinique2000_Utility.Constants;
using Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;



namespace Clinique2000_MVC.Areas.Cliniques.Controllers
{
    [Area("Cliniques")]
    [Authorize]
    public class CliniquesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IClinique2000Services _services { get; set; }

        public CliniquesController(
            IClinique2000Services service,
            UserManager<IdentityUser> userManager
            )
        {
            _services = service;
            _userManager = userManager;
        }

        // GET: Cliniques
        public async Task<IActionResult> Index()
        {
            var listeDesCliniques = await _services.clinique.ObtenirToutAsync();
            return View(listeDesCliniques);
        }

        // GET: Cliniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _services.clinique.ObtenirToutAsync() == null)
            {
                TempData[AppConstants.Warning] = $"Désolé, mais la clinique n'a pas été trouvée dans notre base de données.";
                return View("NotFound");
            }

            var clinique = await _services.clinique.ObtenirParIdAsync(id);

            if (clinique == null)
            {
                TempData[AppConstants.Warning] = $"Désolé, mais la clinique n'a pas été trouvée dans notre base de données.";
                return View("NotFound");
            }

            return View(clinique);
        }

        // GET: Cliniques/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            string courrielUserAuth = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(courrielUserAuth);

            var cliniqueModel = new CliniqueAdresseVM() 
            { 
                Clinique = new Clinique() 
                { 
                    CreateurID = user.Id
                } 
            };

            return View(cliniqueModel);
        }

        // POST: Cliniques/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CliniqueAdresseVM viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cliniqueEnregistre = await _services.clinique.EnregistrerCliniqueAsync(viewModel);

                    TempData[AppConstants.Success] = $"Vous avez enregistré avec succès la clinique  {cliniqueEnregistre.NomClinique}";

                    return RedirectToAction("Details", "Cliniques", new { id = cliniqueEnregistre.CliniqueID });
                }

                TempData[AppConstants.Error] = $"Les champs obligatoires n'ont pas été remplis correctement";
                
                return View(viewModel);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur : {ex.Message}";

                return View(viewModel);
            }
        }

        // GET: Cliniques/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!await _services.clinique.VerifierExistenceCliniqueParIdAsync(id))
                {
                    return View("NotFound");
                }
                var clinique = await _services.clinique.ObtenirParIdAsync(id);

                if (clinique == null)
                {
                    TempData[AppConstants.Warning] = $"Désolé, mais la clinique n'a pas été trouvée dans notre base de données.";
                    return View("NotFound");
                }

                var adreesseClinique = await _services.adresse.ObtenirParIdAsync(clinique.AdresseID);

                var cliniqueAdresseVM = new CliniqueAdresseVM()
                {
                    Clinique = clinique,
                    Adresse = adreesseClinique
                };
                return View(cliniqueAdresseVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur : {ex.Message}";

                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Cliniques/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CliniqueAdresseVM cliniqueAdresseVM)
        {
            if (id != cliniqueAdresseVM.Clinique.CliniqueID)
            {
                return View("NotFound");
            }
            try
            {
                if (ModelState.IsValid)
                { 
                    await _services.clinique.EditerCliniqueAsync(cliniqueAdresseVM);

                    TempData[AppConstants.Success] = $"Les données de la clinique {cliniqueAdresseVM.Clinique.NomClinique} ont été modifiées avec succès";

                    return RedirectToAction("Details", "Cliniques", new { id = cliniqueAdresseVM.Clinique.CliniqueID });
                }

                TempData[AppConstants.Error] = $"Les champs obligatoires n'ont pas été remplis correctement";
                return View(cliniqueAdresseVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur {ex.Message}";

                return View(cliniqueAdresseVM);
            }
        }

        // GET: Cliniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || await _services.clinique.ObtenirToutAsync() == null)
                {
                    TempData[AppConstants.Warning] = $"Désolé, mais la clinique n'a pas été trouvée dans notre base de données.";
                    return View("NotFound");
                }

                var cliniqueASupprimer = await _services.clinique.ObtenirParIdAsync(id);
                if (cliniqueASupprimer == null)
                {
                    TempData[AppConstants.Warning] = $"Désolé, mais la clinique n'a pas été trouvée dans notre base de données.";
                    return View("NotFound");
                } 

                TempData[AppConstants.Warning] = $"Vous êtes sûr de vouloir supprimer cette clinique?";
                return View(cliniqueASupprimer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur : {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Cliniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (await _services.clinique.ObtenirToutAsync() == null)
                {
                    TempData[AppConstants.Error] = $"L'ensemble d'entités 'ApplicationDbContext.Cliniques' est nul.";
                    return Problem("Error");
                }
                var clinique = await _services.clinique.ObtenirParIdAsync(id);
                if(clinique != null)
                {
                    await _services.clinique.SupprimerAsync(id);
                    TempData[AppConstants.Success] = $"Le dossier de la clinique {clinique.NomClinique} a été supprimé avec succès.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur : {ex.Message}";
                return RedirectToAction(nameof(Index));

            }          
        }

        public async Task<IActionResult> IndexCliniquesAProximite()
        {
            bool userEstPatient = await _services.patient.UserAuthEstPatientAsync();
            if (!userEstPatient)
            {
                TempData[AppConstants.Info] = $"Vous devez être un patient pour accéder à cette page.";
                return RedirectToAction("Create", "Patients", new { area = "Patients" });
            }
            List<Clinique> allClinics = await _services.clinique.ObtenirToutAsync();

            if (allClinics == null)
            {
                return View("IndexCliniquesAProximite");
            }

            IEnumerable<CliniqueDistanceVM> activeClinics = await _services.clinique.ObtenirLes5CliniquesLesPlusProches();

            if(activeClinics.Count() > 0)
                TempData[AppConstants.Info] = $"Voici les cliniques les plus proches de chez vous avec des rendez-vous disponibles ";
            else
                TempData[AppConstants.Info] = $"Malheureusement, il n'y a pas de clinique RDV disponible pour le moment.";

            return View("IndexCliniquesAProximite", activeClinics);
        }


        public async Task<IActionResult> ListeAttentePourPatient(int clinicId, bool? isOuvert)
        {
            IList<ListeAttente> listeAttentePourPatient = await _services.clinique.GetListeAttentePourPatientAsync(clinicId, isOuvert);


            string clinicName =_services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

            ViewBag.CliniqueName = clinicName;

            return View("ListeAttentePourPatient", listeAttentePourPatient);
        }


        public async Task<IActionResult> ConsultationPourMedecine()
        {
            return View();

        }
    }
}

       