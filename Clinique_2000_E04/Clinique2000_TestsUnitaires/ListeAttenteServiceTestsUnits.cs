//using Clinique2000_Services.IServices;
//using Clinique2000_DataAccess.Data;
//using Clinique2000_Core.Models;
//using Microsoft.EntityFrameworkCore;
//using Clinique2000_Services.Services;
//using System.ComponentModel.DataAnnotations;
//using Clinique2000_Utility.Enum;
//using Google;
//using Moq;
//using Clinique2000_Core.ViewModels;

//namespace Clinique2000_TestsUnitaires
//{
//    public class ListeAttenteServiceTestsUnits
//    {

//        private readonly CliniqueDbContext dbTest;

//        public ListeAttenteServiceTestsUnits()
//        {
//            var options = SetUpInMemory("CliniqueTestDb");
//            dbTest = new CliniqueDbContext(options);
//            //seed les données
//            SeedInMemoryStore(dbTest);
//        }

//        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
//        {
//            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
//                .UseInMemoryDatabase(uniqueName).Options;
//            return options;
//        }

//        //Preparer des valeurs 
//        private void SeedInMemoryStore(CliniqueDbContext dbTest)
//        {
//            if (!dbTest.Cliniques.Any())
//            {
//                dbTest.Cliniques.AddRange(
//                    new Clinique
//                    {
//                        CliniqueID = 1,
//                        NomClinique = "Clinique A", // Added NomClinique
//                        Courriel = "cliniqueA@example.com", // Added Courriel
//                        CreateurID = "creator1", // Added CreateurID
//                        HeureOuverture = TimeSpan.FromHours(8),
//                        HeureFermeture = TimeSpan.FromHours(18), // Added HeureFermeture
//                        TempsMoyenConsultation = 30,
//                    },
//                    new Clinique
//                    {
//                        CliniqueID = 2,
//                        NomClinique = "Clinique B", // Added NomClinique
//                        Courriel = "cliniqueB@example.com", // Added Courriel
//                        CreateurID = "creator2", // Added CreateurID
//                        HeureOuverture = TimeSpan.FromHours(9), // Adjusted HeureOuverture
//                        HeureFermeture = TimeSpan.FromHours(17), // Adjusted HeureFermeture
//                        TempsMoyenConsultation = 20,
//                    },
//                    new Clinique
//                    {
//                        CliniqueID = 3,
//                        NomClinique = "Clinique C", // Added NomClinique
//                        Courriel = "cliniqueC@example.com", // Added Courriel
//                        CreateurID = "creator3", // Added CreateurID
//                        HeureOuverture = TimeSpan.FromHours(8),
//                        HeureFermeture = TimeSpan.FromHours(18), // Added HeureFermeture
//                        TempsMoyenConsultation = 30,
//                    }
//                );
//                dbTest.SaveChanges();
//            }

//            if (!dbTest.ListeAttentes.Any())
//            {
//                dbTest.ListeAttentes.AddRange(
//                    new ListeAttente { ListeAttenteID = 1, DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 },
//                    new ListeAttente { ListeAttenteID = 2, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 0, CliniqueID = 1 },
//                    new ListeAttente { ListeAttenteID = 3, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 3 },
//                    new ListeAttente { ListeAttenteID = 4, DateEffectivite = DateTime.Today.AddDays(1), HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 2 }
//                );
//                dbTest.SaveChanges();
//            }

//            if (!dbTest.PlagesHoraires.Any())
//            {
//                dbTest.PlagesHoraires.AddRange(
//                    new PlageHoraire { PlageHoraireID = 1,  HeureDebut = DateTime.Today.AddHours(8).AddMinutes(00), HeureFin = DateTime.Today.AddHours(8).AddMinutes(30), ListeAttenteID = 1 },
//                    new PlageHoraire { PlageHoraireID = 2,  HeureDebut = DateTime.Today.AddHours(8).AddMinutes(30), HeureFin = DateTime.Today.AddHours(9).AddMinutes(00), ListeAttenteID = 1 },
//                    new PlageHoraire { PlageHoraireID = 3,  HeureDebut = DateTime.Today.AddHours(9).AddMinutes(00), HeureFin = DateTime.Today.AddHours(9).AddMinutes(30), ListeAttenteID = 1 },
//                    new PlageHoraire { PlageHoraireID = 4,  HeureDebut = DateTime.Today.AddHours(9).AddMinutes(30), HeureFin = DateTime.Today.AddHours(10).AddMinutes(00), ListeAttenteID = 1 },
//                    new PlageHoraire { PlageHoraireID = 5, HeureDebut = DateTime.Today.AddHours(9).AddMinutes(00), HeureFin = DateTime.Today.AddHours(9).AddMinutes(30), ListeAttenteID = 3 },
//                    new PlageHoraire { PlageHoraireID = 6, HeureDebut = DateTime.Today.AddHours(9).AddMinutes(30), HeureFin = DateTime.Today.AddHours(10).AddMinutes(00), ListeAttenteID = 2}
//                );

//                dbTest.SaveChanges();
//            }

//            if ( !dbTest .Consultations.Any())
//            {
//                dbTest.Consultations.AddRange(
//                    new Consultation { ConsultationID=1, /*HeureDateDebutPrevue = DateTime.Today.AddHours(8).AddMinutes(00), HeureDateFinPrevue = DateTime.Today.AddHours(8).AddMinutes(30), */PlageHoraireID = 1 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=2, /*HeureDateDebutPrevue = DateTime.Today.AddHours(8).AddMinutes(00), HeureDateFinPrevue = DateTime.Today.AddHours(8).AddMinutes(30), */PlageHoraireID = 1 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=3, /*HeureDateDebutPrevue = DateTime.Today.AddHours(8).AddMinutes(30), HeureDateFinPrevue = DateTime.Today.AddHours(9).AddMinutes(00), */PlageHoraireID = 2 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=4, /*HeureDateDebutPrevue = DateTime.Today.AddHours(8).AddMinutes(30), HeureDateFinPrevue = DateTime.Today.AddHours(9).AddMinutes(00), */PlageHoraireID = 2 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=5, /*HeureDateDebutPrevue = DateTime.Today.AddHours(9).AddMinutes(00), HeureDateFinPrevue = DateTime.Today.AddHours(9).AddMinutes(30), */PlageHoraireID = 3 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=6, /*HeureDateDebutPrevue = DateTime.Today.AddHours(9).AddMinutes(00), HeureDateFinPrevue = DateTime.Today.AddHours(9).AddMinutes(30), */PlageHoraireID = 3 , StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=7, /*HeureDateDebutPrevue = DateTime.Today.AddHours(9).AddMinutes(30), HeureDateFinPrevue = DateTime.Today.AddHours(10).AddMinutes(00),*/ PlageHoraireID = 4, StatutConsultation=(StatutConsultation)6},
//                    new Consultation { ConsultationID=8, /*HeureDateDebutPrevue = DateTime.Today.AddHours(9).AddMinutes(30), HeureDateFinPrevue = DateTime.Today.AddHours(10).AddMinutes(00),*/ PlageHoraireID = 4, StatutConsultation=(StatutConsultation)6}

//             );
//                dbTest.SaveChanges();
//            }
//        }


//        [Fact]
//        public async Task GenererPlagesHorairesAsync_CreatesCorrectNumberofConsultation()
//        {
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            var listeAttente = await dbTest.ListeAttentes.FindAsync(1);

//            if (listeAttente == null)
//            {
//                throw new InvalidOperationException("ListeAttente not found.");
//            }
//            // Act
//            await service.GenererPlagesHorairesAsync(listeAttente.ListeAttenteID);

//            // Assert
//            var consultations = dbTest.PlagesHoraires.Count();
//            var expectedCount = 10; // You mentioned that you expect 4 consultations.
//            Assert.Equal(expectedCount, consultations);
//        }


//        [Fact]
//        public async Task GenererPlagesHorairesAsync_NoMedecinsDisponibles()
//        {
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            var listeAttente = dbTest.ListeAttentes.FirstOrDefault(l => l.ListeAttenteID == 2);

//            if (listeAttente == null)
//            {
//                throw new InvalidOperationException("ListeAttente not found.");
//            }
//            // Act
//            var exception = Assert.Throws<ValidationException>(() => service.VerifierSiNbMedecinsDisponibles(listeAttente));

//            // Assert
//            Assert.Equal("On doit avoir au moins un medecin disponible.", exception.Message);
//        }



//        [Fact]
//        public async Task GenererPlagesHorairesAsync_ListeDejaExistanteDansLaBD()
//        {
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(8), HeureFermeture = TimeSpan.FromHours(10), NbMedecinsDispo = 2, CliniqueID = 1 };
//            if (listeAttente == null)
//            {
//                throw new InvalidOperationException("ListeAttente not found.");
//            }

//            // Act
//            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiListeAttenteExisteMemeJourClinique(DateTime.Today, listeAttente.CliniqueID));

//            // Assert
//            Assert.Equal("Il existe deja une liste d'attente dans la meme clinique pour la meme date.", exception.Message);
//        }




//        [Fact]
//        public async Task GenererPlagesHorairesAsync_HeureOuvertureInvalide()
//        {
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today, HeureOuverture = TimeSpan.FromHours(10), HeureFermeture = TimeSpan.FromHours(9), NbMedecinsDispo = 2, CliniqueID = 1 };
//            if (listeAttente == null)
//            {
//                throw new InvalidOperationException("ListeAttente not found.");
//            }

//            // Act
//            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiHeureOuvertureValide(listeAttente));

//            // Assert
//            Assert.Equal("L'heure d'ouverture doit etre inferieure a l'heure de fermeture.", exception.Message);
//        }

//        [Fact]
//        public async Task GenererPlagesHorairesAsync_DateEffectiviteInvalide()
//        {
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            var listeAttente = new ListeAttente { DateEffectivite = DateTime.Today.AddDays(-1), HeureOuverture = TimeSpan.FromHours(10), HeureFermeture = TimeSpan.FromHours(9), NbMedecinsDispo = 2, CliniqueID = 1 };
//            if (listeAttente == null)
//            {
//                throw new InvalidOperationException("ListeAttente not found.");
//            }

//            // Act
//            ValidationException exception = Assert.Throws<ValidationException>(() => service.VerifierSiDateEffectiviteValide(listeAttente));

//            // Assert
//            Assert.Equal("La date d'effectivite n'est pas valide. Elle doit etre posterieure a la date actuelle.", exception.Message);
//        }



//        #region Filtrage des plages horaires 

//        [Fact]
//        public async Task GetListeAttenteOrdonnee_ListExists_ReturnsValidListeAttenteVM_AucuneReservation()
//        {
//            // Arrange
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            ListeAttenteVM listeattentevm_test = new ListeAttenteVM();
//            var listeattente = await dbTest.ListeAttentes.FindAsync(1);
//            if (listeattente == null)
//            {
//                throw new InvalidOperationException("listeattente not found.");
//            }
//            // On réserve 0 consultations 
//            foreach (var consultation in dbTest.Consultations)
//            {
//                consultation.StatutConsultation = (StatutConsultation)5;
//            }
//            dbTest.SaveChanges();
//            // Act
//            listeattentevm_test = await service.GetListeAttenteOrdonnee(listeattente.ListeAttenteID);
//            // Assert
//            var plageshorairesfiltrees = listeattentevm_test.PlagesHoraires.Count();
//            var expectedcount = 8; // Je m'attends à avoir 4 car aucune réservation.
//            Assert.Equal(expectedcount, plageshorairesfiltrees);
//        }
//        #endregion
//        [Fact]
//        public async Task GetListeAttenteOrdonnee_ValidListeAttenteID_ReturnsListeAttenteVM_WithConsultations()
//        {
//            // Arrange
//            IListeAttenteService service = new ListeAttenteService(dbTest);
//            ListeAttenteVM listeAttenteVM_test = new ListeAttenteVM();
//            var listeattente = await dbTest.ListeAttentes.FindAsync(1);
//            var plageHoraireID = 2;

//            var plagesHoraires = await dbTest.PlagesHoraires.ToListAsync();
//            var consultations = await dbTest.Consultations.ToListAsync();

//            // Filter PlagesHoraires based on consultations
//            //var plagesHorairesFiltrees = plagesHoraires
//            //    .Where(ph => consultations.Any(c => c.PlageHoraireID == ph.PlageHoraireID && c.StatutConsultation == (StatutConsultation)2))
//            //    .ToList();

//            var newConsultation = new Consultation
//            {
//                //HeureDateDebutPrevue = DateTime.Today.AddHours(8).AddMinutes(00),
//                //HeureDateFinPrevue = DateTime.Today.AddHours(8).AddMinutes(30),
//                PlageHoraireID = plageHoraireID,
//                StatutConsultation = StatutConsultation.EnCours
//            };

//            dbTest.Consultations.Add(newConsultation);
//            dbTest.SaveChanges();

//            // Act
//            listeAttenteVM_test = await service.GetListeAttenteOrdonnee(listeattente.ListeAttenteID);

//            // Assert
//            Assert.NotNull(listeAttenteVM_test);
//            Assert.NotNull(listeAttenteVM_test.ListeAttente);
//            Assert.NotNull(listeAttenteVM_test.PlagesHoraires);
//            Assert.NotEmpty(listeAttenteVM_test.PlagesHoraires);


//            var plageshorairesfiltrees = listeAttenteVM_test.PlagesHoraires.Count();
//            var expectedcount = 8;
//            Assert.Equal(expectedcount, plageshorairesfiltrees);
//        }


//    }
//}





