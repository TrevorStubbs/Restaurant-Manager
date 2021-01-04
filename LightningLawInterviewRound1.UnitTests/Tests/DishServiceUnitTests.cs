using LightningLawInterviewRound1.Models.DTOs;
using LightningLawInterviewRound1.Models.Interfaces;
using LightningLawInterviewRound1.Models.Services;
using LightningLawInterviewRound1.UnitTests.TestConfigurations;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LightningLawInterviewRound1.UnitTests.Tests
{
    public class DishServiceUnitTests : TestingDatabase
    {
        private readonly Mock<IRecipe> _recipeMock = new Mock<IRecipe>();

        private IDish BuildSut()
        {
            return new DishService(_db, _recipeMock.Object);
        }

        [Fact]
        public void CanGetADish()
        {
            // Arrange
            var dishId = 1;
            var recpieId = 1;
            var ingredientId = 1;

            var ingrediants = new List<IngredientDTO>();

            ingrediants.Add(new IngredientDTO
            {
                Id = recpieId,
                Name = "Sugar"
            });

            var recipes = new List<RecipeDTO>();

            recipes.Add(new RecipeDTO
            {
                Id = ingredientId,
                Name = "Pumpkin Pie",
                Ingredients = ingrediants
            });

            var setupMock = _recipeMock.Setup(x => x.GetRecipesForDish(dishId)).ReturnsAsync(recipes);

            // Act
            var sut = BuildSut();
            var response = sut.GetDish(dishId).Result;

            // Assert
            Assert.NotNull(response);
            Assert.Equal("Pie", response.Name);
            Assert.Equal(recpieId, response.Recipes[0].Id);
            Assert.Equal(ingredientId, response.Recipes[0].Ingredients[0].Id);
        }
    }
}
