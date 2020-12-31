using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightningLawInterviewRound1.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightningLawInterviewRound1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private IMenu _menu;

        public MenusController(IMenu menu)
        {
            _menu = menu;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu(int id)
        {
            var menu = await _menu.GetMenu(id);

            if (menu is null) return BadRequest("no menu found");

            return Ok(menu);
        }

    }
}
