using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Clinique2000_Utility.Enum;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Clinique2000_Services.Services
{
    public class ListeAttenteService : ServiceBaseAsync<ListeAttente>, IListeAttenteService
    {

        private readonly CliniqueDbContext _context;
        private readonly IEmailService _emailService;

        public ListeAttenteService(CliniqueDbContext context, IEmailService emailService) : base(context)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<ListeAttente> CreerListeAttenteAsync(ListeAttente listeAttente)
        {


            if (VerifierSiListeAttenteExisteMemeJourClinique(listeAttente.DateEffectivite, listeAttente.CliniqueID))
            {
                throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.");
            }

            if (!VerifierSiDateEffectiviteValide(listeAttente) || !VerifierSiHeureOuvertureValide(listeAttente))
            {
                throw new ValidationException("La liste n'est pas valide");
            }
            else
            {
                await CreerAsync(listeAttente);
                return listeAttente;
            }
        }

        /// <summary>
        /// Cette methode s occupe de faire les verifications lors d'une creation de liste d'attente, puis faire la creation elle meme
        /// si une des verifications echoue, elle renvoie une erreur de validation 
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<ListeAttente> ModifierListeAttenteAsync(ListeAttente listeAttente)
        {
            if (VerifierSiListeAttenteExisteMemeJourClinique(listeAttente.DateEffectivite, listeAttente.CliniqueID, listeAttente.ListeAttenteID))
            {
                throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.");
            }

            if (!VerifierSiDateEffectiviteValide(listeAttente) || !VerifierSiHeureOuvertureValide(listeAttente))
            {
                throw new ValidationException("La liste n'est pas valide");
            }
            else
            {
                await EditerAsync(listeAttente);
                return listeAttente;
            }
        }

        /// <summary>
        /// Cette methode verifie que la liste dattente passee en parametre est pas ouverte
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        public bool PeutSupprimmer(ListeAttente listeAttente)
        {
            if (listeAttente.IsOuverte == false)
                return true;
            else
                return false;

        }


        /// <summary>
        /// Cette methode supprimme une liste d'attente de la base de donnees
        /// et sauvegarde les changements
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task SupprimmerListeAttente(ListeAttente listeAttente)
        {

            _context.ListeAttentes.Remove(listeAttente);
            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Cette methode Verifie s'il existe deja une liste d'attente dans la meme clinique pour la meme date.
        /// </summary>
        /// <param name="dateEffectivite"></param>
        /// <param name="cliniqueID"></param>
        /// <param name="listeAttenteID"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public bool VerifierSiListeAttenteExisteMemeJourClinique(DateTime dateEffectivite, int cliniqueID, int? listeAttenteID = null)
        {
            var query = _context.ListeAttentes.Where(la => la.DateEffectivite == dateEffectivite && la.CliniqueID == cliniqueID);

            if (listeAttenteID.HasValue)
            {
                query = query.Where(la => la.ListeAttenteID != listeAttenteID.Value);
                return query.Any();
            }
            else
            {
                return query.Any()
             ? throw new ValidationException("Il existe deja une liste d'attente dans la meme clinique pour la meme date.")
             : false;
            }
        }
        /// <summary>
        /// Verifie le nombree de Medecins et l existance de la liste d'attente avent d'ajouter les plages horaires. 
        /// </summary>
        /// <param name="listeAttente"></param>
        /// <returns></returns>
        public bool ListeAttenteIsValid(ListeAttente listeAttente)
        {

            if (!VerifierSiListeAttenteEstCree(listeAttente) ||
            !VerifierSiNbMedecinsDisponibles(listeAttente))
            {
                return false;
            }


            return true;
        }



        public bool VerifierSiListeAttenteEstCree(ListeAttente listeAttente)
        {
            return _context.ListeAttentes.Any(l => l.DateEffectivite == listeAttente.DateEffectivite && l.CliniqueID == listeAttente.CliniqueID)
                        ? true
                        : throw new ValidationException("Il faut creer une liste d'attente avant");
        }

        public bool VerifierSiNbMedecinsDisponibles(ListeAttente listeAttente)
        {
            return listeAttente.NbMedecinsDispo >= 1
                    ? true
                    : throw new ValidationException("On doit avoir au moins un medecin disponible.");
        }

        public bool VerifierSiHeureOuvertureValide(ListeAttente listeAttente)
        {
            return listeAttente.HeureOuverture < listeAttente.HeureFermeture
                     ? true
                     : throw new ValidationException("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.");

        }
        public bool VerifierSiDateEffectiviteValide(ListeAttente listeAttente)
        {

            return listeAttente.DateEffectivite >= DateTime.Now.Date
                   ? true
                   : throw new ValidationException("La date d'effectivite n'est pas valide. Elle doit etre posterieure a la date actuelle.");


        }

        public async Task GenererPlagesHorairesAsync(int ID)
        {
            var listeAttente = await _context.ListeAttentes.FindAsync(ID);
            if (!ListeAttenteIsValid(listeAttente))
            {
                throw new Exception("Liste d'attente invalide");
            }

            DateTime heureDebut = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureOuverture);
            DateTime finService = listeAttente.DateEffectivite.Date.Add(listeAttente.HeureFermeture);
            PlageHoraire plageHoraire;

            while (heureDebut < finService)
            {
                DateTime nouvelleHeureFin = heureDebut.AddMinutes((double)listeAttente.Clinique.TempsMoyenConsultation);
                plageHoraire = new PlageHoraire
                {
                    HeureDebut = heureDebut,
                    HeureFin = nouvelleHeureFin,
                    ListeAttente = listeAttente

                };
                _context.PlagesHoraires.Add(plageHoraire);
                await _context.SaveChangesAsync();

                for (int i = 0; i < listeAttente.NbMedecinsDispo; i++)
                {
                    Consultation consultation = new Consultation
                    {
                        //HeureDateDebutPrevue = heureDebut,
                        //HeureDateFinPrevue = nouvelleHeureFin,
                        StatutConsultation = StatutConsultation.DisponiblePourReservation,
                        PlageHoraireID = plageHoraire.PlageHoraireID,
                        PatientID = null,
                        ///Salle=i++;

                    };
                    _context.Consultations.Add(consultation);

                }
                heureDebut = nouvelleHeureFin;
            }
            await _context.SaveChangesAsync();

        }


        public async Task<ListeAttenteVM> GetListeAttenteOrdonnee(int listeAttenteID)
        {
            var listeAttente = await _context.ListeAttentes
                                     .FirstOrDefaultAsync(la => la.ListeAttenteID == listeAttenteID);

            if (listeAttente == null)
            {
                throw new Exception("La liste d'attente n'existe pas");
            }


            var plagesHoraires = await _context.PlagesHoraires
                                       .Where(ph => ph.ListeAttenteID == listeAttenteID)
                                       .OrderBy(ph => ph.PlageHoraireID)
                                       //.SkipWhile(ph => ph.Consultations.All(c => c.StatutConsultation != StatutConsultation.DisponiblePourReservation))

                                       .ToListAsync();


            var index = plagesHoraires.FindIndex(ph => ph.Consultations.Any(c => c.StatutConsultation == StatutConsultation.DisponiblePourReservation));
            if (index != -1)
            {
                plagesHoraires = plagesHoraires.Skip(index).ToList();
            }



            foreach (var plageHoraire in plagesHoraires)
            {
                plageHoraire.Consultations = await _context.Consultations
                                                           .Where(c => c.PlageHoraireID == plageHoraire.PlageHoraireID)
                                                           .OrderBy(c => c.ConsultationID)
                                                           .ToListAsync();
            }


            var listeAttenteVM = new ListeAttenteVM
            {
                ListeAttente = listeAttente,
                PlagesHoraires = plagesHoraires
            };

            return listeAttenteVM;
        }



        public async Task<ListeAttenteVM> GetListeSalleAttenteOrdonnee(int listeAttenteID)
        {
            var listeAttente = await _context.ListeAttentes
                                    .FirstOrDefaultAsync(la => la.ListeAttenteID == listeAttenteID);

            if (listeAttente == null)
            {
                throw new Exception("La liste d'attente n'existe pas");
            }


            var plagesHoraires = await _context.PlagesHoraires
                                       .Where(ph => ph.ListeAttenteID == listeAttenteID).ToListAsync();


            List<Consultation> consultations = await _context.Consultations
                                                            .Where(c => c.PlageHoraire.ListeAttenteID == listeAttenteID && c.StatutConsultation == StatutConsultation.EnAttente)
                                                            .OrderBy(c => c.PlageHoraire.HeureDebut)
                                                            .ThenBy(c => c.Patient.Prenom)
                                                            .ThenBy(c => c.Patient.Nom)
                                                            .ToListAsync();



            var listeSalleAttente = new ListeAttenteVM
            {
                ListeAttente = listeAttente,
                PlagesHoraires = plagesHoraires,
                Consultations = consultations

            };

            return listeSalleAttente;

        }


        //public async void MettreConsultationEnCours(int consultaionID)
        //{
        //    var consultation = await _context.Consultations.FindAsync(consultaionID);
        //    consultation.StatutConsultation = StatutConsultation.EnCours;
        //    _context.SaveChanges();

        //}

        //private string D�terminerProchainM�decinDisponible()
        //{
        //    // interroger la base de donn�es pour trouver un m�decin disponible qui n'est pas actuellement en consultation.

        //    // Recherche un m�decin disponible en filtrant par la position "Medecin".
        //    // De plus, v�rifie que le m�decin n'est pas actuellement en consultation en utilisant une sous-requ�te.
        //    var m�decinDisponible = _context.EmployesClinique
        //        .Where(doc => doc.EmployeCliniquePosition == EmployeCliniquePosition.Medecin)
        //        .Where(doc => !_context.Consultations.Any(cons => cons.Medecin.UserID == doc.UserID && cons.StatutConsultation == StatutConsultation.EnCours))
        //        .FirstOrDefault();

        //    if(m�decinDisponible==null)

        //    // Si un m�decin disponible est trouv�, retourne l'UserID du m�decin s�lectionn�.
        //    if (m�decinDisponible != null)
        //    {
        //        return m�decinDisponible.UserID;
        //    }

        //    // Si aucun m�decin disponible n'est trouv�, retourne null 
        //    return null;
        //}



        public async Task<ListeAttenteVM> AppelerProchainPatient(int employeCliniqueID)
        {
            var consultation = await _context.Consultations.Where(x => x.StatutConsultation == StatutConsultation.EnAttente).FirstOrDefaultAsync();
            var employeClinique = await _context.EmployesClinique.FirstAsync(e => e.EmployeCliniqueID == employeCliniqueID);
            //var consultation = await _context.Consultations.FirstAsync(c => c.ConsultationID == prochaineConsultation.ConsultationID);
            if (consultation != null)
            {
                consultation.MedecinId = employeClinique.UserID;
                consultation.StatutConsultation = StatutConsultation.EnCours;
                consultation.HeureDateDebutReele = DateTime.Now;
                await _context.SaveChangesAsync();
                ListeAttenteVM nouvelleListeAttenteVM = await GetListeSalleAttenteOrdonnee(consultation.PlageHoraire.ListeAttenteID);
                return nouvelleListeAttenteVM;

            }

            return null;
        }



        //public async Task<ListeAttenteVM> AppelerProchainPatient(int consultaionID,int employeCliniqueID)
        //{
        //    // R�cup�re la consultation en fonction de l'ID pass� en param�tre.
        //    Consultation consultation = _context.Consultations.FirstOrDefault(c => c.ConsultationID == consultaionID);

        //    // V�rifie si une consultation a �t� trouv�e.
        //    if (consultation != null)
        //    {
        //        // V�rifie si la consultation est en attente.
        //        if (consultation.StatutConsultation == StatutConsultation.EnAttente)
        //        {
        //            // D�termine la logique pour s�lectionner le prochain m�decin disponible.
        //            //string nextAvailableDoctorId = D�terminerProchainM�decinDisponible();


        //            // V�rifie si un m�decin disponible a �t� trouv�.
        //            if (!string.IsNullOrEmpty(nextAvailableDoctorId))
        //            {
        //                // Met � jour le statut de la consultation pour la marquer comme en cours.
        //                consultation.StatutConsultation = StatutConsultation.EnCours;
        //                // Enregistre l'heure de d�but r�elle de la consultation � l'heure actuelle.
        //                consultation.HeureDateDebutReele = DateTime.Now;
        //                // Affecte l'ID du m�decin s�lectionn� � la consultation.
        //                consultation.MedecinId = nextAvailableDoctorId;

        //                // Enregistre les modifications dans la base de donn�es.
        //                await _context.SaveChangesAsync();

        //                // Obtient la liste d'attente mise � jour.
        //                ListeAttenteVM nouvelleListeAttenteVM = await GetListeSalleAttenteOrdonnee(consultation.PlageHoraire.ListeAttenteID);
        //                return nouvelleListeAttenteVM;
        //            }
        //        }
        //    }

        // Si aucune consultation n'a �t� trouv�e, si la consultation n'�tait pas en attente
        // ou si aucun m�decin disponible n'a �t� trouv�, retourne null.
        //    return null;
        //}

        public async Task<ListeAttenteVM> TerminerConsultationEtAppellerProchainPatient(int consultaionID, int employeCliniqueID, DetailsConsultation details)
        {
            // R�cup�re la consultation en fonction de l'ID pass� en param�tre.
            Consultation consultation = await _context.Consultations.FirstOrDefaultAsync(c => c.ConsultationID == consultaionID);

            // V�rifie si une consultation a �t� trouv�e.
            if (consultation != null)
            {
                // V�rifie si la consultation est en attente.
                if (consultation.StatutConsultation != StatutConsultation.EnCours)
                {
                    throw new ValidationException("Une erreure est survenue.");
                }
                // V�rifie si la consultation est en cours.
                else if (consultation.StatutConsultation == StatutConsultation.EnCours)
                {
                    // Enregistre l'heure de fin r�elle de la consultation � l'heure actuelle.
                    consultation.HeureDateFinReele = DateTime.Now;
                    // Met � jour le statut de la consultation pour la marquer comme termin�e.
                    consultation.StatutConsultation = StatutConsultation.Termine;

                    //_emailService.ConsultationCompleted(consultation.Patient);


                    // D�termine la logique pour s�lectionner le prochain m�decin disponible.
                    //string nextAvailableDoctorId = D�terminerProchainM�decinDisponible();

                    // V�rifie si un m�decin disponible a �t� trouv�.
                    //if (!string.IsNullOrEmpty(nextAvailableDoctorId))
                    //{

                    
                    // Associe le m�decin s�lectionn� � la consultation.
                    consultation.DetailsConsultation = details;
                    await _context.SaveChangesAsync();
                    //}
                }

                // Enregistre les modifications dans la base de donn�es (statut et heures de d�but/fin).


                // Obtient la liste d'attente mise � jour.
                //ListeAttenteVM nouvelleListeAttenteVM = await GetListeSalleAttenteOrdonnee(consultation.PlageHoraire.ListeAttenteID);
                //return nouvelleListeAttenteVM;
            }

            // Si aucune consultation n'a �t� trouv�e, retourne null.
            return null;
        }



        public async Task<ListeAttenteVM> TerminerConsultation(int consultaionID, DetailsConsultation details)
        {
            // R�cup�re la consultation en fonction de l'ID pass� en param�tre.
            Consultation consultation = await _context.Consultations.FirstOrDefaultAsync(c => c.ConsultationID == consultaionID);

            // V�rifie si une consultation a �t� trouv�e.
            if (consultation != null)
            {
                // V�rifie si la consultation est en cours.
                if (consultation.StatutConsultation == StatutConsultation.EnCours)
                {
                    // Met � jour le statut de la consultation pour la marquer comme termin�e.
                    consultation.StatutConsultation = StatutConsultation.Termine;
                    _emailService.ConsultationCompleted(consultation.Patient);
                    // Enregistre l'heure de fin r�elle de la consultation � l'heure actuelle.
                    consultation.HeureDateFinReele = DateTime.Now;

                    // Mettre à jour les détails de la consultation avec les données fournies.
                    consultation.DetailsConsultation = details;
                    // Enregistre les modifications dans la base de donn�es.
                    _context.Update(consultation);
                    await _context.SaveChangesAsync();

                    // Obtient la liste d'attente mise � jour.
                    ListeAttenteVM nouvelleListeAttenteVM = await GetListeSalleAttenteOrdonnee(consultation.PlageHoraire.ListeAttenteID);
                    return nouvelleListeAttenteVM;
                }
            }

            // Si aucune consultation n'a �t� trouv�e ou si la consultation n'�tait pas en cours, retourne null.
            return null;
        }

        public async Task AnnulerConsultationAsync(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            var consultation = await _context.Consultations.Where(c => c.PatientID == patient.PatientId && c.StatutConsultation == StatutConsultation.EnAttente).FirstOrDefaultAsync();
            if (consultation != null)
            {
                consultation.StatutConsultation = StatutConsultation.DisponiblePourReservation;
                _emailService.ConsultationCompleted(consultation.Patient);
                consultation.PatientID = null;
                ListeAttente listeAttente = await _context.ListeAttentes.Where(la => la.ListeAttenteID == consultation.PlageHoraire.ListeAttenteID).FirstOrDefaultAsync();
                if (listeAttente != null)
                {
                    listeAttente.IsOuverte = true;

                }
                await _context.SaveChangesAsync();
            }
        }


        public void AssignerCliniqueIDaListeAttente(ListeAttente listeAttente, int cliniqueID)
        {
            if (listeAttente != null && cliniqueID != null)
            {
                listeAttente.CliniqueID = cliniqueID;
            }
            else { }

            _context.SaveChanges();


        }
    }


}
