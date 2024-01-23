using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
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
                return View("NotFound");
            }

            var clinique = await _services.clinique.ObtenirParIdAsync(id);

            if (clinique == null)
            {
                return View("NotFound");
            }

            return View(clinique);
        }

        // GET: Cliniques/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //if (User.Identity.IsAuthenticated) //Utiliser temporairement, jusqu'à implémentation Role-based authorization
            //{
                string courrielUserAuth = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(courrielUserAuth);

                var cliniqueModel = new CliniqueAdresseVM() { 
                    Clinique = new Clinique() 
                    { 
                        CreateurID = user.Id} 
                    };

                    return View(cliniqueModel);
            //}

            //return RedirectToAction(nameof(Index));
        }

        // POST: Cliniques/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CliniqueAdresseVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var cliniqueEnregistre = await _services.clinique.EnregistrerCliniqueAsync(viewModel);

                return RedirectToAction("Details", "Cliniques", new { id = cliniqueEnregistre.CliniqueID });
            }

            return View(viewModel);
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
            catch
            {
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
                    return RedirectToAction("Details", "Cliniques", new { id = cliniqueAdresseVM.Clinique.CliniqueID });
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            return View(cliniqueAdresseVM);
        }

        // GET: Cliniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _services.clinique.ObtenirToutAsync() == null)
            {
                return View("NotFound");
            }

            var cliniqueASupprimer = await _services.clinique.ObtenirParIdAsync(id);
            if (cliniqueASupprimer == null)
            {
                return View("NotFound");
            }

            return View(cliniqueASupprimer);
        }

        // POST: Cliniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _services.clinique.ObtenirToutAsync() == null)
            {
                return Problem("L'ensemble d'entités 'ApplicationDbContext.Cliniques' est nul.");
            }
            await _services.clinique.SupprimerAsync(id);
            //var cliniqueASupprimer = await _services.clinique.ObtenirParIdAsync(id);
            //if (cliniqueASupprimer != null)
            //{

            //    _context.Cliniques.Remove(cliniqueASupprimer);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool CliniqueExists(int id)
        //{
        //    return (_context.Cliniques?.Any(e => e.CliniqueID == id)).GetValueOrDefault();
        //}


        public async Task<IActionResult> IndexPourPatients()
        {
            List<Clinique> allClinics = await _services.clinique.ObtenirToutAsync();

            if (allClinics == null)
            {
                return View("IndexPourPatients", Enumerable.Empty<Clinique>());
            }

            var activeClinics = allClinics.Where(clinic => clinic.EstActive).ToList();
            return View("IndexPourPatients", activeClinics);
        }


        public async Task<IActionResult> ListeAttentePourPatient(int clinicId, bool? isOuvert)
        {
            IList<ListeAttente> listeAttentePourPatient = await _services.clinique.GetListeAttentePourPatientAsync(clinicId, isOuvert);


            string clinicName = _services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

            ViewBag.CliniqueName = clinicName;

            return View("ListeAttentePourPatient", listeAttentePourPatient);
        }
    }
}

       