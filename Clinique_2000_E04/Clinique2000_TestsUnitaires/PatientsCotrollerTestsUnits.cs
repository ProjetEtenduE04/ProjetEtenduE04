using Clinique2000_Core.Models;
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
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_TestsUnitaires
{
    public class PatientsCotrollerTestsUnits
    {

        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly Mock<IClinique2000Services> _servicesMock;

        private List<Patient> _patientsList;
        private readonly PatientsController _patientsController;

        public PatientsCotrollerTestsUnits()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, null, null, null, null, null, null, null, null);
            _servicesMock = new Mock<IClinique2000Services>();

            _patientsController = new PatientsController(
                                    _servicesMock.Object,
                                    _userManagerMock.Object
                                );

            _patientsList = new List<Patient>()
            {
                new Patient()
                {
                    PatientId = 1,
                    Nom = "Smith",
                    Prenom = "Jhon",
                    NAM = "SMIJ12345678",
                    CodePostal = "A1A 1A1",
                    DateDeNaissance = new DateTime(2001, 05, 04),
                    UserId = "4eaffcbd-4351-4995-a0c0-03624a3743c7"

                }
            };
        }

        /// <summary>
        ///  Teste si la méthode Create renvoie une vue avec le modèle lorsque l'utilisateur n'est pas un patient.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Create_ReturnViewAvecModel_LorsqueUser_NestPasPatient()
        {
            // Arrange
            var userMock = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "test@example.com")
            }, "mock"));

            _patientsController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userMock }
            };

            var user = new ApplicationUser
            {
                Id = "1",
            };
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            _userManagerMock.Setup(manager => manager.FindByEmailAsync("test@example.com")).ReturnsAsync(user);
            _servicesMock.Setup(service => service.patient.UserEstPatientAsync(user.Id)).ReturnsAsync(false);

            // Act
            var result = await _patientsController.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Patient>(viewResult.Model);
        }

        /// <summary>
        /// Teste si la méthode Create renvoie une redirection vers l'action "Index" du contrôleur "Home"
        /// lorsque l'utilisateur est un patient.
        /// <returns></returns>
        [Fact]
        public async Task Create_ReturnsRedirectVersIndex_LorsqueUserEstPatient()
        {
            // Arrange
            var userMock = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "test@example.com")
            }, "mock"));

            _patientsController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userMock }
            };

            var user = new ApplicationUser
            {
                Id = "1",
            };

            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            _userManagerMock.Setup(manager => manager.FindByEmailAsync("test@example.com")).ReturnsAsync(user);
            _servicesMock.Setup(service => service.patient.UserEstPatientAsync(user.Id)).ReturnsAsync(true);
            _servicesMock.Setup(service => service.patient.GetPatientParUserIdAsync(user.Id)).ReturnsAsync(_patientsList.FirstOrDefault());

            // Act
            var result = await _patientsController.Create();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", redirectToActionResult.ActionName);
            Assert.Equal("Patients", redirectToActionResult.ControllerName);
        }

        /// <summary>
        /// Teste le comportement de l'action Create lorsque le modèle est valide.
        /// Vérifie si la méthode Create redirige vers l'action Index lorsque le modèle est valide.
        /// </summary>
        [Fact]
        public async Task Create_Post_ModelStateValid_RedirectsVersIndex()
        {
            // Arrange
            var patientValide = _patientsList.FirstOrDefault();
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            _servicesMock.Setup(service => service.patient.EnregistrerOuModifierPatient(patientValide)).ReturnsAsync(patientValide);

            // Act
            var result = await _patientsController.Create(patientValide);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        /// <summary>
        /// Teste le comportement de l'action Create lorsqu'un modèle invalide est soumis.
        /// Vérifie si la méthode Create renvoie une vue lorsque le modèle est invalide.
        /// </summary>
        [Fact]
        public async Task Create_Post_ModelStateInvalid_ReturnsView()
        {
            // Arrange
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            var patientInvalid = _patientsList.FirstOrDefault();
            patientInvalid.DateDeNaissance = DateTime.Now;

            _patientsController.ModelState.AddModelError("Error", "Model State est invalide");


            // Act
            var result = await _patientsController.Create(patientInvalid);


            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(patientInvalid, viewResult.Model);
        }

        /// <summary>
        /// Teste si la méthode Index renvoie une vue avec le modèle de type IEnumerable<Patient>.
        /// </summary>
        [Fact]
        public async Task Index_ReturnsViewAvecModelPatient()
        {
            // Arrange
            _servicesMock.Setup(service => service.patient.ObtenirToutAsync()).ReturnsAsync(_patientsList);

            // Act
            var result = await _patientsController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Patient>>(viewResult.Model);
            Assert.Equal(_patientsList, model);
        }

        /// <summary>
        /// Teste si la méthode Edit (GET) renvoie une vue avec le modèle de type Patient.
        /// </summary>
        [Fact]
        public async Task Edit_Get_Returns_ViewAvecPatient()
        {
            // Arrange
            int id = 1;
            var patient = _patientsList.FirstOrDefault();
            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(id)).ReturnsAsync(patient);
            _servicesMock.Setup(service => service.patient.ObtenirToutAsync()).ReturnsAsync(_patientsList);
            // Act
            var result = await _patientsController.Edit(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Patient>(viewResult.Model);
            Assert.Equal(id, model.PatientId);
            Assert.Equal(_patientsList.FirstOrDefault(), model);
        }

        /// <summary>
        /// Teste si la méthode Edit (GET) renvoie NotFound lorsque l'identifiant est null.
        /// </summary>
        [Fact]
        public async Task Edit_Get_ReturnsNotFound_LorsqueIdNull()
        {
            // Arrange
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;
            // Act
            var result = await _patientsController.Edit(null);

            // Assert
            var notFoundResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", notFoundResult.ViewName);
        }

        /// <summary>
        /// Teste si la méthode Edit renvoie NotFound lorsque le patient est null.
        /// </summary>
        [Fact]
        public async Task Edit_ReturnNotFound_Lorsque_PatientEstNull()
        {
            // Arrange
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            int id = 1;
            var patient = _patientsList.FirstOrDefault();
            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(id)).ReturnsAsync((Patient)null);

            // Act
            var result = await _patientsController.Edit(id);

            // Assert
            var notFoundResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", notFoundResult.ViewName);
        }

        /// <summary>
        /// Teste si la méthode Edit renvoie une redirection vers l'Index en cas d'exception.
        /// </summary>
        [Fact]
        public async Task Edit_Action_RedirectsVerIndex_Exception()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            _servicesMock.Setup(service => service.patient.ObtenirToutAsync()).ThrowsAsync(new Exception("Simuler une exception"));

            // Act
            var result = await _patientsController.Edit(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        /// <summary>
        /// Teste si la méthode Edit (POST) redirige vers l'Index lorsque ModelState est valide.
        /// </summary>
        [Fact]
        public async Task Edit_Post_ModelStateValid_RedirectsToIndex()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            var patient = _patientsList.FirstOrDefault();
            _servicesMock.Setup(service => service.patient.ObtenirPatientParNAMAsync(patient.NAM)).ReturnsAsync(patient);
            _servicesMock.Setup(service => service.patient.EnregistrerOuModifierPatient(patient)).ReturnsAsync(patient);

            // Act
            var result = await _patientsController.Edit(1, patient);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _servicesMock.Verify(service => service.patient.EnregistrerOuModifierPatient(patient), Times.Once);
        }

        /// <summary>
        /// Teste si la méthode Edit (POST) retourne une vue avec le patient initial lorsque ModelState est invalide.
        /// </summary>
        [Fact]
        public async Task Edit_Post_ModelStateInvalid_ReturnsAvecPatientInit()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            _patientsController.ModelState.AddModelError("Error", "Model State invalid");

            var patient = _patientsList.FirstOrDefault();

            // Act
            var result = await _patientsController.Edit(1, patient);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(patient, viewResult.Model);
        }

        /// <summary>
        /// Teste si la méthode Delete (GET) renvoie une vue avec le modèle Patient correspondant à un identifiant valide.
        /// </summary>
        [Fact]
        public async Task Delete_Get_ReturnsView_IdValide()
        {
            // Arrange
            var patientId = 1;
            var patient = _patientsList.Find(p => p.PatientId == patientId);

            _servicesMock.Setup(service => service.patient.ObtenirToutAsync()).ReturnsAsync(_patientsList);
            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(patientId)).ReturnsAsync(patient);

            // Act
            var result = await _patientsController.Delete(patientId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Patient>(viewResult.Model);
            Assert.Equal(patientId, model.PatientId);
        }

        /// <summary>
        /// Teste si la méthode Delete (GET) renvoie NotFound lorsque l'identifiant est invalide.
        /// </summary>
        [Fact]
        public async Task Delete_Get_ReturnsNotFound_surInvalidId()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            var invalidPatientId = 999;

            _servicesMock.Setup(service => service.patient.ObtenirToutAsync()).ReturnsAsync(_patientsList);
            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(invalidPatientId)).ReturnsAsync((Patient)null);

            // Act
            var result = await _patientsController.Delete(invalidPatientId);

            // Assert
            var notFoundResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", notFoundResult.ViewName);
        }

        /// <summary>
        /// Teste si la méthode Delete renvoie NotFound lorsque l'identifiant est null.
        /// </summary>
        [Fact]
        public async Task Delete_ReturnsNotFound_NullId()
        {
            // Arrange
            // Act
            var result = await _patientsController.Delete(null);

            // Assert
            var notFoundResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("NotFound", notFoundResult.ViewName);
        }

        /// <summary>
        /// Teste si la méthode DeleteConfirmed supprime le patient et redirige vers l'Index en cas de succès.
        /// </summary>
        [Fact]
        public async Task DeleteConfirmed_SupprimerPatient_Est_Redirect_VersIndex()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            int patientId = 1;
            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(patientId)).ReturnsAsync(_patientsList.FirstOrDefault());

            // Act
            var result = await _patientsController.DeleteConfirmed(patientId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);

            _servicesMock.Verify(service => service.patient.SupprimerAsync(patientId), Times.Once);
        }

        /// <summary>
        /// Teste si la méthode DeleteConfirmed renvoie une vue en cas d'échec de la suppression.
        /// </summary>
        [Fact]
        public async Task DeleteConfirmed_RenvoieView_EnCasEchecSuppression()
        {
            // Arrange
            //mock tempData
            var tempDataMock = new Mock<ITempDataDictionary>();
            tempDataMock.SetupGet(t => t[It.IsAny<string>()]).Returns("Valeur de Mock");
            _patientsController.TempData = tempDataMock.Object;

            var patientId = 1;
            var patient = _patientsList.FirstOrDefault();

            _servicesMock.Setup(service => service.patient.ObtenirParIdAsync(patientId)).ReturnsAsync(patient);
            _servicesMock.Setup(service => service.patient.SupprimerAsync(patientId)).ThrowsAsync(new Exception("Simuler une exception"));

            // Act
            var result = await _patientsController.DeleteConfirmed(patientId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model);

            _servicesMock.Verify(service => service.patient.SupprimerAsync(patientId), Times.Once);
        }
    }
}
