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

            // Applicant Added - A Composite Key must be defined for the RecipeIngredients join table.
            modelBuilder.Entity<RecipeIngredients>().HasKey(e => new { e.RecipeId, e.IngredientId });
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<DishRecipe> DishRecipes { get; set; }
        public DbSet<MenuDishes> MenuDishes { get; set; }

        // Applicant added - there was no connection to the database with the RecipeIngredients entity.
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }

    }
}
