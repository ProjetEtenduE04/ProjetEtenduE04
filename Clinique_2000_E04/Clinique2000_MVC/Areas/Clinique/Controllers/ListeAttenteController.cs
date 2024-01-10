
using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clinique2000_MVC.Areas.Clinique.Controllers
{
    [Area("Clinique")]
    public class ListeAttenteController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public ListeAttenteController(IClinique2000Services service)
        {
            _services = service;
        }




        // GET: ListeAttenteController
        public async Task<ActionResult> Index()
        {
            IReadOnlyList<ListeAttente> listListAttente = await _services.listeAttente.ObtenirToutAsync();
            return View(listListAttente);

        }


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

        // GET: ListeAttenteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                ListeAttente list = await _services.listeAttente.ObtenirParIdAsync(id);
                return View(list);
            }
            return NotFound();

        }

        // POST: ListeAttenteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ListeAttente listeAttente)
        {
            if (ModelState.IsValid)
            {
                await _services.listeAttente.SupprimerAsync(listeAttente.ListeAttenteID);
                return RedirectToAction("Index");
            }

            return View(listeAttente);
        }










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
