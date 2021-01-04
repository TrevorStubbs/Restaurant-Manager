using LightningLawInterviewRound1.UnitTests.TestConfigurations;
using System;
using System.Threading.Tasks;
using Xunit;

namespace LightningLawInterviewRound1.UnitTests
{
    /// <summary>
    /// These tests are used to make sure the Unit Testing environment is setup and running as expected.
    /// </summary>
    public class UnitTestEnvironmentTests : TestingDatabase
    {
        [Fact]
        public async Task CanGetDishFromTheDatabase()
        {
            // Arrange
            var expectedDishId = 1;

            // Act
            var dish = await _db.Dishes.FindAsync(1);

            // Assert
            Assert.Equal(expectedDishId, dish.Id);
        }
    }
}
