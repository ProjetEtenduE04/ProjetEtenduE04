using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinique2000_MVC.Controllers
{
    public class ListeAttenteController : Controller
    {
        // GET: ListeAttenteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListeAttenteController/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: ListeAttenteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListeAttenteController/Create
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

        // GET: ListeAttenteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListeAttenteController/Edit/5
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

        // GET: ListeAttenteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListeAttenteController/Delete/5
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
