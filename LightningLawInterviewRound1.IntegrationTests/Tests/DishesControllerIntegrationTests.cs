/*
 * This code is based off of 'Integration tests in ASP.NET Core' in the official Microsoft Documentation
 * https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
 */

using LightningLawInterviewRound1.IntegrationTests.TestConfigurations;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LightningLawInterviewRound1.IntegrationTests.Tests
{
    public class DishesControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {      
        // Applicant's Thoughts - 
        // This is how the guide has it. But In the future we might want to have a method call the start of the HttpClient.
        // That will have clean client for each test but it might also make each test slower.
        // I am still exploring what is the better option.

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DishesControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task DishesController_CanGetADish()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Dishes/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
