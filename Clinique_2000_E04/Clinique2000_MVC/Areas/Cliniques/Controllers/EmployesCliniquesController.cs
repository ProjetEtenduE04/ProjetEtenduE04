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

             

                // L'utilisateur n'est pas le créateur ou l'administrateur d'une clinique, nous redirigeons donc vers la page principale.
                TempData[AppConstants.Error] = "Accès refusé. Seuls les superadministrateurs, les créateurs de cliniques ou les administrateurs de cliniques sont autorisés à accéder à cette page";
                return RedirectToAction("Index", "Home", new { area = "" });
                //}

              
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
                TempData[AppConstants.Info] = $"Il n'y a pas de patient en attente.";
            }

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
                TempData[AppConstants.Success] = "Les informations de l'employé ont été mises à jour avec succès.";
                return RedirectToAction(nameof(Details), new { id = employesClinique.EmployeCliniqueID });
            }
            return View(employesClinique);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _services.patient.GetUserAuthAsync();
            // Assuming this method returns the current user based on authentication context.
            // var userAuth = await _userManager.GetUserAsync(User);

            if (User.IsInRole(AppConstants.SuperAdminRole))
            {
                // User is a SuperAdmin: Display dropdown list of all clinics.
                ViewData["CliniqueID"] = new SelectList(await _services.clinique.ObtenirToutAsync(), "CliniqueID", "NomClinique");
            }
            else
            {
                // Check if the user is a "gestionnaireDeClinique" (clinic manager).
                bool isGestionnaire = await _services.clinique.VerifierSiUserAuthEstCreateurClinique(user);
                if (isGestionnaire)
                {
                    // User is a clinic manager: Use the clinic they manage as the default value.
                    var cliniques = await _services.clinique.ObtenirLESCliniquesParCreateurId(user.Id);

                    if (cliniques.Count > 1)
                    {
                        // If the manager has more than one clinic, provide a selection.
                        ViewData["CliniqueID"] = new SelectList(cliniques, "CliniqueID", "NomClinique");
                    }
                    else if (cliniques.Count == 1)
                    {
                        // For a single clinic, still use a SelectList to keep the view logic consistent.
                        ViewData["CliniqueID"] = new SelectList(cliniques, "CliniqueID", "NomClinique", cliniques.First().CliniqueID);
                    }
                
                }
                else
                {
                    // Redirect non-authorized users to a suitable page.
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployesClinique employesClinique)
        {
            var user = await _services.patient.GetUserAuthAsync();
            var userAuth = await _userManager.GetUserAsync(User);

            // Repopulate the clinic SelectList for the form based on the user role
            if (User.IsInRole(AppConstants.SuperAdminRole))
            {
                // SuperAdmins see all clinics
                ViewData["CliniqueID"] = new SelectList(await _services.clinique.ObtenirToutAsync(), "CliniqueID", "NomClinique");
            }
            else if (await _services.clinique.VerifierSiUserAuthEstCreateurClinique(user))
            {
                // For clinic managers, get the list of clinics they manage
                var cliniquesGerees = await _services.clinique.ObtenirLESCliniquesParCreateurId(user.Id);

                if (cliniquesGerees.Count > 1)
                {
                    // If the manager handles multiple clinics, provide a dropdown selection
                    ViewData["CliniqueID"] = new SelectList(cliniquesGerees, "CliniqueID", "NomClinique");
                }
                else if (cliniquesGerees.Count == 1)
                {
                    // If only one clinic is managed, set it directly (though this should already be set by the model or hidden input)
                    employesClinique.CliniqueID = cliniquesGerees.First().CliniqueID;
                    ViewData["CliniqueID"] = new SelectList(cliniquesGerees, "CliniqueID", "NomClinique", employesClinique.CliniqueID);
                }
                
            }
            // else, potentially handle other roles or redirect if unauthorized

            if (ModelState.IsValid)
            {
                var addedEmploye = await _services.employesClinique.AjouterEmployerAsync(employesClinique);

                if (addedEmploye != null)
                {
                    return RedirectToAction("employescliniques", "Cliniques", new {area=""});
                }
                else
                {
                    TempData[AppConstants.Warning] = "Cet employé existe déjà ou n'a pas pu être ajouté.";
                    // No need to repopulate ViewData here, as it's already done above
                }
            }

            // If we get here, something failed; re-display form
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