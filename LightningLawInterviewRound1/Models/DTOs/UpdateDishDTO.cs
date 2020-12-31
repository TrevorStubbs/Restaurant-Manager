using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.DTOs
{
    public class UpdateDishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DishType Type { get; set; }
        public List<RecipeDTO> Recipes { get; set; }
    }
}
