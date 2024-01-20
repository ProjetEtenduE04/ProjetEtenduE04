
using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Clinique2000_MVC.Areas.Clinique.Controllers
{
    [Area("Cliniques")]
    public class ListeAttenteController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public ListeAttenteController(IClinique2000Services service)
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
            DateTime now = DateTime.Now;

            IList<ListeAttente> listListAttente = await _services.listeAttente
                .ObtenirToutAsync();


            listListAttente = listListAttente.Where(x => x.DateEffectivite.AddDays(-1) >= now)
                .OrderBy(x => x.DateEffectivite)
                .ToList();
                

            return View(listListAttente);
        }

        /// <summary>
        /// Retourne tout les Listes d'attente 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> HistoriqueListeAttentes()
        {

            IList<ListeAttente> listListAttente = await _services.listeAttente
        .ObtenirToutAsync();

          listListAttente = listListAttente.OrderByDescending(x => x.DateEffectivite).ToList();

            return View(listListAttente);
        }


        /// <summary>
        /// Obtient une ListeAttenteId en parametre, recupere la liste d'attente et la renvoie a la vue, 
        /// si le listeAttenteId recu en parametre est pas valide, retourne NotFound
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            if (id >= 0)
            {
                ListeAttente listeAttente = await _services.listeAttente.ObtenirParIdAsync(id);
                return View(listeAttente);
            }
            return NotFound();

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListeAttenteController/Create
        /// <summary>
        /// Action de creation de la liste d'attente.
        /// Si le formulaire est valide, on redirige l'utilisateur vers la page index,
        /// sinon, on lui retourne le formulaire comme il l'avait remplit avec l'erreur de validation
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ListeAttente listeAttente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _services.listeAttente.CreerListeAttenteAsync(listeAttente);
                    return RedirectToAction("Index");
                }
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
         


            return View("create", listeAttente);
        }


          
        

        [HttpGet]
        // GET: ListeAttenteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            ListeAttente list = await _services.listeAttente.ObtenirParIdAsync(id);
            return View(list);


        }

        // POST: ListeAttenteController/Edit/5
        /// <summary>
        /// Action de modification de la liste d'attente.
        /// Si le formulaire est valide, la modification est effectuee et l'utilisateur est redirige vers la page index,
        /// dans le cas contraire, on lui envoie l'erreur de validation
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ListeAttente listeAttente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _services.listeAttente.ModifierListeAttenteAsync(listeAttente);
                    return RedirectToAction("Index");
                }
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
       

            return View(listeAttente);
        }

        /// <summary>
        /// Recoit un ListeAttenteID en parametre et recupere la liste d'Attente puis l'envoie a la vue.
        /// Redirige l'utilisateur vers la vue Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ListeAttenteController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                ListeAttente listeattente = _services.listeAttente.ObtenirParIdAsync(id).Result;
                return View("Delete", listeattente);
            }
            return NotFound();
         
        }



        // POST: ListeAttenteController/Delete/5
        /// <summary>
        /// Verifie si la liste d'Attente peut etre supprimee, si elle peut etre supprimee,
        /// on la supprime, sinon, on retourne la meme vue avec l'erreur de validation.
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ListeAttente listeAttente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_services.listeAttente.PeutSupprimmer(listeAttente))
                    {
                        ModelState.AddModelError("", "Cette liste d'attente ne peut etre supprimee.");
                        return View(listeAttente);
                    }
                    else
                    {
                        await _services.listeAttente.SupprimmerListeAttente(listeAttente);
                        return RedirectToAction("index");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details as needed
                    ModelState.AddModelError("", "Une erreur s'est produite lors de la suppression : " + ex.Message);
                    return View(listeAttente);
                }
            }

            return View(listeAttente);
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
            var model = await _services.listeAttente.ObtenirParIdAsync(ID);
            if (model != null)
            {
                await _services.listeAttente.GenererPlagesHorairesAsync(ID);

                model = await _services.listeAttente.ObtenirParIdAsync(ID);

                return View("Details", model);

            }
            return NotFound();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReserverConsultation(Patient patient, Consultation consultation)
        {
            _services.listeAttente.ReserverConsultation(consultation, patient);
            return RedirectToAction("Details", consultation);
        }







    }
}
