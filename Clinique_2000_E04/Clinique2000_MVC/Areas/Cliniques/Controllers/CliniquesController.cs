using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_MVC.Areas.Cliniques.Controllers
{
    public class CliniquesController : Controller
    {
        private readonly CliniqueDbContext _context;

        public CliniquesController(CliniqueDbContext context)
        {
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
        public IActionResult Create()
        {
            ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal");
            return View();
        }

        // POST: Cliniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CliniqueID,NomClinique,Courriel,HeureOuverture,HeureFermeture,TempsMoyenConsultation,EstActive,AdresseID")] Clinique clinique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseID"] = new SelectList(_context.Adresses, "AdresseID", "CodePostal", clinique.AdresseID);
            return View(clinique);
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
