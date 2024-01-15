using Clinique2000_Core.Models;
using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

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
                             NAM = "SMIJ12345678",
                             CodePostal = "A1A 1A1",
                             DateDeNaissance = new DateTime(2001, 05, 04),
                             Age = 23,
                             UserId = "4eaffcbd-4351-4995-a0c0-03624a3743c7"

                         }
                   ); ;
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
            Assert.Equal(23, age.Annees);
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
            Assert.Equal(24, age.Annees);
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
                // Arrange
                IPatientService service = new PatientService(dbTest);
                var patientAChercher = await dbTest.Patients.LastOrDefaultAsync();
                var namPatientFaux = "xxxx12345674";
                // Act
                var trueResult = await service.VerifierExistencePatientParNAM(patientAChercher.NAM);
                var falseResult = await service.VerifierExistencePatientParNAM(namPatientFaux);

                // Assert
                Assert.IsType<bool>(trueResult);
                Assert.NotNull(trueResult);
                Assert.True(trueResult);

                Assert.IsType<bool>(falseResult);
                Assert.NotNull(falseResult);
                Assert.False(falseResult);
            }
        }
        /// <summary>
        /// Vérifie si un patient existe dans la base de données par Nom.
        /// </summary>
        /// <returns>
        /// Renvoie vrai (True) si le patient existe avec le Nomn fournie, sinon renvoie faux (False).
        /// </returns>
        [Fact]
        public async Task VerifierExistencePatientParNomAsync_ReturnTrueOrFalse()
        {
            using (var dbTest = new CliniqueDbContext(SetUpInMemory("VerifierExistencePatientParNomAsync_ReturnTrueOrFalse")))
            {
                // Arrange
                IPatientService service = new PatientService(dbTest);
                var patientAChercher = await dbTest.Patients.LastOrDefaultAsync();
                var nomPatientFaux = "Alex";
                // Act
                var trueResult = await service.VerifierExistencePatientParEmailAsync(patientAChercher.Nom);
                var falseResult = await service.VerifierExistencePatientParEmailAsync(nomPatientFaux);

                // Assert
                Assert.IsType<bool>(trueResult);
                Assert.NotNull(trueResult);
                Assert.True(trueResult);

                Assert.IsType<bool>(falseResult);
                Assert.NotNull(falseResult);
                Assert.False(falseResult);
            }
        }

        /// <summary>
        /// Teste la méthode ObtenirPatientParNAMAsync pour vérifier si elle retourne un patient existant en fonction du numéro d'assurance médicale (NAM).
        /// </summary>
        /// <returns>
        /// Si un patient existe avec le NAM fourni, la méthode devrait retourner le patient correspondant ; sinon, elle doit retourner null.
        /// </returns>
        [Fact]
        public async Task ObtenirPatientParNAMAsync_ReturnPatientIfExists()
        {
            using (var dbTest = new CliniqueDbContext(SetUpInMemory("ObtenirPatientParNAMAsync_ReturnPatientIfExists")))
            {
                // Arrange
                IPatientService service = new PatientService(dbTest);
                var patientAChercher = await dbTest.Patients.LastOrDefaultAsync();

                var namPatientFaux = "xxxx12345674";

                // Act
                var trueResult = await service.ObtenirPatientParNAMAsync(patientAChercher.NAM);
                var falseResult = await service.ObtenirPatientParNAMAsync(namPatientFaux);
                // Assert
                Assert.NotNull(trueResult);
                Assert.IsType<Patient>(trueResult);
                Assert.Equal(patientAChercher, trueResult);

                Assert.Null(falseResult);
            }
        }

        /// <summary>
        /// Teste la méthode ObtenirPatientParNomAsync pour vérifier si elle retourne un patient existant en fonction de Nom.
        /// </summary>
        /// <returns>
        /// Si un patient existe en fonction du nom fournie, la méthode devrait retourner le patient correspondant ; sinon, elle doit retourner null.
        /// </returns>
        [Fact]
        public async Task ObtenirPatientParNomAsync_ReturnPatientIfExists()
        {
            using (var dbTest = new CliniqueDbContext(SetUpInMemory("ObtenirPatientParNomAsync_ReturnPatientIfExists")))
            {
                // Arrange
                IPatientService service = new PatientService(dbTest);
                var patientAChercher = await dbTest.Patients.LastOrDefaultAsync();

                var nomlPatientFaux = "Alexei";

                // Act
                var trueResult = await service.ObtenirPatientParNomAsync(patientAChercher.Nom);
                var falseResult = await service.ObtenirPatientParNAMAsync(nomlPatientFaux);
                // Assert
                Assert.NotNull(trueResult);
                Assert.IsType<Patient>(trueResult);
                Assert.Equal(patientAChercher, trueResult);

                Assert.Null(falseResult);
            }
        }

        ///// <summary>
        ///// este la fonctionnalité d'enregistrement d'un patient lorsqu'il existe déjà un utilisateur avec la même adresse électronique.
        ///// </summary>
        ///// <returns>Lance une exception si l'on essaie d'enregistrer un patient avec un courriel existant.</returns>
        //[Fact]
        //public async Task EnregistrerPatient_CourrielExist_ThrowsException()
        //{
        //    // Arrange
        //    using (var dbTest = new CliniqueDbContext(SetUpInMemory("EnregistrerPatient_WhenEmailExists_ThrowsException")))
        //    {
        //        // Arrange
        //        IPatientService service = new PatientService(dbTest);
        //        var patientInscris = await dbTest.Patients.LastOrDefaultAsync();

        //        var courrielExistent = patientInscris.Courriel;

        //        var patientAEnregistrer = new Patient { Courriel = courrielExistent };

        //        // Act & Assert
        //        await Assert.ThrowsAsync<Exception>(() => service.EnregistrerPatient(patientAEnregistrer));
        //    }
        //}

        /// <summary>
        /// Test d'enregistrement des patients, avec un NAM déjà enregistré dans BD
        /// </summary>
        /// <returns>Une exception est lancée au cas où il existerait déjà dans le bd</returns>
        [Fact]
        public async Task EnregistrerPatient_NAMExist_ThrowsException()
        {
            // Arrange

            using (var dbTest = new CliniqueDbContext(SetUpInMemory("EnregistrerPatient_NAMExist_ThrowsException")))
            {
                IPatientService service = new PatientService(dbTest);
                var patientInscris = await dbTest.Patients.LastOrDefaultAsync();

                var namExistent = patientInscris.NAM;
                var nouveauCourriel = "test@test.test";

                var patientAEnregistrer = new Patient { 
                    NAM = namExistent 
                };

                // Act & Assert
                await Assert.ThrowsAsync<Exception>(() => service.EnregistrerOuModifierPatient(patientAEnregistrer));
            }
        }

        /// <summary>
        /// Tester le cas de l'enregistrement d'un patient avec une date invalide (dans le futur)
        /// </summary>
        /// <returns>Renvoie une exception si la date n'est pas valide</returns>
        [Fact]
        public async Task EnregistrerPatient_DateDeNaissanceInvalide_ThrowsArgumentException()
        {
            // Arrange

            using (var dbTest = new CliniqueDbContext(SetUpInMemory("EnregistrerPatient_DateDeNaissanceInvalide_ThrowsArgumentEception")))
            {
                IPatientService service = new PatientService(dbTest);
                var patientInscris = await dbTest.Patients.LastOrDefaultAsync();

                var nouveauNAM = "ABCD12345678";
                var dateDeNaissanceInvalide = DateTime.Now.AddDays(1);

                var patientAEnregistrer = new Patient { 
                    NAM = nouveauNAM, 
                    DateDeNaissance=dateDeNaissanceInvalide
                };

                // Act & Assert
                await Assert.ThrowsAsync<ArgumentException>(() => service.EnregistrerOuModifierPatient(patientAEnregistrer));
            }
        }

        /// <summary>
        /// Cas test d'enregistrement du patient mineur
        /// </summary>
        /// <returns>Lancer une exception si l'utilisateur est mineur</returns>
        [Fact]
        public async Task EnregistrerPatient_EstMineur_ThrowsException()
        {
            // Arrange

            using (var dbTest = new CliniqueDbContext(SetUpInMemory("EnregistrerPatient_EstMineur_ThrowsException")))
            {
                IPatientService service = new PatientService(dbTest);
                var patientInscris = await dbTest.Patients.LastOrDefaultAsync();

                var nouveauNAM = "ABCD12345678";
                var dateDeNaissanceInvalide = DateTime.Now;

                var patientAEnregistrer = new Patient
                {
                    DateDeNaissance = dateDeNaissanceInvalide
                };

                // Act & Assert
                await Assert.ThrowsAsync<Exception>(() => service.EnregistrerOuModifierPatient(patientAEnregistrer));
            }
        }

        /// <summary>
        /// Teste l'enregistrement correct d'un patient lorsque toutes les conditions sont remplies.
        /// </summary>
        /// <returns>Retourner le patient sans lancer d'exceptions</returns>
        [Fact]
        public async Task EnregistrerPatient_CorrectRegistration_NoExceptionThrown()
        {
            // Arrange
            using (var dbTest = new CliniqueDbContext(SetUpInMemory("EnregistrerPatient_CorrectRegistration_NoExceptionThrown")))
            {
                IPatientService service = new PatientService(dbTest);
                var patientAEnregistrer = new Patient
                {
                    Nom = "TEST",
                    Prenom = "TEST",
                    CodePostal = "K3K 3K3",
                    NAM = "ABCD12345678",
                    DateDeNaissance = new DateTime(1990, 1, 1),
                    UserId = "4eaffcbd-4351-4995-a0c0-03624a3743c7"
                };

                // Act
                var createdPatient = await service.EnregistrerOuModifierPatient(patientAEnregistrer);

                //Assert
                Assert.NotNull(createdPatient);
            }
        }

    }
}

