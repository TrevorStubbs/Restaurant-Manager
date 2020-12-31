using LightningLawInterviewRound1.Data;
using LightningLawInterviewRound1.Models.DTOs;
using LightningLawInterviewRound1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningLawInterviewRound1.Models.Services
{
    public class MenuService : IMenu
    {
        private LightningLawInterviewRound1Context _context;
        private IDish _dish;

        public MenuService(LightningLawInterviewRound1Context context, IDish dish)
        {
            _context = context;
            _dish = dish;

        }
        public async Task<MenuDTO> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            MenuDTO dto = new MenuDTO
            {
                Id = menu.Id,
                Name = menu.Name,
                Type = menu.Type,
            };

            dto.Dishes = await _dish.GetDishesForMenu(id);

            return dto;
        }
    }
}
