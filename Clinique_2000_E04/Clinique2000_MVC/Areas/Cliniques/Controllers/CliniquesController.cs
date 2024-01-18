using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Google;
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
        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                string courriel = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(courriel);

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
        public IActionResult Create(CliniqueAdresseVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var clinique = viewModel.Clinique;
                var adresse = viewModel.Adresse;

                _context.Adresses.Add(adresse);
                _context.SaveChanges();

                clinique.AdresseID = adresse.AdresseID;
                clinique.Adresse = adresse;
                _context.Cliniques.Add(clinique);
                ;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
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
            if (clinique == null)
            {
                return NotFound();
            }
            ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal", clinique.AdresseID);
            return View(clinique);
        }

        // POST: Cliniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CliniqueID,NomClinique,Courriel,HeureOuverture,HeureFermeture,TempsMoyenConsultation,EstActive,AdresseID")] Clinique clinique)
        {
            if (id != clinique.CliniqueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CliniqueExists(clinique.CliniqueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal", clinique.AdresseID);
            return View(clinique);
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
