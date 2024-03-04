using Clinique2000_Core.Models;
using Clinique2000_Core.ViewModels;
using Clinique2000_MVC.Areas.Cliniques.Controllers;
using Clinique2000_MVC.Areas.Patients.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_TestsUnitaires
{
    public class CliniqueControllerTestsUnits
    {
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly Mock<IClinique2000Services> _servicesMock;

        private ApplicationUser _createur;
        private Adresse _adresse;
        private List<Clinique> _listeCliniques;

        private readonly CliniquesController _cliniqueControllerMock;

        public CliniqueControllerTestsUnits()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, null, null, null, null, null, null, null, null);
            _servicesMock = new Mock<IClinique2000Services>();

            _cliniqueControllerMock = new CliniquesController(
                                    _servicesMock.Object,
                                    _userManagerMock.Object
                                );

            _createur = new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df223",
                UserName = "bit@gmail.com",
                NormalizedUserName = "BIT@GMAIL.COM",
                Email = "c",
                NormalizedEmail = "BIT@GMAIL.COM",
                EmailConfirmed = true,
            };

            _adresse = new Adresse()
            {
                AdresseID = 1,
                Numero = "7B-568",
                Rue = "Rue",
                Ville = "Ville",
                Province = "QC",
                CodePostal = "A1A 1A1",
                Pays = "Canada"
            };

            _listeCliniques = new List<Clinique>()
            {
                new Clinique()
                {
                    CliniqueID = 1,
                    NomClinique = "CliniqueA",
                    Courriel = "test@clinique2000.com",
                    HeureOuverture = new TimeSpan(8, 0, 0),
                    HeureFermeture = new TimeSpan(17, 0, 0),
                    TempsMoyenConsultation = 30,
                    EstActive = true,
                    AdresseID = 1,
                    CreateurID = "7cc96785-8933-4eac-8d7f-a289b28df223",

                }
            };


        }

        /// <summary>
        /// Teste si l'action Index du contrôleur CliniquesController retourne un ViewResult avec une liste de cliniques.
        /// </summary>
        [Fact]
        public async Task Index_RenvoieUneViewResult_AvecUneListeDesCliniques()
        {
            // Arrange
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync(_listeCliniques);

            // Act
            var result = await _cliniqueControllerMock.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Clinique>>(viewResult.ViewData.Model);
            Assert.Equal(_listeCliniques, model);
            Assert.Equal(1, model.Count());
        }

        /// <summary>
        /// Teste si l'action Details (avec un id clinique valide) du contrôleur CliniquesController retourne un ViewResult.
        /// </summary>
        [Fact]
        public async Task Details_AvecValidId_RenvoieViewResult()
        {
            // Arrange
            int cliniqueId = 1;
            var expectedClinique = _listeCliniques.FirstOrDefault();
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync(_listeCliniques);
            _servicesMock.Setup(s => s.clinique.ObtenirParIdAsync(cliniqueId)).ReturnsAsync(expectedClinique);

            // Act
            var result = await _cliniqueControllerMock.Details(cliniqueId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Clinique>(viewResult.ViewData.Model);

            Assert.Equal(expectedClinique, model);
        }

        /// <summary>
        /// Teste si l'action Details (avec un id clinique invalide) du contrôleur CliniquesController retourne un NotFoundResult.
        /// </summary>
        [Fact]
        public async Task Details_AvecInvalidId_RenvoieNotFoundResult()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _cliniqueControllerMock.TempData = tempDataMock.Object;

            int? invalidClinicId = null;
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync(_listeCliniques);

            // Act
            var result = await _cliniqueControllerMock.Details(invalidClinicId);

            // Assert
            var notFoundResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", notFoundResult.ViewName);
        }

        /// <summary>
        /// Teste la méthode Create lorsque l'utilisateur est authentifié.
        /// Vérifie si elle renvoie un objet ViewResult contenant une instance de CliniqueAdresseVM.
        /// </summary>
        [Fact]
        public async Task Create_UserIsAuthenticated_RenvoieViewResult_AvecCliniqueAdresseVM()
        {
            // Arrange
            var userMock = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "bit@gmail.com")
            }, "mock"));

            _cliniqueControllerMock.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userMock }
            };

            _userManagerMock.Setup(um => um.FindByEmailAsync("bit@gmail.com")).ReturnsAsync(_createur);

            // Act
            var result = await _cliniqueControllerMock.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CliniqueAdresseVM>(viewResult.ViewData.Model);

            Assert.NotNull(model.Clinique);
            Assert.Equal(_createur.Id, model.Clinique.CreateurID);
        }

        /// <summary>
        /// Teste l'action Create lorsqu le modèle est valide.
        /// Vérifie si elle enregistre une clinique avec succès et redirige vers l'action "Details" avec l'identifiant de la clinique enregistrée.
        /// </summary>
        [Fact]
        public async Task Create_Post_ModelStateValid_EnregistreCliniqueEtRedirigeVersDetails()
        {
            // Arrange
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _cliniqueControllerMock.TempData = tempDataMock.Object;

            var viewModel = new CliniqueAdresseVM
            {
                Clinique = _listeCliniques.FirstOrDefault(),
                Adresse = _adresse
            };
            _servicesMock.Setup(s=>s.patient.GetUserAuthAsync()).ReturnsAsync(_createur);
            _servicesMock.Setup(s => s.clinique.EnregistrerCliniqueAsync(viewModel)).ReturnsAsync(new Clinique { CliniqueID = 1 });

            // Act
            var result = await _cliniqueControllerMock.Create(viewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal(1, redirectToActionResult.RouteValues["id"]);

            _servicesMock.Verify(s => s.clinique.EnregistrerCliniqueAsync(viewModel), Times.Once);

        }

        /// <summary>
        /// Teste la méthode Create en mode POST lorsque le modèle non valide.
        /// Vérifie si elle renvoie la vue avec le même modèle.
        /// </summary>
        [Fact]
        public async Task Create_PostModeWithInvalidModel_RenvoieVueAvecMemeModele()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _cliniqueControllerMock.TempData = tempDataMock.Object;

            var viewModel = new CliniqueAdresseVM
            {
                Clinique = _listeCliniques.FirstOrDefault(),
                Adresse = _adresse
            };

            _cliniqueControllerMock.ModelState.AddModelError("Erreur", "ModelStateInvalide");

            // Act
            var result = await _cliniqueControllerMock.Create(viewModel);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<CliniqueAdresseVM>(viewResult.ViewData.Model);
            Assert.Same(viewModel, model);

            _servicesMock.Verify(s => s.clinique.EnregistrerCliniqueAsync(It.IsAny<CliniqueAdresseVM>()), Times.Never);

        }

        /// <summary>
        /// Verifie si la méthode IndexPourPatients renvoie une vue vide lorsque la liste des cliniques est vide.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task IndexPourPatients_ReturnsUneVueVideSansCliniques()
        {
            // Arrange 
            var emptyCliniqueList = new List<Clinique>();
            _servicesMock.Setup(s => s.patient.UserAuthEstPatientAsync()).ReturnsAsync(true);
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync((List<Clinique>)null);

            // Act 
            var result = await _cliniqueControllerMock.IndexCliniquesAProximite();

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model);
        }

        /// <summary>
        /// Verifie si la méthode IndexPourPatients renvoie une vue avec les cliniques actives seulement.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task IndexPourPatients_RetourneLaVueApproprieeAvecCliniques()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _cliniqueControllerMock.TempData = tempDataMock.Object;

            var mockCliniqueList = new List<CliniqueDistanceVM>
            {
                new CliniqueDistanceVM
                {
                    Clinique = new Clinique { CliniqueID = 1, NomClinique = "Clinic1", EstActive = true },
                    Distance = 10.0 // Example distance
                },
                new CliniqueDistanceVM
                {
                    Clinique = new Clinique { CliniqueID = 2, NomClinique = "Clinic2", EstActive = true },
                    Distance = 20.0 // Example distance
                }
      
            };

            _servicesMock.Setup(s => s.patient.UserAuthEstPatientAsync()).ReturnsAsync(true);
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync(new List<Clinique>());
            _servicesMock.Setup(s => s.clinique.ObtenirLes5CliniquesLesPlusProches()).ReturnsAsync(mockCliniqueList);

            // Act
            var result = await _cliniqueControllerMock.IndexCliniquesAProximite();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CliniqueDistanceVM>>(viewResult.Model);

            Assert.Equal("IndexCliniquesAProximite", viewResult.ViewName);
            Assert.NotNull(model);
            Assert.Equal(mockCliniqueList.Count, model.Count());
        }


        [Fact]
        public async Task ListeAttentePourPatient_RetourneLaVueAppropriee()
        {
            // Arrange
            var clinicId = 1;
            var isOuvert = true;

            var listeAttenteData = new List<ListeAttente>
                {
                    new ListeAttente()                 
                  };

            _servicesMock.Setup(s => s.clinique.GetListeAttentePourPatientAsync(clinicId, isOuvert))
                               .ReturnsAsync(listeAttenteData);

            // Act
            var result = await _cliniqueControllerMock.ListeAttentePourPatient(clinicId, isOuvert);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("ListeAttentePourPatient", viewResult.ViewName);

            // Verificați dacă modelul este o listă de așteptare
            var model = Assert.IsAssignableFrom<IList<ListeAttente>>(viewResult.Model);
            Assert.Equal(listeAttenteData, model);

            // Verificați dacă ViewBag.CliniqueName este setat corespunzător
            Assert.Equal("ListeAttentePourPatient", viewResult.ViewName);
        }
    }
}