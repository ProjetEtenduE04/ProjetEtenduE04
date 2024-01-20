using Clinique2000_DataAccess.Data;
using Clinique2000_Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace Clinique2000_TestsUnitaires
{
    public class AdresseServiceTestsUnits
    {
        [Fact]
        public async Task VerifierCodePostalValideAsync_ValidCodePostal_ReturnsTrue()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database name for each test
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                var adresseService = new AdresseService(dbContext);
                var validCodePostal = "A1A 1A1";

                // Act
                var result = await adresseService.VerifierCodePostalValideAsync(validCodePostal);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public async Task VerifierCodePostalValideAsync_InvalidCodePostal_ThrowsValidationException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CliniqueDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique database name for each test
                .Options;

            using (var dbContext = new CliniqueDbContext(options))
            {
                var adresseService = new AdresseService(dbContext);
                var invalidCodePostal = "InvalidCodePostal";

                // Act & Assert
                await Assert.ThrowsAsync<ValidationException>(() => adresseService.VerifierCodePostalValideAsync(invalidCodePostal));
            }
        }
    }
}
