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
using System.Globalization;
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
            
            var userAuth = await _services.patient.GetUserAuthAsync();

            // Vérifier si l'utilisateur est un superadministrateur
            if (User.IsInRole(AppConstants.SuperAdminRole))
            {
                // L'utilisateur est un superadministrateur, il peut donc voir toutes les cliniques
                var employesClinique = await _services.clinique.ObtenirToutAsync();
                return View(employesClinique);
            }
            //Vérifier si l'utilisateur est le créateur d'une clinique
            if (User.IsInRole(AppConstants.AdminCliniqueRole))
            {
                // L'utilisateur est le créateur d'une clinique, il ne peut donc voir que ses clinique.
                var listeCliniqueAdminClinique = await _services.clinique.ObtenirListeCliniquesParCreateurId(userAuth.Id);
                return View(listeCliniqueAdminClinique);
            }
            // Vérifier si l'utilisateur est l'employe d'une clinique 
            var employe = await _services.employesClinique.VerifierSiUserAuthEstEmploye(userAuth.Email);
            if (employe != null)
            {
                // L'utilisateur est l'employe d'une clinique, il ne peut donc voir que la clinique dans laquelle il travaille.
                var listCliniqueDeLEmployee = await _services.employesClinique.ObtenirCliniquesDeLEmploye(employe);
                return View(listCliniqueDeLEmployee);
            }
            //L'utilisateur n'est pas le créateur ou l'administrateur d'une clinique, nous redirigeons donc vers la page principale.
            TempData["ErrorMessage"] = "Accès refusé. Seuls les superadministrateurs, les créateurs de cliniques ou les administrateurs de cliniques sont autorisés à accéder à cette page.";
            return RedirectToAction("Index", "Home");
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
                    var user = await _services.patient.GetUserAuthAsync();
                    await _userManager.AddToRoleAsync(user, AppConstants.AdminCliniqueRole);
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
            ViewBag.PatientLatitude = activeClinics.FirstOrDefault()?.PatientLatitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.PatientLongitude = activeClinics.FirstOrDefault()?.PatientLongitude.ToString(CultureInfo.InvariantCulture);

            if (activeClinics.Count() > 0)
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

        //[Authorize(Roles = AppConstants.AdminCliniqueRole + "," + AppConstants.SuperAdminRole)]
        //public async Task<IActionResult> IndexAdministration()
        //{
        //    // Verificați dacă utilizatorul autentificat are unul dintre rolurile necesare
        //    if (User.IsInRole(AppConstants.AdminCliniqueRole) || User.IsInRole(AppConstants.SuperAdminRole))
        //    {
        //        // Obtenir l'ID de l'utilisateur connecté
        //        var userAuth = await _services.patient.GetUserAuthAsync();

        //        // Vérifier si l'utilisateur est un superadministrateur
        //        if (User.IsInRole(AppConstants.SuperAdminRole))
        //        {
        //            // L'utilisateur est un superadministrateur, il peut donc voir toutes les cliniques
        //            var employesClinique = await _services.clinique.ObtenirToutAsync();
        //            return View(employesClinique);
        //        }
        //        // Vérifier si l'utilisateur est le créateur d'une clinique
        //        var isCreator = await _services.clinique.VerifierSiUserAuthEstCreateurClinique(userAuth);
        //        if (isCreator)
        //        {
        //            // L'utilisateur est le créateur d'une clinique, il ne peut donc voir que sa clinique.
        //            //var clinique = await _services.clinique.ObtenirCliniqueParCreteurId(userAuth.Id);
        //            var listeCliniqueAdminClinique = await _services.clinique.ObtenirListeCliniquesParCreateurId(userAuth.Id);
        //            return View(listeCliniqueAdminClinique);
        //        }

        //        // Vérifier si l'utilisateur est l'employe d'une clinique 
        //        var estEmploye = await _services.employesClinique.VerifierSiUserAuthEstEmploye(userAuth.Email);
        //        if (estEmploye != null)
        //        {
        //            // L'utilisateur est l'employe d'une clinique, il ne peut donc voir que la clinique dans laquelle il travaille.
        //            var employeClinique = await _services.employesClinique.GetEmployeUserID(userId, null);
        //            var clinique = await _services.clinique.SelectionnerClinique(employeClinique.CliniqueID);
        //            var employesClinique = await _services.employesClinique.ObtenirCliniquesDeLEmploye(clinique);
        //            return View(employesClinique);
        //        }

        //        // Utilizatorul nu este creatorul sau administratorul unei clinici, deci redirectionăm la pagina principală
        //        TempData["ErrorMessage"] = "Accesul interzis. Doar superadminii, creatorii de clinici sau administratorii de clinici au permisiunea de a accesa această pagină.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // Utilizatorul nu are unul dintre rolurile necesare, deci redirectionăm la pagina principală și afișăm un mesaj de eroare
        //    TempData["ErrorMessage"] = "Accesul interzis. Doar superadminii și administratorii de clinici au permisiunea de a accesa această pagină.";
        //    return RedirectToAction("Index", "Home");
        //}


        public async Task<IActionResult> ConsultationPourMedecine()
        {
            return View();

        }

        [HttpGet]
        public IActionResult CreateCritique(int id)
        {
            var clinicName = _services.clinique.GetClinicNameById(id);
            ViewData["ClinicName"] = clinicName;

            ViewData["CliniqueID"] = id;

            return View();
        }

        [HttpPost]
        public IActionResult CreateCritique(Critique critique)
        {
            // Add validation logic
            if (ModelState.IsValid)
            {
                _services.clinique.CreerCritiqueAsync(critique);

                TempData[AppConstants.Success] = $"Merci infiniment d'avoir pris le temps d'écrire une critique, votre feedback est précieux pour nous!";

                return RedirectToAction("IndexCliniquesAProximite"); // Redirect to a different page after successful review submission
            }

            return View(critique); // Return the view with validation errors
        }
    }
}

       