
using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Clinique2000_Utility.Constants;

namespace Clinique2000_MVC.Areas.Cliniques.Controllers
{
    [Area("Cliniques")]
    public class ConsultationController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public ConsultationController(IClinique2000Services service)
        {
            _services = service;
        }

        
        /// <summary>
        /// Obtient tout les listes d'Attente ordered par date d'effectivité ,
        /// qui sont pertinantes a la receptionniste
        /// , puis les renvoie a la vue.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            DateTime now = DateTime.Now.Date;

            IList<Consultation> consultation = await _services.consultation
                .ObtenirToutAsync();


            //consultation = consultation.Where(x => x.DateEffectivite >= now)
            //    .OrderBy(x => x.DateEffectivite)
            //    .ToList();


            return View(consultation);
        }

        /// <summary>
        /// Retourne tout les Listes d'attente 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Historiqueconsultations()
        {

            IList<Consultation> consultation = await _services.consultation
        .ObtenirToutAsync();

          consultation = consultation.ToList();

            return View(consultation);
        }


        /// <summary>
        /// Obtient une consultationId en parametre, recupere la liste d'attente et la renvoie a la vue, 
        /// si le consultationId recu en parametre est pas valide, retourne NotFound
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            if (id >= 0)
            {
                Consultation consultation = await _services.consultation.ObtenirParIdAsync(id);
                return View(consultation);
            }
            TempData[AppConstants.Warning] = $"Désolé, mais la Consultation n'a pas été trouvée.";
            return View("NotFound");

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: consultationController/Create
        /// <summary>
        /// Action de creation de la liste d'attente.
        /// Si le formulaire est valide, on redirige l'utilisateur vers la page index,
        /// sinon, on lui retourne le formulaire comme il l'avait remplit avec l'erreur de validation
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Consultation consultation)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        await _services.consultation.CreerconsultationAsync(consultation);
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch(ValidationException ex)
            //{
            //    ModelState.AddModelError("", ex.Message);
            //}
         


            return View("create", consultation);
        }


          
        

        [HttpGet]
        // GET: consultationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Consultation list = await _services.consultation.ObtenirParIdAsync(id);
            return View(list);


        }

        // POST: consultationController/Edit/5
        /// <summary>
        /// Action de modification de la liste d'attente.
        /// Si le formulaire est valide, la modification est effectuee et l'utilisateur est redirige vers la page index,
        /// dans le cas contraire, on lui envoie l'erreur de validation
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Consultation consultation)
        {

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        await _services.consultation.ModifierconsultationAsync(consultation);
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch(ValidationException ex)
            //{
            //    ModelState.AddModelError("", ex.Message);
            //}
       

            return View(consultation);
        }

        /// <summary>
        /// Recoit un consultationID en parametre et recupere la liste d'Attente puis l'envoie a la vue.
        /// Redirige l'utilisateur vers la vue Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: consultationController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                Consultation consultation = _services.consultation.ObtenirParIdAsync(id).Result;
                return View("Delete", consultation);
            }
            return NotFound();
         
        }



        // POST: consultationController/Delete/5
        /// <summary>
        /// Verifie si la liste d'Attente peut etre supprimee, si elle peut etre supprimee,
        /// on la supprime, sinon, on retourne la meme vue avec l'erreur de validation.
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Consultation consultation)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        if (!_services.consultation.PeutSupprimmer(consultation))
            //        {
            //            ModelState.AddModelError("", "Cette liste d'attente ne peut etre supprimee.");
            //            return View(consultation);
            //        }
            //        else
            //        {
            //            await _services.consultation.Supprimmerconsultation(consultation);
            //            return RedirectToAction("index");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Log the exception details as needed
            //        ModelState.AddModelError("", "Une erreur s'est produite lors de la suppression : " + ex.Message);
            //        return View(consultation);
            //    }
            //}

            return View(consultation);
        }




        /// <summary>
        /// Genere des plages horaires
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AjouterDesPlagesHorairesl(int ID)
        {
            var model = await _services.consultation.ObtenirParIdAsync(ID);
            if (model != null)
            {
                //await _services.consultation.GenererPlagesHorairesAsync(ID);

                model = await _services.consultation.ObtenirParIdAsync(ID);
                TempData[AppConstants.Success] = $"Les plages horaires ont été générées avec succès.";
                return View("Details", model);

            }
            TempData[AppConstants.Warning] = $"Désolé, mais la consultation n'a pas été trouvée.";
            return View("NotFound");
        }




       




    }
}
