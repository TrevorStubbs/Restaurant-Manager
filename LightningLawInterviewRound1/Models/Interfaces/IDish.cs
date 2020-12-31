using LightningLawInterviewRound1.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Interfaces
{
    public interface IDish
    {
        Task<DishDTO> GetDish(int id);
        Task<bool> UpdateDish(UpdateDishDTO dish);
        Task<List<DishDTO>> GetDishesForMenu(int menuId);
    }
}
