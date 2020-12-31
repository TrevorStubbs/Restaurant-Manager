using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Entities
{
    public class MenuDishes
    {
        public int MenuId { get; set; }
        public int DishId { get; set; }

        public Menu Menu { get; set; }
        public Dish Dish { get; set; }
    }
}
