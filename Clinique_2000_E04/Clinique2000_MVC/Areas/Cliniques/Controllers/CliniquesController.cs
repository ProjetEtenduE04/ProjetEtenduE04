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
        private readonly CliniqueDbContext _context;

        public CliniquesController(
            IClinique2000Services service,
            UserManager<IdentityUser> userManager,
            CliniqueDbContext context
            )
        {
            _services = service;
            _userManager = userManager;
            _context = context;
        }

        // GET: Cliniques
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cliniques.Include(c => c.Adresse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cliniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliniques == null)
            {
                return NotFound();
            }

            var clinique = await _context.Cliniques
                .Include(c => c.Adresse)
                .FirstOrDefaultAsync(m => m.CliniqueID == id);
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
                string courriel = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(courriel);

                var cliniqueModel = new CliniqueAdresseVM() { 
                    Clinique = new Clinique2000_Core.Models.Clinique() 
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
            if (id == null || _context.Cliniques == null)
            {
                return NotFound();
            }
            var clinique = await _context.Cliniques.FindAsync(id);
            var adreesseClinique = await _context.Adresses.FindAsync(clinique.AdresseID);
            var cliniqueAdresseVM = new CliniqueAdresseVM()
            {
                Clinique = clinique,
                Adresse = adreesseClinique
            };

            if (clinique == null)
            {
                return NotFound();
            }
            //ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal", clinique.AdresseID);
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
                    _context.Update(cliniqueAdresseVM.Adresse);
                    _context.Update(cliniqueAdresseVM.Clinique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CliniqueExists(cliniqueAdresseVM.Clinique.CliniqueID))
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
            //ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal", cliniqueAdresseVM.Clinique.AdresseID);
            return View(cliniqueAdresseVM.Clinique);
        }

        // GET: Cliniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliniques == null)
            {
                return NotFound();
            }

            var clinique = await _context.Cliniques
                .Include(c => c.Adresse)
                .FirstOrDefaultAsync(m => m.CliniqueID == id);
            if (clinique == null)
            {
                return NotFound();
            }

            return View(clinique);
        }

        // POST: Cliniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliniques == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cliniques'  is null.");
            }
            var clinique = await _context.Cliniques.FindAsync(id);
            if (clinique != null)
            {
                _context.Cliniques.Remove(clinique);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CliniqueExists(int id)
        {
            return (_context.Cliniques?.Any(e => e.CliniqueID == id)).GetValueOrDefault();
        }
    }
}
