using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.BLL.Managers;
using ProiectDAW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerManager manager;

        public ManufacturerController(IManufacturerManager manufacturerManager)
        {
            this.manager = manufacturerManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetManufacturers()
        {
            var manufacturers = manager.GetManufacturers();

            return Ok(manufacturers);
        }

        [HttpGet("with-cars")]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetCarsForManufacturers()
        {
            var manufacturers = manager.GetCarsForManufacturers();

            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById([FromRoute] int id)
        {
            var manufacturer = manager.GetManufacturerById(id);

            return Ok(manufacturer);
        }

        [HttpPost("")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ManufacturerModel model)
        {
            manager.Create(model);

            return Ok(manager.GetManufacturers());
        }

        [HttpPut("")]
        //[Authorize(Policy = "Moderator")]
        public async Task<IActionResult> Update([FromBody] ManufacturerModel model)
        {
            manager.Update(model);

            return Ok(manager.GetManufacturers());
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok(manager.GetManufacturers());
        }

    }
}
