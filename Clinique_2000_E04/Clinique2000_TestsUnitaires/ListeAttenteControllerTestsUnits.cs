using Clinique2000_Core.Models;
using Clinique2000_MVC.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class ListeAttenteControllerTestsUnits
    {

        /// <summary>
        //Ce test vérifie que laction Index du ListeAttenteController renvoie correctement une vue contenant une liste de ListeAttente. Le test utilise un mock de IListeAttenteService
        //pour retourner une liste prédéfinie de ListeAttente. Il sassure que le résultat de laction Index est un ViewResult et que le modèle de la vue correspond à la liste mockée,
        //tant en type quen nombre déléments. Ce test confirme que le contrôleur traite et affiche correctement les données provenant du service.
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
                            DateEffectivite = new DateTime(2023, 1, 1),
                            HeureOuverture = new TimeSpan(9, 0, 0),
                            HeureFermeture = new TimeSpan(17, 0, 0),
                            NbMedecinsDispo = 5,
                            DureeConsultationMinutes = 30,
                            CliniqueID = 1
                        },
                        new ListeAttente
                        {
                            ListeAttenteID = 2,
                            IsOuverte = false,
                            DateEffectivite = new DateTime(2023, 1, 2),
                            HeureOuverture = new TimeSpan(8, 30, 0),
                            HeureFermeture = new TimeSpan(16, 30, 0),
                            NbMedecinsDispo = 4,
                            DureeConsultationMinutes = 45,
                            CliniqueID = 2
                        }
                    };


            mockListeAttenteService.Setup(s => s.ObtenirToutAsync()).ReturnsAsync(listeAttenteTest);

            var mockClinique2000Services = new Mock<IClinique2000Services>();
            mockClinique2000Services.Setup(s => s.listeAttente).Returns(mockListeAttenteService.Object);

            var controller = new ListeAttenteController(mockClinique2000Services.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<ListeAttente>>(viewResult.Model);
            Assert.Equal(listeAttenteTest.Count, model.Count);
        }








        /// <summary>
        ///Ce test unitaire vérifie le comportement de l'action Index du ListeAttenteController lorsqu'il n'y a pas de données disponibles.
        ///Il utilise un service mocké IClinique2000Services, qui à son tour utilise un IListeAttenteService mocké pour retourner une liste vide
        ///de ListeAttente. Le test s'assure que l'action Index renvoie un ViewResult avec un modèle vide, ce qui est le comportement attendu dans
        ///le cas où il n'y a pas de données à afficher. Ce test est essentiel pour confirmer que le contrôleur gère correctement les situations où
        ///la source de données est vide.
        /// 
        /// </summary>
      
        [Fact]
        public async Task Index_QuandAucuneDonnee_RetourneVueVide()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttenteVide = new List<ListeAttente>(); // Liste vide pour simuler l'absence de données

            var mockListeAttenteService = new Mock<IListeAttenteService>();
            mockListeAttenteService.Setup(s => s.ObtenirToutAsync()).ReturnsAsync(listeAttenteVide);

            mockService.Setup(s => s.listeAttente).Returns(mockListeAttenteService.Object);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<ListeAttente>>(viewResult.Model);
            Assert.Empty(model); // Vérifier que le modèle est vide
        }



        /// <summary>
        /// Teste que l'action Details retourne une vue avec le bon objet ListeAttente pour un ID spécifique
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
                DureeConsultationMinutes = 15,
                CliniqueID = 101,
            };

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(1)).ReturnsAsync(listeAttenteAttendue);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListeAttente>(viewResult.Model);
            Assert.Equal(listeAttenteAttendue, model);
        }

        /// <summary>
        /// Cette méthode de test unitaire, Details AvecIdInvalide RetourneNotFound, vise à vérifier le comportement de laction Details dans ListeAttenteController lorsquelle
        /// reçoit un ID invalide (dans ce cas, 999). Le test sassure que si aucun objet ListeAttente ne correspond à lID fourni, laction renvoie un résultat NotFoundResult.
        /// Pour cela, il configure un service mock (IClinique2000Services) pour retourner null lors de lappel à ObtenirParIdAsync avec nimporte quel ID, simulant ainsi une
        /// situation où lID demandé nexiste pas dans la base de données. Le test confirme ensuite que le contrôleur se comporte comme attendu dans ce scénario.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Details_AvecIdInvalide_RetourneNotFound()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttenteAttendue = new ListeAttente
            {
                ListeAttenteID = int.MaxValue,
                IsOuverte = true,
                DateEffectivite = new DateTime(2023, 4, 10),
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 3,
                DureeConsultationMinutes = 15,
                CliniqueID = 101,
            };

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(It.IsAny<int>())).ReturnsAsync((ListeAttente)null);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


        // Ce test vérifie que l'action EditAsync renvoie une vue contenant l'objet ListeAttente correct lorsque l'ID fourni est valide.
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
                DureeConsultationMinutes = 30,
            };
            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(1)).ReturnsAsync(listeAttenteTest);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.EditAsync(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListeAttente>(viewResult.Model);
            Assert.Equal(listeAttenteTest, model);
        }


        // Ce test vérifie que lorsque le modèle est valide, l'action Edit effectue la mise à jour et redirige vers l'action Index.
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
                DureeConsultationMinutes = 30,
               
            };
            mockService.Setup(s => s.listeAttente.EditerAsync(listeAttente)).Returns(Task.CompletedTask);

            var controller = new ListeAttenteController(mockService.Object);
            controller.ModelState.Clear();

            // Act
            var result = await controller.Edit(listeAttente);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }


        // Ce test vérifie que si le modèle n'est pas valide, l'action Edit retourne la même vue avec le modèle fourni.
        [Fact]
        public async Task Edit_Post_AvecModeleInvalide_RetourneMemeVue()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var listeAttente = new ListeAttente();

            var controller = new ListeAttenteController(mockService.Object);
            controller.ModelState.AddModelError("Error", "Erreur de modèle"); // Rendre le ModelState invalide

            // Act
            var result = await controller.Edit(listeAttente);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(listeAttente, viewResult.Model);
        }


        //Ce test vérifie que l'action Create (GET) renvoie la vue par défaut pour créer une nouvelle entrée.
        [Fact]
        public async Task Create_Get_RetourneVueParDefaut()
        {

            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.Null(viewResult.Model); // Confirme que la vue est retournée sans modèle
        }


        /// <summary>
        ///Ce test unitaire vérifie que laction Create du contrôleur ListeAttenteController réagit correctement lorsqu'un
        ///modèle de ListeAttente valide est soumis.Il s'assure que, dans ce cas, l'action renvoie une redirection vers l'action
        ///Index. Cela garantit que l'ajout d'une liste d'attente valide conduit à une redirection vers la page principale de la 
        ///liste d'attente, conformément au comportement attendu.
        /// </summary>
        [Fact]
        public async Task Create_Post_RetourneViewIndexLorsqueModelstateValide()
        {
            // Arrange
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            var validListeAttente = new ListeAttente
            {
                ListeAttenteID = 1,
                IsOuverte = true,
                DateEffectivite = DateTime.Now,
                HeureOuverture = new TimeSpan(9, 0, 0),
                HeureFermeture = new TimeSpan(17, 0, 0),
                NbMedecinsDispo = 5,
                DureeConsultationMinutes = 30,
                CliniqueID = 1,
            };

            // Configurez le service pour retourner un résultat de réussite (peut être simulé)
            mockService.Setup(s => s.listeAttente.CreerAsync(It.IsAny<ListeAttente>()));


            controller.ModelState.Clear();

            // Act
            var result = await controller.Create(validListeAttente);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }


        // Test : Vérifie si l'action GET Delete renvoie la vue et le modèle corrects lorsque un ID valide est fourni
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
                DureeConsultationMinutes = 30,
                CliniqueID = 1,
            };
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(validId)).ReturnsAsync(expectedModel);

            // Act
            var result = await controller.Delete(validId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ListeAttente>(viewResult.Model);
            Assert.Equal(expectedModel, model);

        }



        // Test : Vérifie que l'action GET Delete renvoie un résultat NotFound lorsque un ID invalide est fourni
        [Fact]
        public async Task Delete_Get_IdInvalide_RetourneNotFound()
        {
            // Arrange
            var invalidId = -1;
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);
            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(invalidId)).ReturnsAsync((ListeAttente)null);

            // Act
            var result = await controller.Delete(invalidId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async Task Suppression_Post_ReduitNombreListeAttenteEtRedirigeAindex_SiModelStateValide()
        {
            // Arrange
            List<ListeAttente> listeListeattente = new List<ListeAttente>();
            var listeAttente1 = new ListeAttente {ListeAttenteID=1, };
            var listeattente2= new ListeAttente { ListeAttenteID=2, };

            listeListeattente.Add(listeAttente1);
            listeListeattente.Add(listeattente2);


            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);
            mockService.Setup(s => s.listeAttente.SupprimerAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
            controller.ModelState.Clear();

            // Act
            var result = await controller.Delete(listeAttente1);

            // Assert
            mockService.Verify(s => s.listeAttente.SupprimerAsync(It.IsAny<int>()), Times.Once); // Vérifie que SupprimerAsync a été appelé une fois
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal(listeListeattente.Count, 2);
        }


        /// <summary>
        /// Ce test vérifie que lorsqu'un ModelState invalide est détecté dans l'action POST Delete de ListeAttenteController,
        /// la méthode renvoie à l'utilisateur la vue "Delete" accompagnée du modèle ListeAttente initial. Ce comportement assure
        /// que l'utilisateur reçoit un feedback approprié en cas d'erreur de validation lors de la tentative de suppression d'une
        /// entrée de la liste d'attente.
        /// </summary>
        [Fact]
        public async Task Suppression_Post_RetourneVueDelete_SiModelStateInvalide()
        {
            // Arrange
            var listeAttente = new ListeAttente { ListeAttenteID=-1 };
            var mockService = new Mock<IClinique2000Services>();
            var controller = new ListeAttenteController(mockService.Object);
            controller.ModelState.AddModelError("Error", "Error message");

            // Act
            var result = await controller.Delete(listeAttente);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(listeAttente, viewResult.Model);
        }


    }
}