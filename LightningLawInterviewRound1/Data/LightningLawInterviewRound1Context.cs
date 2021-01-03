using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LightningLawInterviewRound1.Models.Entities;

namespace LightningLawInterviewRound1.Data
{
    public class LightningLawInterviewRound1Context : DbContext
    {
        public LightningLawInterviewRound1Context(DbContextOptions<LightningLawInterviewRound1Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DishRecipe>().HasKey(e => new { e.DishId, e.RecipeId });
            modelBuilder.Entity<MenuDishes>().HasKey(e => new { e.MenuId, e.DishId });
            // Applicant Added
            modelBuilder.Entity<RecipeIngredients>().HasKey(e => new { e.RecipeId, e.IngredientId });

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

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<DishRecipe> DishRecipes { get; set; }
        public DbSet<MenuDishes> MenuDishes { get; set; }

        // Applicant added
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }

    }
}
