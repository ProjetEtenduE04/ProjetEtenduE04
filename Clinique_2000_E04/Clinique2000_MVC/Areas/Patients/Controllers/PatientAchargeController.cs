using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Clinique2000_Utility.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Debugger.Contracts.HotReload;
using static Clinique2000_Services.Services.PatientService;

namespace Clinique2000_MVC.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientAchargeController : Controller
    {
        private readonly IClinique2000Services _services;

        public PatientAchargeController(IClinique2000Services services)
        {
            _services = services;
        }

        // GET: PatientAchargeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientAchargeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientAchargeController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                var userconnecter = await _services.patient.GetUserAuthAsync();
                Patient parent = await _services.patient.GetPatientParUserIdAsync(userconnecter.Id);
              
                ViewBag.PatientId = parent.PatientId; // Setting PatientId in ViewBag

                return View();
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
                return RedirectToAction(nameof(Index)); // Redirect to index or another action
            }
        }

        // POST: PatientAchargeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientACharge patientACharge)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    // Save the patientACharge object to the database
                    Age age = _services.patient.CalculerAge(patientACharge.DateDeNaissance);

                    patientACharge.Age = age.Annees;
                    await _services.patientAcharge.AjouterPatientaCharge(patientACharge);
                    TempData[AppConstants.Success] = "Patient à charge ajouté avec succès";
                    return RedirectToAction("Index", "home", new {area=""});
                }
                else
                {
                    return View(patientACharge);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(patientACharge);
            }
        }


        // GET: PatientAchargeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientAchargeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientACharge patientACharge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Update the patientACharge object in the database
                    // Code to update the patientACharge object goes here

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(patientACharge);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientAchargeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientAchargeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Delete the patientACharge object from the database
                // Code to delete the patientACharge object goes here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
