using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightningLawInterviewRound1.UnitTests.TestConfigurations
{
    /// <summary>
    /// This class inherits from the System Under Test's DbContext and provides a place for the tester to put in data used for testing purposes. This data will be used to seed the in-memory Sqlite server used for testing.
    /// </summary>
    public class DbContextWithSeedDataForTesting : LightningLawInterviewRound1Context
    {
        public DbContextWithSeedDataForTesting(DbContextOptions<LightningLawInterviewRound1Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Pie with Icecream",
                    Type = Models.MenuType.Dessert
                });
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    Name = "Pie",
                    DishType = Models.DishType.Dessert
                });
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Pie Recipe"
                });
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "flour",
                    Cost = 10
                });

            modelBuilder.Entity<MenuDishes>().HasData(
                new MenuDishes
                {
                    DishId = 1,
                    MenuId = 1
                });
            modelBuilder.Entity<DishRecipe>().HasData(
                new DishRecipe
                {
                    DishId = 1,
                    RecipeId = 1
                });
            modelBuilder.Entity<RecipeIngredients>().HasData(
                new RecipeIngredients
                {
                    RecipeId = 1,
                    IngredientId = 1
                });
        }
    }
}
