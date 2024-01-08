using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Clinique2000_MVC.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientsController : Controller
    {
        private readonly IServiceBaseAsync<Patient> _serviceBase;
        private readonly IPatientService _patientService;
        private readonly IAuthenGoogleService _authenGoogleService;

        public PatientsController(IServiceBaseAsync<Patient> serviceBase, IPatientService patientService, IAuthenGoogleService authenGoogleService)
        {
            _serviceBase = serviceBase;
            _patientService = patientService;
            _authenGoogleService = authenGoogleService;
        }

        // GET: PatientsController
        public async Task<IActionResult> Index()
        {
            //return View(); 
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            return View("Index");
        }

        // GET: PatientsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: PatientsController/Create
        public async Task<IActionResult> Create()
        {
            //var courriel = await _authenGoogleService.GetUserEmailAsync();
            //var nameIdentifier = await _authenGoogleService.GetUserNameIdentifierAsync();
            //var dateDeNaissance =await _authenGoogleService.GetUserDateOfBirthAsync();
            //var patient = new Patient { Courriel = courriel, GoogleNameIdentifier=nameIdentifier , DateDeNaissance = dateDeNaissance };
            var utilisateurConnecte = await _authenGoogleService.GetAuthUserDataAsync();
            return View(utilisateurConnecte);
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoogleNameIdentifier,NAM,CodePostal,MotDePasse,MotDePasseConfirmation,DateDeNaissance,Age,PersonneId,Nom,Prenom,Courriel,Genre")] Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _patientService.EnregistrerPatient(patient);
                    return RedirectToAction(nameof(Index));
                }
                return View(patient);
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientsController/Edit/5
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

        // GET: PatientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientsController/Delete/5
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
