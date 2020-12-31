using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MenuType Type { get; set; }
    }
}
