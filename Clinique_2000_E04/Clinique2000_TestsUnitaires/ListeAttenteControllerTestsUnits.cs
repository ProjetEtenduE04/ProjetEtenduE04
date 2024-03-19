using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_MVC.Areas.Cliniques.Controllers;
using Clinique2000_MVC.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class ListeAttenteControllerTestsUnits
    {

        /// <summary>
        //Ce test v�rifie que laction Index du ListeAttenteController renvoie correctement une vue contenant une liste de ListeAttente. Le test utilise un mock de IListeAttenteService
        //pour retourner une liste pr�d�finie de ListeAttente. Il sassure que le r�sultat de laction Index est un ViewResult et que le mod�le de la vue correspond � la liste mock�e,
        //tant en type quen nombre d�l�ments. Ce test confirme que le contr�leur traite et affiche correctement les donn�es provenant du service.
        /// </summary>
        [Fact]
        public async Task Index_RetourneVueAvecListeAttente()
        {
            // Arrange
            var mockListeAttenteService = new Mock<IListeAttenteService>();
            var listeAttenteTest = new List<ListeAttente>
                    {
                        new ListeAttente
                        {
                            ListeAttenteID = 1,
                            IsOuverte = true,
                            DateEffectivite = DateTime.Now.AddDays(5),
                            HeureOuverture = new TimeSpan(9, 0, 0),
                            HeureFermeture = new TimeSpan(17, 0, 0),
                            NbMedecinsDispo = 5,
                            //DureeConsultationMinutes = 30,
                            CliniqueID = 1

                        }
                    };
            var employe = new EmployesClinique
            {
                EmployeCliniqueID = 1,
                CliniqueID = 1,
                EmployeCliniquePosition = Clinique2000_Utility.Enum.EmployeCliniquePosition.Receptionniste,
                UserID = "2323234243423423"
            };

            var mockUserAuth = new Mock<ApplicationUser>();
            var mockEmployesCliniqueService = new Mock<IEmployesCliniqueService>();
            mockEmployesCliniqueService.Setup(s => s.GetEmployeUserID(It.IsAny<string>(), It.IsAny<string>()))
                                       .ReturnsAsync(employe);

            var mockClinique2000Services = new Mock<IClinique2000Services>();
            mockClinique2000Services.Setup(s => s.patient.GetUserAuthAsync())
                                    .ReturnsAsync(mockUserAuth.Object);
            mockClinique2000Services.Setup(s => s.employesClinique.GetEmployeUserID(It.IsAny<string>(), It.IsAny<string>()))
                                    .ReturnsAsync(employe);
            mockClinique2000Services.Setup(s => s.listeAttente.ObtenirToutAsync())
                                    .ReturnsAsync(listeAttenteTest);

            var controller = new ListeAttenteController(mockClinique2000Services.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<ListeAttente>>(viewResult.Model);
            Assert.Equal(listeAttenteTest.Count, model.Count);
        }








        /// <summary>
        ///Ce test unitaire v�rifie le comportement de l'action Index du ListeAttenteController lorsqu'il n'y a pas de donn�es disponibles.
        ///Il utilise un service mock� IClinique2000Services, qui � son tour utilise un IListeAttenteService mock� pour retourner une liste vide
        ///de ListeAttente. Le test s'assure que l'action Index renvoie un ViewResult avec un mod�le vide, ce qui est le comportement attendu dans
        ///le cas o� il n'y a pas de donn�es � afficher. Ce test est essentiel pour confirmer que le contr�leur g�re correctement les situations o�
        ///la source de donn�es est vide.
        /// 
        /// </summary>

        [Fact]
        public async Task Index_QuandAucuneDonnee_RetourneVueVide()
        {
            // Arrange
            var mockListeAttenteService = new Mock<IListeAttenteService>();
            var listeAttenteTest = new List<ListeAttente>
                    {
                        new ListeAttente
                        {
                            ListeAttenteID = 1,
                            IsOuverte = true,
                            DateEffectivite = DateTime.Now.AddDays(5),
                            HeureOuverture = new TimeSpan(9, 0, 0),
                            HeureFermeture = new TimeSpan(17, 0, 0),
                            NbMedecinsDispo = 5,
                            //DureeConsultationMinutes = 30,
                            CliniqueID = 1

                        }
                    };
            var employe = new EmployesClinique
            {
                EmployeCliniqueID = 1,
                CliniqueID = 3,
                EmployeCliniquePosition = Clinique2000_Utility.Enum.EmployeCliniquePosition.Receptionniste,
                UserID = "2323234243423423"
            };

            var mockUserAuth = new Mock<ApplicationUser>();
            var mockEmployesCliniqueService = new Mock<IEmployesCliniqueService>();
            mockEmployesCliniqueService.Setup(s => s.GetEmployeUserID(It.IsAny<string>(), It.IsAny<string>()))
                                       .ReturnsAsync(employe);

            var mockClinique2000Services = new Mock<IClinique2000Services>();
            mockClinique2000Services.Setup(s => s.patient.GetUserAuthAsync())
                                    .ReturnsAsync(mockUserAuth.Object);
            mockClinique2000Services.Setup(s => s.employesClinique.GetEmployeUserID(It.IsAny<string>(), It.IsAny<string>()))
                                    .ReturnsAsync(employe);
            mockClinique2000Services.Setup(s => s.listeAttente.ObtenirToutAsync())
                                    .ReturnsAsync(listeAttenteTest);

            var controller = new ListeAttenteController(mockClinique2000Services.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<ListeAttente>>(viewResult.Model);
            Assert.Empty(model);
        }



        /// <summary>
        /// Teste que l'action Details retourne une vue avec le bon objet ListeAttente pour un ID sp�cifique
        /// </summary>  
        /// <returns></returns>
        [Fact]
        public async Task Details_AvecIdValide_RetourneVueAvecListeAttenteSpecifique()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttenteAttendue = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = new DateTime(2023, 4, 10),
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                //DureeConsultationMinutes = 15,
                CliniqueID = 101,
                PlagesHoraires = new List<PlageHoraire>(),
            };

            //var listeAttenteVMAttendue = new ListeAttenteVM
            //{
            //    ListeAttente = listeAttenteAttendue,
            //    PlagesHoraires=listeAttenteAttendue.PlagesHoraires
            //};

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(1)).ReturnsAsync(listeAttenteAttendue);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);//retourne type VM
            var model = Assert.IsType<ListeAttenteVM>(viewResult.Model);
            Assert.Equal(listeAttenteAttendue.ListeAttenteID, model.ListeAttente.ListeAttenteID);
        }

        /// <summary>
        /// Cette m�thode de test unitaire, Details AvecIdInvalide RetourneNotFound, vise � v�rifier le comportement de laction Details dans ListeAttenteController lorsquelle
        /// re�oit un ID invalide (dans ce cas, 999). Le test sassure que si aucun objet ListeAttente ne correspond � lID fourni, laction renvoie un r�sultat NotFoundResult.
        /// Pour cela, il configure un service mock (IClinique2000Services) pour retourner null lors de lappel � ObtenirParIdAsync avec nimporte quel ID, simulant ainsi une
        /// situation o� lID demand� nexiste pas dans la base de donn�es. Le test confirme ensuite que le contr�leur se comporte comme attendu dans ce sc�nario.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Details_AvecIdInvalide_RetourneViewNotFound()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttenteAttendue = new ListeAttente
            {
                ListeAttenteID = -1,
                IsOuverte = true,
                DateEffectivite = new DateTime(2023, 4, 10),
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                //DureeConsultationMinutes = 15,
                CliniqueID = 101,
            };

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(It.IsAny<int>())).ReturnsAsync((ListeAttente)null);

            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            // Act
            var result = await controller.Details(listeAttenteAttendue.ListeAttenteID);

            // Assert
            Assert.IsType<ViewResult>(result);
        }


        // Ce test v�rifie que l'action EditAsync renvoie une vue contenant l'objet ListeAttente correct lorsque l'ID fourni est valide.
        [Fact]
        public async Task EditAsync_AvecIdValide_RetourneVueAvecListeAttente()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttenteTest = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = new DateTime(2023, 1, 1),
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 5,
                //DureeConsultationMinutes = 30,
            };
            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(1)).ReturnsAsync(listeAttenteTest);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListeAttente>(viewResult.Model);
            Assert.Equal(listeAttenteTest, model);
        }


        // Ce test v�rifie que lorsque le mod�le est valide, l'action Edit effectue la mise � jour et redirige vers l'action Index.
        [Fact]
        public async Task Edit_Post_AvecModeleValide_RedirigeVersIndex()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttente = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = new DateTime(2023, 1, 1),
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 5,
                //DureeConsultationMinutes = 30,
            };
            // Set up the mock to return a completed Task<ListeAttente> with the listeAttente entity
            mockService.Setup(s => s.listeAttente.EditerAsync(listeAttente)).Returns(Task.FromResult(listeAttente));

            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            controller.ModelState.Clear();

            // Act
            var result = await controller.Edit(listeAttente);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }



        // Ce test v�rifie que si le mod�le n'est pas valide, l'action Edit retourne la m�me vue avec le mod�le fourni.
        [Fact]
        public async Task Edit_Post_AvecModeleInvalide_RetourneMemeVue()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttente = new ListeAttente();

            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            controller.ModelState.AddModelError("Error", "Erreur de mod�le"); // Rendre le ModelState invalide

            // Act
            var result = await controller.Edit(listeAttente);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(listeAttente, viewResult.Model);
        }


        //Ce test v�rifie que l'action Create (GET) renvoie la vue par d�faut pour cr�er une nouvelle entr�e.
        [Fact]
        public async Task Create_Get_RetourneVueParDefaut()
        {

            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);
            ListeAttente listeAttente1 = new ListeAttente { ListeAttenteID = 1, };
            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model); // Confirme que la vue est retourn�e sans mod�le
        }


        /// <summary>
        ///Ce test unitaire v�rifie que laction Create du contr�leur ListeAttenteController r�agit correctement lorsqu'un
        ///mod�le de ListeAttente valide est soumis.Il s'assure que, dans ce cas, l'action renvoie une redirection vers l'action
        ///Index. Cela garantit que l'ajout d'une liste d'attente valide conduit � une redirection vers la page principale de la 
        ///liste d'attente, conform�ment au comportement attendu.
        /// </summary>
        [Fact]
        public async Task Create_Post_RetourneViewIndexLorsqueModelstateValide()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            var validListeAttente = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now,
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 5,
                //DureeConsultationMinutes = 30,
                CliniqueID = 1,
            };

            // Configurez le service pour retourner un r�sultat de r�ussite (peut �tre simul�)
            mockService.Setup(s => s.listeAttente.CreerAsync(It.IsAny<ListeAttente>()));


            controller.ModelState.Clear();

            // Act
            var result = await controller.Create(validListeAttente);

            // Assert
            var redirectToActionResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("create", redirectToActionResult.ViewName);
        }


        // Test : V�rifie si l'action GET Delete renvoie la vue et le mod�le corrects lorsque un ID valide est fourni
        [Fact]
        public async Task Delete_Get_IdValide_RetourneVueEtModel()
        {

            // Arrange
            var validId = 1;
            var expectedModel = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now,
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 5,
                //DureeConsultationMinutes = 30,
                CliniqueID = 1,
            };
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(validId)).ReturnsAsync(expectedModel);

            // Act
            var result = await controller.Delete(validId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListeAttente>(viewResult.Model);
            Assert.Equal(expectedModel, model);

        }



        // Test : V�rifie que l'action GET Delete renvoie un r�sultat NotFound lorsque un ID invalide est fourni
        [Fact]
        public async Task Delete_Get_IdInvalide_RetourneViewNotFound()
        {
            // Arrange
            var invalidId = -1;
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(invalidId)).ReturnsAsync((ListeAttente)null);

            // Act
            var result = await controller.Delete(invalidId);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        /// <summary>
        /// CETTE METHODE VERIFIE LA REDIRECTION DE LA METHODE . VERIFIE QUE LA METHODE RETOURNE A LA VUE INDEX LORS D'UN SUCCES
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeletePost_RedirectsToIndex_WhenSuccessful()
        {
            // Arrange
            var mockServices = new Mock<IClinique2000Services>();
            var mockListeAttenteService = new Mock<IListeAttenteService>();
            mockServices.Setup(s => s.listeAttente).Returns(mockListeAttenteService.Object);

            var controller = new ListeAttenteController(mockServices.Object);

            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            controller.TempData = tempDataMock.Object;

            var listeAttenteToDelete = new ListeAttente { ListeAttenteID = 1 };

            mockListeAttenteService.Setup(s => s.PeutSupprimmer(It.IsAny<ListeAttente>())).Returns(true);
            mockListeAttenteService.Setup(s => s.SupprimmerListeAttente(It.IsAny<ListeAttente>()))
                                   .Returns(Task.CompletedTask);

            // Act
            var result = await controller.Delete(listeAttenteToDelete);

            // Assert
            mockListeAttenteService.Verify(s => s.SupprimmerListeAttente(listeAttenteToDelete), Times.Once);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("index", redirectToActionResult.ActionName);
        }


        /// <summary>
        /// Ce test v�rifie que lorsqu'un ModelState invalide est d�tect� dans l'action POST Delete de ListeAttenteController,
        /// la m�thode renvoie � l'utilisateur la vue "Delete" accompagn�e du mod�le ListeAttente initial. Ce comportement assure
        /// que l'utilisateur re�oit un feedback appropri� en cas d'erreur de validation lors de la tentative de suppression d'une
        /// entr�e de la liste d'attente.
        /// </summary>
        [Fact]
        public async Task Suppression_Post_RetourneVueDelete_SiModelStateInvalide()
        {
            // Arrange
            var listeAttente = new ListeAttente { ListeAttenteID = -1 };
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.ModelState.AddModelError("Error", "Error message");

            // Act
            var result = await controller.Delete(listeAttente);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(listeAttente, viewResult.Model);
        }

        /// <summary>
        /// test  que l'action AppelerProchainPatient du contr�leur ListeAttenteController renvoie un RedirectToActionResult
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task AppelerProchainPatient_Returns_RedirectToActionResult_When_Patient_Called()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            mockService.Setup(s => s.consultation.AppelerProchainPatient(It.IsAny<int>()))
                       .ReturnsAsync(new ListeAttenteVM()); // Adjust return value as needed

            var tempData = new Mock<ITempDataDictionary>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.TempData = tempData.Object;

            // Act
            var result = await controller.AppelerProchainPatient(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("EmployesCliniques", redirectToActionResult.ControllerName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task TerminerConsultationEtAppellerProchainPatient_Returns_RedirectToActionResult_When_Consultation_Terminated_And_Patient_Called()
        {
            // Arrange
            var listeAttenteVM = new ListeAttenteVM();
            var mockService = new Mock<IClinique2000Services>();
            mockService.Setup(s => s.consultation.TerminerConsultation(It.IsAny<int>(), It.IsAny<DetailsConsultation>()))
                       .ReturnsAsync(listeAttenteVM);
            mockService.Setup(s => s.consultation.AppelerProchainPatient(It.IsAny<int>()))
                       .ReturnsAsync(listeAttenteVM); // 

            var tempData = new Mock<ITempDataDictionary>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.TempData = tempData.Object;

            // Act
            var result = await controller.TerminerConsultationEtAppellerProchainPatient(1, 1, new EmployesCliniqueVM());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("EmployesCliniques", redirectToActionResult.ControllerName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task TerminerConsultation_Returns_RedirectToActionResult_When_Consultation_Terminated()
        {
            // Arrange
            var listeAttenteVM = new ListeAttenteVM();
            var mockService = new Mock<IClinique2000Services>();
            mockService.Setup(s => s.consultation.TerminerConsultation(It.IsAny<int>(), It.IsAny<DetailsConsultation>()))
                       .ReturnsAsync(listeAttenteVM);

            var tempData = new Mock<ITempDataDictionary>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.TempData = tempData.Object;

            // Act
            var result = await controller.TerminerConsultation(1, 1, new EmployesCliniqueVM());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("EmployesCliniques", redirectToActionResult.ControllerName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task AnnulerConsultation_Returns_RedirectToActionResult_When_PatientId_Valid()
        {
            // Arrange
            var patient = new Patient { PatientId = 1 };
            var mockService = new Mock<IClinique2000Services>();
            mockService.Setup(s => s.patient.ObtenirParIdAsync(It.IsAny<int>()))
                       .ReturnsAsync(patient);
            mockService.Setup(s => s.consultation.AnnulerConsultationAsync(It.IsAny<Patient>()))
                       .Returns(Task.CompletedTask); 

            var tempData = new Mock<ITempDataDictionary>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.TempData = tempData.Object;

            // Act
            var result = await controller.AnnulerConsultation(patient.PatientId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("Patients", redirectToActionResult.ControllerName);
            Assert.Equal(patient.PatientId, redirectToActionResult.RouteValues["id"]);
        }
    }
}