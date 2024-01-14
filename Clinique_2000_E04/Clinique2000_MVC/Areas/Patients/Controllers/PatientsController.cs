using Clinique2000_Core.Models;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Claims;

namespace Clinique2000_MVC.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientsController : Controller
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IServiceBaseAsync<Patient> _serviceBase;
        private readonly IPatientService _patientService;
        private readonly IAuthenGoogleService _authenGoogleService;

        public PatientsController(IServiceBaseAsync<Patient> serviceBase,
            IPatientService patientService,
            IAuthenGoogleService authenGoogleService,
            //SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _serviceBase = serviceBase;
            _patientService = patientService;
            _authenGoogleService = authenGoogleService;
            //_signInManager = signInManager;
            _userManager = userManager;
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
            #region
            //var utilisateurConnecte = await _authenGoogleService.GetAuthUserDataAsync();
            //if(utilisateurConnecte.Courriel==null || await _patientService.VerifierExistencePatientParEmailAsync(utilisateurConnecte.Courriel))
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(utilisateurConnecte);
            #endregion


            if (User.Identity.IsAuthenticated)
            {
                string courriel = User.FindFirstValue(ClaimTypes.Email);
                var user  =await _userManager.FindByEmailAsync(courriel);
                bool isPatient = await _patientService.UserEstPatientAsync(user.Id);

                if (!isPatient)
                {
                    var patientModel = new Patient
                    {
                       UserId = user.Id,
                    };

                    return View(patientModel);
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,NAM,CodePostal,DateDeNaissance,Age,PatientId,Nom,Prenom,Genre")] Patient patient)
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

        //// GET: PatientsController/Edit/5
        //public async ActionResult Edit(string id)
        //{
        //    try
        //    {
        //        var patient = await _patientService.GetPatientParUserIdAsync(id);

        //        if(patient == null)
        //        {
        //            return NotFound;
        //        }
        //        return View(patient);
        //    } 
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

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
