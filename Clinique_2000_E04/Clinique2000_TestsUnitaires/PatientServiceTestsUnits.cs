using Clinique2000_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using Clinique2000_Core.Models;
using Microsoft.AspNetCore.Routing;
using Clinique2000_Services.Services;
using Clinique2000_Services.IServices;
using Clinique2000_Utility.Constants;

namespace Clinique2000_TestsUnitaires
{
    public class PatientServiceTestsUnits
    {
        // Définir la DB InMemory

        private DbContextOptions<CliniqueDbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<CliniqueDbContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options);
            return options;
        }
        //Preparer des valeurs 
        private void SeedInMemoryStore(DbContextOptions<CliniqueDbContext> options)
        {
            using (var context = new CliniqueDbContext(options))
            {
                if (!context.Patients.Any())
                    context.Patients.AddRange(
                         new Patient()
                         {
                             PatientId = 1,
                             Nom = "Smith",
                             Prenom = "Jhon",
                             Courriel = "smith@gmail.com",
                             NAM = "SMIJ12345678",
                             CodePostal = "A1A 1A1",
                             MotDePasse = "password123!",
                             MotDePasseConfirmation = "password123!",
                             DateDeNaissance = new DateTime(2001, 05, 04),

                         }
                   );
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Vérifie si une date de naissance future déclenche une exception.
        /// </summary>
        [Fact]
        public void DateDeNaissanceEstValid_DateFuture_LanceArgumentException()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            var dateFuture = DateTime.Now.AddDays(1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => service.DateDeNaissanceEstValid(dateFuture));
            Assert.Equal("La date de naissance ne peut pas se situer dans le futur.", exception.Message);
        }

        /// <summary>
        /// Vérifie si la date de naissance fournie est valide.
        /// </summary>
        /// <param name="annee">L'année de la date de naissance</param>
        /// <param name="mois">Le mois de la date de naissance</param>
        /// <param name="jour">Le jour de la date de naissance.</param>
        [Theory]
        [InlineData(1990, 5, 15)]
        [InlineData(2022, 2, 20)]
        public void DateDeNaissanceEstValidDateValideTrue(int annee, int mois, int jour)
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            var dateValide = new DateTime(annee, mois, jour);

            // Act & Assert
            Assert.True(service.DateDeNaissanceEstValid(dateValide));
        }

        /// <summary>
        /// Teste le calcul de l'âge d'une personne née dans une année bissextile.
        /// </summary>
        /// <returns>Âge correct</returns>
        [Fact]
        public async Task CalculerAge_NeAnneeBissextile_ReturnAgeCorrect()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            var dateOfBirth = new DateTime(2000, 2, 29); // Une année bissextile

            // Act
            var age = service.CalculerAge(dateOfBirth);

            // Assert
            Assert.Equal(23, age);
        }

        /// <summary>
        /// Teste le calcul de l'âge d'une personne née au cours d'une année ordinaire.
        /// </summary>
        /// <returns>Âge correct</returns>
        [Fact]
        public async Task CalculerAge_NeAnneeOrdinaire_ReturnAgeCorrect()
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            var dateOfBirth = new DateTime(1999, 4, 15); // Année ordinaire

            // Act
            var age = service.CalculerAge(dateOfBirth);

            // Assert
            Assert.Equal(24, age);
        }
        /// <summary>
        /// Vérifie si l'âge spécifié est supérieur à l'âge de la majorité.
        /// </summary>
        /// <param name="age">Âge à vérifier.</param>
        [Theory]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(100)]
        public void EstMajeurAge_AgeSuperieurAgeMajorite_True(int age)
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurAge(age);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Vérifie si l'âge spécifié est inférieur à l'âge de la majorité.
        /// </summary>
        /// <param name="age">Âge à vérifier.</param>
        [Theory]
        [InlineData(13)]
        [InlineData(10)]
        [InlineData(5)]
        public void EstMajeurAge_AgeInferieurAgeMajorite_False(int age)
        {
            // Arrange
            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurAge(age);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Vérifie si l'âge spécifié est égal à l'âge de la majorité.
        /// </summary>
        [Fact]
        public void EstMajeurAge_AgeEgalAgeMajorite_True()
        {
            // Arrange
            var age = 14;

            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurAge(age);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Vérifie si la personne née hier est majeure.
        /// </summary>
        [Fact]
        public void EstMajeurDateDeNaissance_NeeHier_False()
        {
            // Arrange

            var dateNeeHier = DateTime.Now.Date.AddDays(-1);

            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurDateDeNaissance(dateNeeHier);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Vérifie si la personne âgée de 14 ans est majeure.
        /// </summary>
        [Fact]
        public void EstMajeurDateDeNaissance_14Ans_True()
        {
            // Arrange
            var age14Ans = DateTime.Now.Date.AddYears(-14);

            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurDateDeNaissance(age14Ans);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Vérifie si la personne âgée de 20 ans est majeure.
        /// </summary>
        [Fact]
        public void EstMajeurDateDeNaissance_20Ans_True()
        {
            // Arrange
            var age20Ans = DateTime.Now.Date.AddYears(-20);

            var options = SetUpInMemory("moq_db");
            using var context = new CliniqueDbContext(options);
            var service = new PatientService(context);

            // Act
            var result = service.EstMajeurDateDeNaissance(age20Ans);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Vérifie l'existence d'un patient dans la base de données à partir du numéro d'assurance médicale (NAM) fourni.
        /// </summary>
        /// <returns>
        /// Vrai si le patient existe dans la base de données avec le NAM fourni ; sinon Faux.
        /// </returns>
        /// <remarks>
        /// Ce test vérifie si un patient est trouvé dans la base de données en utilisant un NAM valide et un NAM qui n'existe pas dans la base de données.
        /// </remarks>
        [Fact]
        public async Task VerifierExistencePatientParNAM_ReturnTrueOrFalse()
        {
            using (var dbTest = new CliniqueDbContext(SetUpInMemory("VerifierExistencePatientParNAM_ReturnPatient")))
            {
                IPatientService service = new PatientService(dbTest);
                var patientAChercher = await dbTest.Patients.LastOrDefaultAsync();
                var namPatientFaux = "xxxx12345674";
                var result1 =  await service.VerifierExistencePatientParNAM(patientAChercher.NAM);
                var result2 =  await service.VerifierExistencePatientParNAM(namPatientFaux);

            
                Assert.IsType<bool>(result1);
                Assert.NotNull(result1);
                Assert.True(result1);

                Assert.IsType<bool>(result2);
                Assert.NotNull(result2);
                Assert.False(result2);
            }
        }
    }
}

