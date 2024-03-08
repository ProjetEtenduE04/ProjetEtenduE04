using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Clinique2000_Utility.Constants;
using Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace Clinique2000_MVC.Areas.Cliniques.Controllers
{
    [Area("Cliniques")]

    public class EmployesCliniquesController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public IClinique2000Services _services { get; set; }

        public EmployesCliniquesController(
            IClinique2000Services service,
            UserManager<IdentityUser> userManager

            )
        {
            _services = service;
            _userManager = userManager;
        }

        // GET: EmployesCliniques
        //[Authorize(Roles = AppConstants.AdminCliniqueRole + "," + AppConstants.SuperAdminRole)]
        //public async Task<IActionResult> Index()
        //{

        //    var employesClinique = await _services.employesClinique.ObtenirToutAsync();

        //    //.EmployesClinique.Include(e => e.Clinique).Include(e => e.User);
        //    return View(employesClinique);
        //}

        //[Authorize(Roles = AppConstants.AdminCliniqueRole + "," + AppConstants.SuperAdminRole)]
        public async Task<IActionResult> Index()
        {

            try
            {

                //if (User.IsInRole(AppConstants.AdminCliniqueRole) || User.IsInRole(AppConstants.SuperAdminRole))
                //{
                // Obtenir l'ID de l'utilisateur connecté
                var userAuth = await _services.patient.GetUserAuthAsync();


                // Vérifier si l'utilisateur est un superadministrateur
                if (User.IsInRole(AppConstants.SuperAdminRole))
                {
                    // L'utilisateur est un superadministrateur, il peut donc voir toutes les cliniques
                    var employesClinique = await _services.employesClinique.ObtenirToutAsync();
                    return View(employesClinique);
                }
                // Vérifier si l'utilisateur est le créateur d'une clinique
                //var isCreator = await _services.clinique.VerifierSiUserAuthEstCreateurClinique(userAuth);
                if (User.IsInRole(AppConstants.AdminCliniqueRole))
                {
                    // L'utilisateur est le créateur d'une clinique, il ne peut donc voir que ses cliniques.
                    var listeCliniqueAdminClinique = await _services.clinique.ObtenirListeCliniquesParCreateurId(userAuth.Id);
                    var listEmployesCliniques = await _services.employesClinique.GetEmployeSelonLaListeClinique(listeCliniqueAdminClinique);
                    return View(listEmployesCliniques);
                }

                // Vérifier si l'utilisateur est l'employe d'une clinique 
                //var estEmploye = await _services.employesClinique.VerifierSiUserAuthEstEmploye(userAuth.Email);
                //if (estEmploye != null)
                //{
                //    // L'utilisateur est l'employe d'une clinique, il ne peut donc voir que  les cliniques où ils travaillent.
                //    var listCliniqueEmploye = await _services.employesClinique.ObtenirCliniquesDeLEmploye(estEmploye);
                //    var listEmployesCliniques = await _services.employesClinique.GetEmployeSelonLaListeClinique(listCliniqueEmploye);
                //    return View(listEmployesCliniques);
                //}

                // L'utilisateur n'est pas le créateur ou l'administrateur d'une clinique, nous redirigeons donc vers la page principale.
                TempData[AppConstants.Error] = "Accès refusé. Seuls les superadministrateurs, les créateurs de cliniques ou les administrateurs de cliniques sont autorisés à accéder à cette page";
                return RedirectToAction("Index", "Home", new { area = "" });
                //}

                // L'utilisateur n'a pas l'un des rôles requis, nous redirigeons donc vers la page principale et affichons un message d'erreur.
                //TempData[AppConstants.Error] = "Accès refusé. Seuls les superadministrateurs et les administrateurs de cliniques sont autorisés à accéder à cette page";
                //return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erreur", ex.Message);
                TempData[AppConstants.Error] = $"Erreur : {ex.Message}";
                return RedirectToAction("Index", "Home", new { area = "" });

            }

        }

        // GET: EmployesCliniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            //var email = User.Identity.Name;
            //var user = await _userManager.FindByEmailAsync(email);
            //var employee = await _services.employesClinique.FindOneAsync(x => x.UserID == user.Id && x.EmployeCliniquePosition == Clinique2000_Utility.Enum.EmployeCliniquePosition.Medecin);

            //recupere le user connecté
            //var email = User.Identity.Name;
            //var user =  await _userManager.FindByEmailAsync(email);
            var employee = await _services.employesClinique.ObtenirParIdAsync(id);





            //EmployesClinique employesClinique = await _services.employesClinique.ObtenirParIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var listeAttente = await _services.employesClinique.ObtenirListeAttenteDeLaClinqueDeLEmploye(employee.CliniqueID);
            var listeAttenteVM = await _services.listeAttente.GetListeSalleAttenteOrdonnee(listeAttente.ListeAttenteID);
            var mesCliniques = await _services.employesClinique.ObtenirCliniquesDeLEmploye(employee);


            List<Consultation> consultationList = new List<Consultation>();

            foreach (var plagesHoraire in listeAttente.PlagesHoraires)
            {
                foreach (Consultation consultation in plagesHoraire.Consultations)
                {
                    consultationList.Add(consultation);
                }
            }

            Consultation? prochaineconsultation = consultationList.Where(x => x.StatutConsultation == Clinique2000_Utility.Enum.StatutConsultation.EnAttente && x.PlageHoraire.ListeAttenteID == listeAttente.ListeAttenteID)
           .OrderBy(x => x.ConsultationID)
           .ThenBy(x => x.PlageHoraire.HeureDebut)
           .ThenBy(x => x.Patient.Prenom)
           .ThenBy(x => x.Patient.Nom).FirstOrDefault();



            Consultation? consultationEnCour = consultationList.Where(x => x.StatutConsultation == Clinique2000_Utility.Enum.StatutConsultation.EnCours && x.MedecinId == employee.UserID).FirstOrDefault();

            if (consultationEnCour == null && prochaineconsultation == null)
            {
                TempData[AppConstants.Info] = $"Il n'y a plus de consultations en attente";
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            //if (consultationEnCour == null)
            //{
            //    consultationEnCour = prochaineconsultation;
            //    _services.listeAttente.MettreConsultationEnCours(consultationEnCour.ConsultationID);

            //    prochaineconsultation = null;

            //     prochaineconsultation = consultationList.Where(x => x.StatutConsultation == Clinique2000_Utility.Enum.StatutConsultation.EnAttente)
            //        .OrderBy(x => x.ConsultationID)
            //        .ThenBy(x => x.PlageHoraire.HeureDebut)
            //        .ThenBy(x => x.Patient.Prenom)
            //        .ThenBy(x => x.Patient.Nom).FirstOrDefault();


            //}

            var employesCliniqueVM = new EmployesCliniqueVM()
            {
                EmployesClinique = employee,
                MesCliniques = mesCliniques,
                ListeAttente = listeAttente,
                ListeAttenteVM = listeAttenteVM,
                ProchaineConsultation = prochaineconsultation,
                ConsultationEnCours = consultationEnCour,

            };

            return View(employesCliniqueVM);
        }


        public async Task<IActionResult> SelectionnerClinique(int cliniqueID)
        {
            var clinique = await _services.employesClinique.SelectionnerClinique(cliniqueID);

            return View();
        }


        public async Task<IActionResult> GetUserID()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);//Recupere l email d l user connecté


            var user = await _userManager.FindByEmailAsync(userEmail);//recupere l id de User connecté
            if (user.Id == null)
            {
                return View();
            }
            EmployesClinique employesClinique = await _services.employesClinique.GetEmployeUserID(userEmail, user.Id);//chercher le EmployeClinique avec le meme email que le user 


            return RedirectToAction("Details", new { id = employesClinique.EmployeCliniqueID });
        }

        public async Task<IActionResult> GetUserIDReturnToListeAttente()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);//Recupere l email d l user connecté


            var user = await _userManager.FindByEmailAsync(userEmail);//recupere l id de User connecté
            if (user.Id == null)
            {
                return View();
            }
            EmployesClinique employesClinique = await _services.employesClinique.GetEmployeUserID(userEmail, user.Id);//chercher le EmployeClinique avec le meme email que le user 


            return RedirectToAction("Index", "listeattente", new { area = "Cliniques" }/*, new { id = employesClinique.EmployeCliniqueID }*/);
        }

        // GET: EmployesCliniques/Create
        public IActionResult Create()
        {
            //ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel");
            //ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            var cliniques = _services.clinique.GetAllClinique();

            ViewData["clinique"] = cliniques;

            return View();
        }

        // POST: EmployesCliniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeCliniqueID,EmployeCliniqueNom,EmployeCliniquePrenom,EmployeCliniqueCourriel,EmployeCliniquePosition,UserID,CliniqueID")] EmployesClinique employesClinique)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(employesClinique);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel", employesClinique.CliniqueID);
            //ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", employesClinique.UserID);
            return View(employesClinique);
        }

        // GET: EmployesCliniques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _services.employesClinique == null)
            {
                return NotFound();
            }

            var employesClinique = await _services.employesClinique.ObtenirParIdAsync(id);
            ViewData["CliniqueID"] = employesClinique.CliniqueID;
            if (employesClinique == null)
            {
                return NotFound();
            }
            return View(employesClinique);
        }

        //POST: EmployesCliniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeCliniqueID,EmployeCliniqueNom,EmployeCliniquePrenom,EmployeCliniqueCourriel,EmployeCliniquePosition,UserID,CliniqueID")] EmployesClinique employesClinique)
        {
            if (id != employesClinique.EmployeCliniqueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.CliniqueID = employesClinique.CliniqueID;
                    await _services.employesClinique.UpdateEmployeCliniqueAsync(employesClinique);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_services.employesClinique.EmployeCliniqueExists(employesClinique.EmployeCliniqueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = employesClinique.EmployeCliniqueID });
            }
            return View(employesClinique);
        }
        // GET: EmployesCliniques/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var user = await _services.patient.GetUserAuthAsync();
            var userAuth = await _userManager.GetUserAsync(User);

            if (User.IsInRole(AppConstants.SuperAdminRole))
            {
                // User is an admin, display dropdown list of clinics
                ViewData["CliniqueID"] = new SelectList(await _services.clinique.ObtenirToutAsync(), "CliniqueID", "Courriel");
            }
            else if (await _services.clinique.VerifierSiUserAuthEstCreateurClinique(user) == true)
            {
                // User is a gestionnaireDeClinique, use the clinic they work for as the default value
                var clinique = await _services.clinique.ObtenirCliniqueParCreteurId(user.Id);
                ViewData["CliniqueID"] = clinique.CliniqueID;
            }
            else
            {
                // For example, redirect to an error page or display an error message
                return RedirectToAction("Index", "Home", new { area = "" });
            }


            return View();


                  // Si un employe existe deja, renvoyer a la page de modification et on me dit qu'il existe deja. ************************************



        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployesClinique employesClinique)
        {
            if (ModelState.IsValid)
            {
                var addedEmploye = await _services.employesClinique.AjouterEmployerAsync(employesClinique);
                if (addedEmploye != null)
                {
                    // Redirect to a suitable page after successful creation
                    return RedirectToAction("Index"); // Adjust 'Index' to your actual success landing action method
                }
                else
                {
                    // Handle the case where the employee couldn't be added (e.g., already exists)
                    TempData["ErrorMessage"] = "Cet employé existe déja.";
                    return View("Create", employesClinique);
                }
            }
            return View(employesClinique);
        }



        //    // GET: EmployesCliniques/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null || _context.EmployesClinique == null)
        //        {
        //            return NotFound();
        //        }

        //        var employesClinique = await _context.EmployesClinique
        //            .Include(e => e.Clinique)
        //            .Include(e => e.User)
        //            .FirstOrDefaultAsync(m => m.EmployeCliniqueID == id);
        //        if (employesClinique == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(employesClinique);
        //    }

        //    // POST: EmployesCliniques/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        if (_context.EmployesClinique == null)
        //        {
        //            return Problem("Entity set 'ApplicationDbContext.EmployesClinique'  is null.");
        //        }
        //        var employesClinique = await _context.EmployesClinique.FindAsync(id);
        //        if (employesClinique != null)
        //        {
        //            _context.EmployesClinique.Remove(employesClinique);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool EmployesCliniqueExists(int id)
        //    {
        //      return (_context.EmployesClinique?.Any(e => e.EmployeCliniqueID == id)).GetValueOrDefault();
        //    }
        //}
    }
}