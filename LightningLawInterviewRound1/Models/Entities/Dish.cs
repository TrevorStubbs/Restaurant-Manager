using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DishType DishType { get; set; }
    }
}
