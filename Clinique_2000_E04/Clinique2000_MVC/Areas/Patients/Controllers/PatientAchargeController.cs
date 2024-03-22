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
                    return RedirectToAction("Details", "patients", new { area = "Patients", id = patientACharge.PatientId });
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
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                // Get the patientACharge object from the database based on the id
                PatientACharge patientACharge = await _services.patientAcharge.ObtenirParIdAsync(id);

                if (patientACharge == null)
                {
                    return NotFound();
                }

                return View(patientACharge);
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
                return RedirectToAction(nameof(Index)); // Redirect to index or another action
            }
        }

        // POST: PatientAchargeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientACharge patientACharge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Update the patientACharge object in the database
                    await _services.patientAcharge.UpdatePatientAChargeAsync(patientACharge);

                    TempData[AppConstants.Success] = "Patient à charge modifié avec succès";
                    return RedirectToAction("Details", "patients", new { area = "Patients", id = patientACharge.PatientId });
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





        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                // Get the patientACharge object from the database based on the id
                PatientACharge patientACharge = await _services.patientAcharge.ObtenirParIdAsync(id);

                if (patientACharge == null)
                {
                    return NotFound();
                }

                return View(patientACharge);
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
                return RedirectToAction("Details", "patients", new { area = "Patients" });
            }
        }

        // POST: PatientAchargeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Get the patientACharge object from the database based on the id
                PatientACharge patientACharge = await _services.patientAcharge.ObtenirParIdAsync(id);

                if (patientACharge == null)
                {
                    return NotFound();
                }

                // Delete the patientACharge object from the database
                await _services.patientAcharge.DeletePatientAChargeAsync(patientACharge);
               

                TempData[AppConstants.Success] = "Patient à charge supprimé avec succès";
                return RedirectToAction("Details", "patients", new { area = "Patients", id=patientACharge.PatientId });
            }
            catch (Exception ex)
            {
                // Handle exception if necessary
                return RedirectToAction("Details", "patients", new { area = "Patients" }); // Redirect to index or another action
            }
        }
    }
}

