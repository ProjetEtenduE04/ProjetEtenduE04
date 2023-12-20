using Clinique2000_Core.Models;
using Clinique2000_MVC.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
                            dureeConsultationMinutes = 30,
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
                            dureeConsultationMinutes = 45,
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
                dureeConsultationMinutes = 15,
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
                dureeConsultationMinutes = 15,
                CliniqueID = 101,
            };

            mockService.Setup(s => s.listeAttente.ObtenirParIdAsync(It.IsAny<int>())).ReturnsAsync((ListeAttente)null);

            var controller = new ListeAttenteController(mockService.Object);

            // Act
            var result = await controller.Details(999); // Utiliser un ID qui n'existe probablement pas

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


    }
}