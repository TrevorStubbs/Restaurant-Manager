using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Entities
{
    public class DishRecipe
    {
        public int DishId { get; set; }
        public int RecipeId { get; set; }

        public Dish Dish { get; set; }
        public Recipe Recipe { get; set; }
    }
}
