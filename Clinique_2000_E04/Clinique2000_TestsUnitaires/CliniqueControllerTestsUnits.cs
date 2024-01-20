using Clinique2000_Core.Models;
using Clinique2000_MVC.Areas.Cliniques.Controllers;
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
        private readonly Mock<UserManager<IdentityUser>> _userManagerMock;
        private readonly Mock<IClinique2000Services> _servicesMock;

        private ApplicationUser _createur;
        private Adresse _adresse;
        private List<Clinique> _listeCliniques;

        private readonly CliniquesController _cliniqueController;

        public CliniqueControllerTestsUnits()
        {
            _userManagerMock = new Mock<UserManager<IdentityUser>>(new Mock<IUserStore<IdentityUser>>().Object, null, null, null, null, null, null, null, null);
            _servicesMock = new Mock<IClinique2000Services>();

            _cliniqueController = new CliniquesController(
                                    _servicesMock.Object,
                                    _userManagerMock.Object
                                );

            _createur = new ApplicationUser()
            {
                Id = "7cc96785-8933-4eac-8d7f-a289b28df223",
                UserName = "bit@gmail.com",
                NormalizedUserName = "BIT@GMAIL.COM",
                Email = "bit@gmail.com",
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

            _listeCliniques = new List<Clinique>();
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

                };
            }


        }

        /// <summary>
        /// Teste si l'action Index du contrôleur CliniquesController retourne un ViewResult avec une liste de cliniques.
        /// </summary>
        [Fact]
        public async Task Index_ReturnUneViewResult_AvecUneListeDesCliniques()
        {


            // Arrange
            _servicesMock.Setup(s => s.clinique.ObtenirToutAsync()).ReturnsAsync(_listeCliniques);

            // Act
            var result = await _cliniqueController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Clinique>>(viewResult.ViewData.Model);
            Assert.Equal(_listeCliniques, model);
        }
    }
}
