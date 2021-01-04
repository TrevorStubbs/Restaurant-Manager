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
    public class RecipeService : IRecipe
    {
        private LightningLawInterviewRound1Context _context;

        public RecipeService(LightningLawInterviewRound1Context context)
        {
            _context = context;
        }

        public async Task<RecipeDTO> GetById(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            return Convert(recipe);
        }

        private RecipeDTO Convert(Recipe recipe)
        {
            return new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name
            };
        }

        public async Task<List<RecipeDTO>> GetRecipesForDish(int dishId)
        {
            // Applicant - Here is an error that was causing a infinite loop. GetRecipesForDish was called instead of GetRecipes
            
            var recipes = await GetRecipes(dishId);
            List<RecipeDTO> allrecipes = new List<RecipeDTO>();

            foreach (var item in recipes)
            {
                allrecipes.Add(await GetById(item.Id));
            }

            return allrecipes;

        }


        private async Task<List<Recipe>> GetRecipes(int dishId)
        {
            return await _context.DishRecipes.Where(x => x.DishId == dishId).Include(x => x.Recipe).Select(x => x.Recipe).ToListAsync();
        }

    }
}
