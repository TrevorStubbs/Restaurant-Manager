using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.DTOs
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishDTO> Dishes { get; set; }
        public MenuType Type { get; set; }
    }
}
