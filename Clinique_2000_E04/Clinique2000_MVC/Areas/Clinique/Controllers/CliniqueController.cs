
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
    [Area("Clinique")]

    public class CliniqueController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public CliniqueController(IClinique2000Services service)
        {
            _services = service;
        }
        // GET: CliniqueController
        public async Task<IActionResult> IndexPourPatients()
        {
            //return View(); 
            var listeClinique = await _services.clinique.ObtenirToutAsync();

            return View("IndexPourPatients", listeClinique);
        }

        // GET: CliniqueController/Details/5
        public async Task<IActionResult> DetailsPourPatient(int? id)
        {

            if (id == null || await _services.clinique.ObtenirToutAsync() == null)
            {
                return NotFound();
            }
            var cliniqueDetail = await _services.clinique.ObtenirParIdAsync(id);
            if (cliniqueDetail == null)
            {
                return NotFound();
            }
            return View(cliniqueDetail);
        }

        //[HttpGet]
        //public async Task<IActionResult> WaitingLists(int clinicId)
        //{


        //    IList<ListeAttente> waitingLists = await _services.listeAttente.ObtenirToutAsync();


        //    waitingLists = waitingLists.Where(x => x.Clinique.CliniqueID == clinicId)
        //        .OrderBy(x => x.DateEffectivite)
        //        .ToList();

        //    string clinicName = _services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

        //    ViewBag.CliniqueName = clinicName;


        //    // Return the waiting lists partial view
        //    return View("WaitingLists", waitingLists);
        //}


        public async Task<IActionResult> WaitingLists(int clinicId)
        {
            IList<ListeAttente> listeAttentes = await _services.listeAttente.ObtenirToutAsync();

            listeAttentes = listeAttentes.Where(la => la.Clinique.CliniqueID == clinicId)
                .OrderBy(x => x.DateEffectivite)
                .ToList();

            string clinicName = _services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

            ViewBag.CliniqueName = clinicName;

            // If the form is submitted with filtering data
            if (Request.Method == "POST")
            {
                bool isOuvert = bool.Parse(Request.Form["isOuvert"]);
                listeAttentes = listeAttentes.Where(la => la.IsOuverte == isOuvert).ToList();
            }

            // Return the same view with the filtered or initial data
            return View("WaitingLists", listeAttentes);
        }




    }
}
