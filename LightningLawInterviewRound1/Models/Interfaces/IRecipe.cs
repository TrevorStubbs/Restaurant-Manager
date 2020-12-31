using LightningLawInterviewRound1.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Interfaces
{
    public interface IRecipe
    {
        Task<RecipeDTO> GetById(int id);
        Task<List<RecipeDTO>> GetRecipesForDish(int dishId);
    }
}
