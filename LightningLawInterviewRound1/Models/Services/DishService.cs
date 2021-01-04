using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.DTOs;
using LightningLawInterviewRound1.Models.Entities;
using LightningLawInterviewRound1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Services
{
    public class DishService : IDish
    {
        private LightningLawInterviewRound1Context _context;
        private IRecipe _recipe;

        public DishService(LightningLawInterviewRound1Context context, IRecipe recipe)
        {
            _context = context;
            _recipe = recipe;
        }

        public async Task<DishDTO> GetDish(int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            return await ConvertDish(dish);
        } 

        public async Task<List<DishDTO>> GetDishesForMenu(int menuId)
        {
            List<DishDTO> dishes = new List<DishDTO>();
            var dishIds = await _context.MenuDishes.Where(x => x.MenuId == menuId).Select(x => x.DishId).ToListAsync();
            foreach (var item in dishIds)
            {
                dishes.Add(await GetDish(item));
            }

            return dishes;
        }

        /// <summary>
        /// Updates a Dish and its recipes in the database.
        /// </summary>
        /// <param name="dish">Requires a complete DishDTO including all of its recipes.</param>
        /// <returns>True: if successful</returns>
        public async Task<bool> UpdateDish(UpdateDishDTO dish)
        {
            // TODO: Complete this method and write a (few?) test(s) to confirm its functionality. 
            // Completing this method may require usage of other services
            // A few things to remember with the update:
            // 1. When updating the dish, the recipe could change.
            // 2. A recipe consists of ingredients, which could also change

            // Get the dish
            // Update the items in the DB with the new DTO
            // Update the dish with the new recipes
            // Update the new recipes with new ingredients
            // If successful return true
            // If unsuccessful return false

            // Get the Dish from the database
            var dishFromDB = await _context.Dishes.Where(x => x.Id == dish.Id).FirstOrDefaultAsync();

            if (dishFromDB == null)
                return false;

            // Update its basic information
            dishFromDB.Name = dish.Name;
            dishFromDB.DishType = dish.Type;

            // Update the database
            _context.Entry(dishFromDB).State = EntityState.Modified;            

            // Find all join entities between this dish and recipes
            var deleteTheseRecipes = await _context.DishRecipes.Where(x => x.DishId == dishFromDB.Id).ToListAsync();
                        
            foreach (var recipe in deleteTheseRecipes)
            {
                // Delete those references
                _context.Entry(recipe).State = EntityState.Deleted;                
            }
            
            foreach(var recipe in dish.Recipes)
            {
                var recipeEntity = new Recipe
                {
                    Id = recipe.Id,
                    Name = recipe.Name
                };

                _context.Entry(recipeEntity).State = EntityState.Added;

                // Build a new DishRecpie join entity 
                var newRecpieJoin = new DishRecipe 
                { 
                    DishId = dish.Id, 
                    RecipeId = recipe.Id 
                };

                // Add that entity to the database 
                _context.Entry(newRecpieJoin).State = EntityState.Added;
                
                // Find all join entities between this Recipe and its ingredients
                var deleteTheseIngredientsFromTheRecipe = await _context.RecipeIngredients.Where(x => x.RecipeId == recipe.Id).ToListAsync();

                foreach (var ingredient in deleteTheseIngredientsFromTheRecipe)
                {
                    // Delete those references
                    _context.Entry(ingredient).State = EntityState.Deleted;                    
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    // Build a new RecipeIngredient join entity
                    var newIngredientJoin = new RecipeIngredients
                    {
                        RecipeId = recipe.Id,
                        IngredientId = ingredient.Id
                    };

                    // Add that entity into the database
                    _context.Entry(newIngredientJoin).State = EntityState.Added;         
                }
            }

            // Save All the Changes
            await _context.SaveChangesAsync();            

            return true;
        }

        public async Task RemoveDish(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(dish).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public int NumberOfRecipes(int dishId)
        {
            var number = _context.DishRecipes.Count(x => x.DishId == dishId);

            return number;
        }

        private async Task<DishDTO> ConvertDish(Dish dish)
        {
            var allrecipes = await _recipe.GetRecipesForDish(dish.Id);

            return new DishDTO()
            {
                Name = dish.Name,
                Type = dish.DishType,
                Recipes = allrecipes
            };
        }
    }
}
