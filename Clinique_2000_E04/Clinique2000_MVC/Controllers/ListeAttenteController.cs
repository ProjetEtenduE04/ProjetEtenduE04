using Clinique2000_Core.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using System.Collections.Generic;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Clinique2000_MVC.Controllers
{
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

            
            ListeAttente listeAttente = await _services.listeAttente.ObtenirParIdAsync(id);
            return View(listeAttente);
        }


        //// GET: ListeAttenteController/Create
        //public async Task<ActionResult> Create(int id)
        //{

        //    ListeAttente list = await _services.listeAttente.ObtenirParIdAsync(id);
        //    return View(list);

        //}

        // GET: ListeAttenteController/Create
        public IActionResult Create()
        {
            return View();

        }

        // POST: ListeAttenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ListeAttente listeAttente)
        {

            if (ModelState.IsValid)
            {
                await _services.listeAttente.CreerListeAttenteAsync(listeAttente);
               return  RedirectToAction("Index");
            }
            return View();
        }


            return View(listeAttente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AjouterPlagesHoraires(int listeAttenteID)
        {
            ListeAttente listeAttente = await _services.listeAttente.ObtenirParIdAsync(listeAttenteID);
            if (listeAttente == null)
            {

                return NotFound();
            }

            await _services.listeAttente.GenererPlagesHorairesAsync(listeAttente);
            return View(listeAttente);
        }
        [HttpGet]
        // GET: ListeAttenteController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            
             ListeAttente list = await _services.listeAttente.ObtenirParIdAsync(id);
            if (list == null)
            {

                return NotFound();
            }

            return View(list);
         
      
        }

        // POST: ListeAttenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ListeAttente listeAttente)
        {
            if (ModelState.IsValid)
            {
               await _services.listeAttente.EditerAsync(listeAttente);
               return RedirectToAction("Index");
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





    }





}
