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
using Clinique2000_MVC.Areas.Admin.Controllers;

namespace Clinique2000_TestsUnitaires
{
    public class AdminServiceTestsUnits
    {
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly Mock<IClinique2000Services> _servicesMock;
        private readonly AdminController _adminController;

        public AdminServiceTestsUnits()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, null, null, null, null, null, null, null, null);
            _servicesMock = new Mock<IClinique2000Services>();
            _adminController = new AdminController(_servicesMock.Object, _userManagerMock.Object);
        }

        [Fact]
        public async Task Approbation_WhenIdIsNull_RedirectToActionIndexHome()
        {
            // Arrange
            string id = null;

            // Act
            var result = await _adminController.Approbation(id);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
        }

        [Fact]
        public async Task Approbation_WhenIdIsClinique_ReturnViewWithApprobationCliniquesVM()
        {
            // Arrange
            string id = "clinique";
            var approbationVM = new ApprobationVM
            {
                Param = id
            };
            var approbationCliniquesVM = new ApprobationCliniquesVM
            {
                Cliniques = new List<Clinique>()
            };
            _servicesMock.Setup(s => s.admin.ApprobationCliniqueListe()).ReturnsAsync(approbationCliniquesVM.Cliniques);

            // Act
            var result = await _adminController.Approbation(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ApprobationVM>(viewResult.Model);
            Assert.Equal(approbationVM.Param, model.Param);
            Assert.Equal(approbationCliniquesVM.Cliniques, model.ApprobationCliniquesVM.Cliniques);
        }

        [Fact]
        public async Task Approbation_ReturnCorrectListOfClinics()
        {
            // Arrange
            string id = "clinique";
            var approbationVM = new ApprobationVM
            {
                Param = id
            };
            var approbationCliniquesVM = new ApprobationCliniquesVM
            {
                Cliniques = new List<Clinique>()
            };
            _servicesMock.Setup(s => s.admin.ApprobationCliniqueListe()).ReturnsAsync(approbationCliniquesVM.Cliniques);

            // Act
            var result = await _adminController.Approbation(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ApprobationVM>(viewResult.Model);
            Assert.Equal(approbationVM.Param, model.Param);
            Assert.Equal(approbationCliniquesVM.Cliniques, model.ApprobationCliniquesVM.Cliniques);
        }
    }
}