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
        public async Task<IActionResult> Index()
        {
            var employesClinique = await _services.employesClinique.ObtenirToutAsync();

            //.EmployesClinique.Include(e => e.Clinique).Include(e => e.User);
            return View(employesClinique);
        }

        // GET: EmployesCliniques/Details/5
        public async Task<IActionResult> Details()
        {

            //recupere le user connecté
            var email = User.Identity.Name;
            var user =  await _userManager.FindByEmailAsync(email);
            var employee= await _services.employesClinique.FindOneAsync(x=>x.UserID==user.Id);

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

            Consultation? prochaineconsultation =  consultationList.Where(x => x.StatutConsultation == Clinique2000_Utility.Enum.StatutConsultation.EnAttente && x.PlageHoraire.ListeAttenteID== listeAttente.ListeAttenteID)
           .OrderBy(x => x.ConsultationID)
           .ThenBy(x => x.PlageHoraire.HeureDebut)
           .ThenBy(x => x.Patient.Prenom)
           .ThenBy(x => x.Patient.Nom).FirstOrDefault();



            Consultation? consultationEnCour = consultationList.Where(x => x.StatutConsultation == Clinique2000_Utility.Enum.StatutConsultation.EnCours && x.MedecinId == employee.UserID).FirstOrDefault();

            if (consultationEnCour==null && prochaineconsultation==null)
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
                ConsultationEnCours= consultationEnCour,

            };
            
            return View(employesCliniqueVM);
        }


        public async Task<IActionResult> SelectionnerClinique( int cliniqueID)
        {
            var clinique = await _services.employesClinique.SelectionnerClinique(cliniqueID);
           
            return View();
        }

        
        public async Task<IActionResult> GetUserID()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);//Recupere l email d l user connecté

           
            var user= await _userManager.FindByEmailAsync(userEmail);//recupere l id de User connecté
            if (user.Id == null)
            {
                return View();
            }
            EmployesClinique employesClinique =  await _services.employesClinique.GetEmployeUserID(userEmail, user.Id);//chercher le EmployeClinique avec le meme email que le user 
            

            return RedirectToAction("Details", new { id = employesClinique.EmployeCliniqueID });
        }


      



        //    // GET: EmployesCliniques/Create
        //    public IActionResult Create()
        //    {
        //        ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel");
        //        ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id");
        //        return View();
        //    }

        //    // POST: EmployesCliniques/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("EmployeCliniqueID,EmployeCliniqueNom,EmployeCliniquePrenom,EmployeCliniqueCourriel,EmployeCliniquePosition,UserID,CliniqueID")] EmployesClinique employesClinique)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(employesClinique);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel", employesClinique.CliniqueID);
        //        ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", employesClinique.UserID);
        //        return View(employesClinique);
        //    }

        //    // GET: EmployesCliniques/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null || _context.EmployesClinique == null)
        //        {
        //            return NotFound();
        //        }

        //        var employesClinique = await _context.EmployesClinique.FindAsync(id);
        //        if (employesClinique == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel", employesClinique.CliniqueID);
        //        ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", employesClinique.UserID);
        //        return View(employesClinique);
        //    }

        //    // POST: EmployesCliniques/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("EmployeCliniqueID,EmployeCliniqueNom,EmployeCliniquePrenom,EmployeCliniqueCourriel,EmployeCliniquePosition,UserID,CliniqueID")] EmployesClinique employesClinique)
        //    {
        //        if (id != employesClinique.EmployeCliniqueID)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(employesClinique);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!EmployesCliniqueExists(employesClinique.EmployeCliniqueID))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CliniqueID"] = new SelectList(_context.Cliniques, "CliniqueID", "Courriel", employesClinique.CliniqueID);
        //        ViewData["UserID"] = new SelectList(_context.ApplicationUser, "Id", "Id", employesClinique.UserID);
        //        return View(employesClinique);
        //    }

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