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
        public async Task<bool> UpdateDish(UpdateDishDTO dish)
        {
            // TODO: Complete this method and write a (few?) test(s) to confirm its functionality. 
            // Completing this method may require usage of other services
            // A few things to remember with the update:
            // 1. When updating the dish, the recipe could change.
            // 2. A recipe consists of ingredients, which could also change
            return false;
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
