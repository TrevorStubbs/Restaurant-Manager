using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.DTOs;
using LightningLawInterviewRound1.Models.Entities;
using LightningLawInterviewRound1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Services
{
    public class IngredientService : IIngredient
    {
        private LightningLawInterviewRound1Context _context;

        public IngredientService(LightningLawInterviewRound1Context context)
        {
            _context = context;
        }

        public async Task<IngredientDTO> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            return Convert(ingredient);
        }

        private IngredientDTO Convert(Ingredient data)
        {
            return new IngredientDTO()
            {
                Id = data.Id,
                Name = data.Name
            };
        }
    }
}
