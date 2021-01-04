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
    /// <summary>
    /// This test suite runs tests on all of the methods of the 'DishService' service.
    /// </summary>
    public class DishServiceUnitTests : TestingDatabase
    {
        private readonly Mock<IRecipe> _recipeMock = new Mock<IRecipe>();

        private IDish BuildSut()
        {
            return new DishService(_db, _recipeMock.Object);
        }

        [Fact]
        public async Task CanGetADish()
        {
            // Arrange
            var dishId = 1;
            var recpieId = 1;
            var ingredientId = 1;

            var ingredients = new List<IngredientDTO>();

            ingredients.Add(new IngredientDTO
            {
                Id = recpieId,
                Name = "Sugar"
            });

            var recipes = new List<RecipeDTO>();

            recipes.Add(new RecipeDTO
            {
                Id = ingredientId,
                Name = "Pumpkin Pie",
                Ingredients = ingredients
            });

            var setupMock = _recipeMock.Setup(x => x.GetRecipesForDish(dishId)).ReturnsAsync(recipes);

            // Act
            var sut = BuildSut();
            var response = await sut.GetDish(dishId);

            // Assert
            Assert.NotNull(response);
            Assert.Equal("Pie", response.Name);
            Assert.Equal(recpieId, response.Recipes[0].Id);
            Assert.Equal(ingredientId, response.Recipes[0].Ingredients[0].Id);
        }

        [Fact]
        public async Task CanUpdateADish()
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

            var setupMock = _recipeMock.Setup(x => x.GetRecipesForDish(dishToBeUpdated.Id)).ReturnsAsync(recipes);

            // Act
            var sut = BuildSut();
            var response = await sut.UpdateDish(dishToBeUpdated);
            var updatedDish = await sut.GetDish(dishToBeUpdated.Id);

            // Assert
            Assert.True(response);
            Assert.Equal(dishToBeUpdated.Name, updatedDish.Name);
            Assert.Equal(dishToBeUpdated.Type, updatedDish.Type);
            Assert.Equal(dishToBeUpdated.Recipes[0].Name, updatedDish.Recipes[0].Name);
            Assert.Equal(dishToBeUpdated.Recipes[0].Ingredients[0].Name, updatedDish.Recipes[0].Ingredients[0].Name);
        }
    }
}
