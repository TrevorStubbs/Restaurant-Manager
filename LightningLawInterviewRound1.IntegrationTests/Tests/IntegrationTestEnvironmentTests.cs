using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace LightningLawInterviewRound1.IntegrationTests
{
    /// <summary>
    /// These tests are used to make sure the Integration Testing environment is setup and running as expected.
    /// </summary>
    public class IntegrationTestEnvironmentTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTestEnvironmentTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;            
        }

        // Calling a route that doesn't exist is intentional. This is a test on the testing environment not a specific system.
        [Fact]
        public async Task DishesController_GetDishEndpointReturnSOMETHING()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
