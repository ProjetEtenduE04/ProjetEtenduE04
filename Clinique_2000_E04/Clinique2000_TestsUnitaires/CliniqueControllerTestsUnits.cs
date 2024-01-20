using Clinique2000_Core.Models;
using Clinique2000_MVC.Areas.Clinique.Controllers;
using Clinique2000_MVC.Areas.Patients.Controllers;
using Clinique2000_Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_TestsUnitaires
{
    public class CliniqueControllerTestsUnits
    {

        private readonly Mock<IClinique2000Services> _servicesMock;
        private readonly CliniquesController _cliniqueController;
        private List<Clinique> _cliniqueListe;

        public CliniqueControllerTestsUnits()
        {
            _servicesMock = new Mock<IClinique2000Services>();

            _cliniqueController = new CliniquesController(
                                    _servicesMock.Object
                                );

            _cliniqueListe = new List<Clinique>()
            {
                new Clinique()
                {
                   CliniqueID = 1,
                   NomClinique = "Anh Anh",
                   Courriel = "anieewon@gmail.com",
                   HeureOuverture = new TimeSpan(8, 0, 0),
                   HeureFermeture = new TimeSpan(18, 0, 0),
                   TempsMoyenConsultation = 30,
                   EstActive = false,
                   AdresseID = 1

                }
            };
        }

        [Fact]
        public async Task IndexPourPatients_ReturnsViewWithList()
        {
            // Arrange
            _servicesMock.Setup(service => service.clinique.ObtenirToutAsync()).ReturnsAsync(_cliniqueListe);


            // Act
            var result = await _cliniqueController.IndexPourPatients();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Clinique>>(viewResult.Model);

            Assert.Equal(_cliniqueListe.Count, model.Count());

            foreach (var clinique in _cliniqueListe)
            {
                Assert.Contains(model, c => c.CliniqueID == clinique.CliniqueID);
            }
        }

    }
}
