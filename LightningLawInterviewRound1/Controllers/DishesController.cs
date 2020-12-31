using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightningLawInterviewRound1.Models.DTOs;
using LightningLawInterviewRound1.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightningLawInterviewRound1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private IDish _dish;

        public DishesController(IDish dish)
        {
            _dish = dish;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDish(int id)
        {
            var dish = await _dish.GetDish(id);
            if (dish is null) return BadRequest("No dish found");
            return Ok(dish);
        }

        [HttpPut]
        public async Task<IActionResult> GetDish(UpdateDishDTO dish)
        {
            //TODO: Compete this route, and ensure the proper data is being returned.
            var updated = await _dish.UpdateDish(dish);
            return Ok();
        }

    }
}
