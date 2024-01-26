
using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Clinique2000_Utility.Enum;

namespace Clinique2000_MVC.Areas.Cliniques.Controllers
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
        /// Obtient tout les listes d'Attente ordered par date d'effectivit� ,
        /// qui sont pertinantes a la receptionniste
        /// , puis les renvoie a la vue.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            DateTime now = DateTime.Now.Date;

            IList<ListeAttente> listListAttente = await _services.listeAttente
                .ObtenirToutAsync();


            listListAttente = listListAttente.Where(x => x.DateEffectivite >= now)
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
               if (listeAttente == null)
                { 
                    return NotFound();
                }

               var plagesHoraires = listeAttente.PlagesHoraires?? new List<PlageHoraire>();
               ListeAttenteVM listeAttenteVM = new ListeAttenteVM
                {
                    ListeAttente = listeAttente,
                    PlagesHoraires = listeAttente.PlagesHoraires.OrderBy(ph => ph.PlageHoraireID).ToList()
                };
                return View(listeAttenteVM);
            }

            return NotFound();
        }



        /// <summary>
        /// Obtient une ListeAttenteId en parametre, recupere la liste d'attente et la renvoie a la vue,
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> DetailsOrdonnes(int id)
        {
            ListeAttenteVM listeAttenteVM = new ListeAttenteVM();

            if (id >= 0)
            {
               listeAttenteVM = await _services.listeAttente.GetListeAttenteOrdonnee(id);
                if (listeAttenteVM == null)
                {
                    return NotFound();
                }
                return View("Details",listeAttenteVM);
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
                    listeAttente.CliniqueID = 2;
                    await _services.listeAttente.CreerListeAttenteAsync(listeAttente);
                    //valeur hardcod�
                  


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
                    //hardcod�
                    listeAttente.CliniqueID = 1;


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
        public async Task<ActionResult> AjouterDesPlagesHoraires(int ID)
        {
           
               await _services.listeAttente.GenererPlagesHorairesAsync(ID);

               var listeAttente = await _services.listeAttente.ObtenirParIdAsync(ID);
                ListeAttenteVM listeAttenteVM = new ListeAttenteVM
                {
                    ListeAttente = listeAttente,
                    PlagesHoraires = listeAttente.PlagesHoraires.OrderBy(ph => ph.PlageHoraireID).ToList()
                };
                return View("Details", listeAttenteVM);  
        }


    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReserverConsultation(int id)
        {
            try
            {
                await _services.consultation.ReserverConsultationAsync(id);
                var consultation = await _services.consultation.ObtenirParIdAsync(id);
                if (consultation == null)
                {
                    return NotFound();
                }

                return View("ReservationSuccess", consultation);
            }
            catch (ValidationException ex)
            {
                var consultation = await _services.consultation.ObtenirParIdAsync(id);
                var listeAttenteVM = await _services.listeAttente.GetListeAttenteOrdonnee(consultation.PlageHorarie.ListeAttenteID);

                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Details", listeAttenteVM);
            }
        }


        public async Task<ActionResult> TestReservationSuccess()
        {
          
            var clinique = new Clinique2000_Core.Models.Clinique
            {
                CliniqueID = 1, // ID ficticio
                NomClinique = "Santé pour tous",
                Courriel = "abc@dcv",
                //NumTelephone="514-123 4567",
                HeureOuverture = new TimeSpan(8, 0, 0), 
                HeureFermeture = new TimeSpan(17, 0, 0),
               
                Adresse = new Adresse
                {
                    AdresseID = 1, // ID ficticio
                    Numero = "123",
                    Rue = "Rue de la Clinique",
                    Ville = "Montréal",
                    Province = "Québec",
                    CodePostal = "H1H 1H1"
                },

            };

           
            var listeAttente = new ListeAttente
            {
                ListeAttenteID = 1, // ID ficticio
                IsOuverte = true,
                DateEffectivite = new DateTime(2024, 1, 19),
                HeureOuverture = new TimeSpan(8, 0, 0), // Ejemplo: 8:00 AM
                HeureFermeture = new TimeSpan(17, 0, 0), // Ejemplo: 5:00 PM
                NbMedecinsDispo = 5,
                DureeConsultationMinutes = 30,
                CliniqueID = clinique.CliniqueID,
                Clinique = clinique
                
            };

            
            var plageHoraire = new PlageHoraire
            {
                PlageHoraireID = 1, // ID ficticio
                HeureDebut = new DateTime(2024, 1, 19, 9, 0, 0),
                HeureFin = new DateTime(2024, 1, 19, 9, 30, 0),
                ListeAttenteID = listeAttente.ListeAttenteID,
                ListeAttente = listeAttente
            };

            var consultation = new Consultation
            {
                ConsultationID = 1, // ID ficticio
                HeureDateDebutPrevue = plageHoraire.HeureDebut,
                HeureDateFinPrevue = plageHoraire.HeureFin,
                PlageHoraireID = plageHoraire.PlageHoraireID,
                PlageHorarie = plageHoraire,
                PatientID = 1, // ID ficticio
                Patient = new Patient
                {
                    Nom = "Emond",
                    Prenom = "Benoit"
                },
             
               
                // Añade aquí otras propiedades necesarias para Consultation
            };

           
            return View("ReservationSuccess", consultation);
        }

        public  async Task<IActionResult> IndexlisteSalleAttente(int listeAttenteID)
        {

            ListeAttenteVM listeSalleAttenteVM = new ListeAttenteVM();
            if (listeAttenteID > 0)
            {
                listeSalleAttenteVM = await _services.listeAttente.GetListeSalleAttenteOrdonnee(listeAttenteID);
                if (listeSalleAttenteVM == null)
                {
                    return NotFound();
                }
                return View(listeSalleAttenteVM);
            }
            else
            {
                return View("NotFound");
            }
        }

    }
}
