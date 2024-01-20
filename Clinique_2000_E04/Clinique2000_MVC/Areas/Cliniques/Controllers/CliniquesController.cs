
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

    public class CliniquesController : Controller
    {

        public IClinique2000Services _services { get; set; }

        public CliniquesController(IClinique2000Services service)
        {
            _services = service;
        }
        // GET: CliniqueController
        public async Task<IActionResult> IndexPourPatients()
        {
            // Get all clinics from the service
            var allClinics = await _services.clinique.ObtenirToutAsync();

            // Filter clinics where EstActive is true
            var activeClinics = allClinics.Where(clinic => clinic.EstActive);

            return View("IndexPourPatients", activeClinics);
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


        //public async Task<IActionResult> WaitingLists(int clinicId)
        //{
        //    IList<ListeAttente> listeAttentes = await _services.listeAttente.ObtenirToutAsync();

        //    listeAttentes = listeAttentes.Where(la => la.Clinique.CliniqueID == clinicId)
        //        .OrderBy(x => x.DateEffectivite)
        //        .ToList();

        //    string clinicName = _services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

        //    ViewBag.CliniqueName = clinicName;

        //    // If the form is submitted with filtering data
        //    if (Request.Method == "POST")
        //    {
        //        bool isOuvert = bool.Parse(Request.Form["isOuvert"]);
        //        listeAttentes = listeAttentes.Where(la => la.IsOuverte == isOuvert).ToList();
        //    }

        //    // Return the same view with the filtered or initial data
        //    return View("WaitingLists", listeAttentes);
        //}

        public async Task<IActionResult> ListeAttentePourPatient(int clinicId, bool? isOuvert)
        {

            IList<ListeAttente> listeAttentePourPatient = await _services.clinique.GetListeAttentePourPatientAsync(clinicId, isOuvert);

            string clinicName = _services.clinique.ObtenirParIdAsync(clinicId)?.Result?.NomClinique;

            ViewBag.CliniqueName = clinicName;

            return View("ListeAttentePourPatient", listeAttentePourPatient);
        }

    }


}

