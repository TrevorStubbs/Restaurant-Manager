/*
 * This code is based off of 'Integration tests in ASP.NET Core' in the official Microsoft Documentation
 * https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
 */

using LightningLawInterviewRound1.IntegrationTests.TestConfigurations;
using LightningLawInterviewRound1.Models.DTOs;
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
        // This is how the guide has it. But In the future we might want to have a method call the start of the HttpClient at the beginning of each test.
        // That will have clean client for each test but it might also make all the tests slower to run.
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
            var response = await _client.GetAsync("/api/Dishes/1");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DishesController_CanUpdateADish()
        {
            // Arrange 
            var peasIngredients = new List<IngredientDTO>();
            peasIngredients.Add(new IngredientDTO
            {
                Id = 2,
                Name = "Peas"
            });

            peasIngredients.Add(new IngredientDTO
            {
                Id = 3,
                Name = "Butter"
            });

            var chickenIngredients = new List<IngredientDTO>() {
                new IngredientDTO
                {
                    Id = 4,
                    Name = "Chicken"
                }
            };

            var recipes = new List<RecipeDTO>();

            recipes.Add(new RecipeDTO
            {
                Id = 2,
                Name = "Buttered Peas",
                Ingredients = peasIngredients
            });

            recipes.Add(new RecipeDTO
            {
                Id = 3,
                Name = "Grilled Chicken",
                Ingredients = chickenIngredients
            });

            var dishToBeUpdated = new UpdateDishDTO
            {
                Id = 1,
                Name = "Chicken Dinner",
                Type = Models.DishType.MainCourse,
                Recipes = recipes
            };

            // Act

            // Assert
        }
    }
}
