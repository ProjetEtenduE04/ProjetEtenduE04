using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_MVC.Areas.Clinique.Controllers
{
    [Area("Clinique")]

    public class CliniqueController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public CliniqueController(IClinique2000Services service)
        {
            _services = service;
        }
        // GET: CliniqueController
        public async Task<IActionResult> Index()
        {
            //return View(); 
            var listeClinique = await _services.clinique.ObtenirToutAsync();

            return View("Index", listeClinique);
        }

        // GET: CliniqueController/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || await _services.clinique.ObtenirToutAsync() == null)
            {
                return NotFound();
            }
            var cliniqueDetail = await _services.clinique.ObtenirParIdAsync(id);
            if (cliniqueDetail == null)
            {
                return NotFound();
            }
            return View(cliniqueDetail);
        }

        // GET: CliniqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CliniqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CliniqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CliniqueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CliniqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CliniqueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
