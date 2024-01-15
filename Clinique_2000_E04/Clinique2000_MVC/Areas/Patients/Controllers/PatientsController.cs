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
            var listeDePatients = await _serviceBase.ObtenirToutAsync();

            return View("Index", listeDePatients);
        }

        // GET: PatientsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _patientService.ObtenirToutAsync() == null)
            {
                return NotFound();
            }
            var patientDetails = await _patientService.ObtenirParIdAsync(id);
            if (patientDetails == null)
            {
                return NotFound();
            }
            return View(patientDetails);
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
                    await _patientService.EnregistrerOuModifierPatient(patient);
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
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _patientService.ObtenirToutAsync() == null)
                {
                    return NotFound();
                }
                var patient = await _patientService.ObtenirParIdAsync(id);

                if (patient == null)
                {
                    return NotFound();
                }
                return View(patient);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,Nom,Prenom,Genre,NAM,CodePostal,DateDeNaissance,Age,UserId")] Patient patient)
        {
            try
            {
                if (id != patient.PatientId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _patientService.EnregistrerOuModifierPatient(patient);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _patientService.VerifierExistencePatientParNAM(patient.NAM))
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null || _patientService.ObtenirToutAsync() == null)
                {
                    return NotFound();
                }
                var patient =  await _patientService.ObtenirParIdAsync(id);

                if (patient != null)
                {
                    return View(patient);
                }
                else
                    return NotFound();
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PatientsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int patientId)
        {
            try
            {
                var patient = await _patientService.ObtenirParIdAsync(patientId);
                if (patient != null)
                {
                    await _patientService.SupprimerAsync(patientId);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
