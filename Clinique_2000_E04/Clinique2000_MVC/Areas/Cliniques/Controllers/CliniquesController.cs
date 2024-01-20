using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Clinique2000_MVC.Areas.Cliniques.Controllers
{
    [Area("Cliniques")]
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
            if (id == null || _services.clinique.ObtenirToutAsync() == null)
            {
                return NotFound();
            }

            var clinique = await _services.clinique.ObtenirParIdAsync(id);

            if (clinique == null)
            {
                return NotFound();
            }

            return View(clinique);
        }

        // GET: Cliniques/Create
        //[Authorize]
        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                string courrielUserAuth = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(courrielUserAuth);

                var cliniqueModel = new CliniqueAdresseVM() { 
                    Clinique = new Clinique() 
                    { 
                        CreateurID = user.Id} 
                    };

                    return View(cliniqueModel);
            }

            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _services.clinique.ObtenirToutAsync() == null)
            {
                return NotFound();
            }
            var clinique = await _services.clinique.ObtenirParIdAsync(id);
            var adreesseClinique = await _services.adresse.ObtenirParIdAsync(clinique.AdresseID);

            var cliniqueAdresseVM = new CliniqueAdresseVM()
            {
                Clinique = clinique,
                Adresse = adreesseClinique
            };

            if (clinique == null)
            {
                return NotFound();
            }

            return View(cliniqueAdresseVM);
        }

        // POST: Cliniques/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CliniqueAdresseVM cliniqueAdresseVM)
        {
            if (id != cliniqueAdresseVM.Clinique.CliniqueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _services.adresse.EditerAsync(cliniqueAdresseVM.Adresse);
                    await _services.clinique.EditerAsync(cliniqueAdresseVM.Clinique);


                }
                catch (DbUpdateConcurrencyException)
                {
                    var cliniqueExiste = _services.clinique.ObtenirParIdAsync(cliniqueAdresseVM.Clinique.CliniqueID);
                    if (cliniqueExiste==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Cliniques", new { id = cliniqueAdresseVM.Clinique.CliniqueID });
            }

            return View(cliniqueAdresseVM.Clinique);
        }

        // GET: Cliniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _services.clinique.ObtenirToutAsync() == null)
            {
                return NotFound();
            }

            var cliniqueASupprimer = await _services.clinique.ObtenirParIdAsync(id);
            if (cliniqueASupprimer == null)
            {
                return NotFound();
            }

            return View(cliniqueASupprimer);
        }

        // POST: Cliniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_services.clinique.ObtenirToutAsync() == null)
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
    }
}
