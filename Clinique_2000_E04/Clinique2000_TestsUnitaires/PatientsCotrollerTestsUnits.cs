using Clinique2000_Core.Models;
using Clinique2000_MVC.Areas.Patients.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_TestsUnitaires
{
    public class PatientsCotrollerTestsUnits
    {

        private readonly Mock<IServiceBaseAsync<Patient>> _serviceBaseMock;
        private readonly Mock<IPatientService> _patientServiceMock;
        private readonly Mock<IAuthenGoogleService> _authenGoogleServiceMock;
        //private readonly Mock<SignInManager<IdentityUser>> _signInManagerMock;
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;


        private List<Patient> _patientsList;
        private readonly PatientsController _patientsController;

        public PatientsCotrollerTestsUnits()
        {
            _serviceBaseMock = new Mock<IServiceBaseAsync<Patient>>();
            _patientServiceMock = new Mock<IPatientService>();
            _authenGoogleServiceMock = new Mock<IAuthenGoogleService>();
            //_signInManagerMock = new Mock<SignInManager<IdentityUser>>(_userManagerMock.Object, new Mock<IHttpContextAccessor>().Object, new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object, null, null, null, null);
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, null, null, null, null, null, null, null, null);




            _patientsController = new PatientsController(
                                    _serviceBaseMock.Object,
                                    _patientServiceMock.Object,
                                    _authenGoogleServiceMock.Object,
                                    //_signInManagerMock.Object,
                                    _userManagerMock.Object
           );

            _patientsList = new List<Patient>()
            {
                new Patient()
                {
                    Nom = "Smith",
                    Prenom = "Jhon",
                    NAM = "SMIJ12345678",
                    CodePostal = "A1A 1A1",
                    DateDeNaissance = new DateTime(2001, 05, 04),
                    UserId = "4eaffcbd-4351-4995-a0c0-03624a3743c7"

                }
            };
        }

        ///// <summary>
        ///// Teste si la méthode Create retourne une vue avec le modèle correct.
        ///// </summary>
        ///// <returns>Une tâche asynchrone représentant l'exécution du test.</returns>
        //[Fact]
        //public async Task Create_ReturnsViewWithModel()
        //{
        //    // Arrange
        //    var patientMock = _patientsList.FirstOrDefault();
        //    var userAuthentifie = new Patient { 
        //        //Courriel = patientMock.Courriel ,
        //        //GoogleNameIdentifier = patientMock.GoogleNameIdentifier,
        //        DateDeNaissance = patientMock.DateDeNaissance,
        //        UserId = patientMock.UserId
        //    };

        //    _patientServiceMock.Setup(service => service.UserEstPatientAsync(userAuthentifie.UserId)).ReturnsAsync(true);
        //    // Act
        //    var result = await _patientsController.Create();

        //    // Assert
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    var model =
        //        Assert.IsType<Patient>(viewResult.Model);
        //    //Assert.Equal(userAuthentifie.Courriel, model.Courriel); 
        //}

        [Fact]
        public async Task Create_ReturnsViewWithModel_WhenUserIsNotPatient()
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

            _userManagerMock.Setup(manager => manager.FindByEmailAsync("test@example.com")).ReturnsAsync(user);
            _patientServiceMock.Setup(service => service.UserEstPatientAsync(user.Id)).ReturnsAsync(false);

            // Act
            var result = await _patientsController.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Patient>(viewResult.Model);
        }

        [Fact]
        public async Task Create_ReturnsRedirectToIndex_WhenUserIsPatient()
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

            _userManagerMock.Setup(manager => manager.FindByEmailAsync("test@example.com")).ReturnsAsync(user);
            _patientServiceMock.Setup(service => service.UserEstPatientAsync(user.Id)).ReturnsAsync(true);

            // Act
            var result = await _patientsController.Create();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
        }

        /// <summary>
        /// Teste le comportement de l'action Create lorsque le modèle est valide.
        /// Vérifie si la méthode Create redirige vers l'action Index lorsque le modèle est valide.
        /// </summary>
        [Fact]
        public async Task Create_Post_ModelStateValid_RedirectsToIndex()
        {
            // Arrange
            var patientValide = _patientsList.FirstOrDefault();

            _patientServiceMock.Setup(service => service.EnregistrerPatient(patientValide)).ReturnsAsync(patientValide);

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
            var patientInvalid = _patientsList.FirstOrDefault();
            patientInvalid.DateDeNaissance = DateTime.Now;

            _patientsController.ModelState.AddModelError("Error", "Model State est invalide");

            // Act
            var result = await _patientsController.Create(patientInvalid);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(patientInvalid, viewResult.Model);
        }
    }
}
