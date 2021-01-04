using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.IntegrationTests.TestConfigurations
{
    public static class SeedDataForTests
    {
        public static void LoadDbWithSeedData(LightningLawInterviewRound1Context context)
        {
            var seedMenu = new Menu
            {
                Id = 1,
                Name = "Pie with Icecream",
                Type = Models.MenuType.Dessert
            };

            var seedDish = new Dish
            {
                Id = 1,
                Name = "Pie",
                DishType = Models.DishType.Dessert
            };

            var seedRecipe = new Recipe
            {
                Id = 1,
                Name = "Pie Recipe"
            };

            var seedIngredient = new Ingredient
            {
                Id = 1,
                Name = "flour",
                Cost = 10
            };

            var seedMenuDish = new MenuDishes
            {
                DishId = 1,
                MenuId = 1
            };

            var seedDishRecipe = new DishRecipe
            {
                DishId = 1,
                RecipeId = 1
            };

            var seedRecipeIngredients = new RecipeIngredients
            {
                RecipeId = 1,
                IngredientId = 1
            };

            context.Entry(seedMenu).State = EntityState.Added;
            context.Entry(seedDish).State = EntityState.Added;
            context.Entry(seedRecipe).State = EntityState.Added;
            context.Entry(seedIngredient).State = EntityState.Added;
            context.Entry(seedMenuDish).State = EntityState.Added;
            context.Entry(seedDishRecipe).State = EntityState.Added;
            context.Entry(seedRecipeIngredients).State = EntityState.Added;

            context.SaveChanges();
        }
    }
}
