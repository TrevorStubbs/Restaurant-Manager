using LightningLawInterviewRound1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Applicant change - This was returning just a Ingredients not IngredientDTOs
        public List<IngredientDTO> Ingredients { get; set; }
    }
}
