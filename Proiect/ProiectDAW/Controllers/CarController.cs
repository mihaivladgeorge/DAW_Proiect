using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.BLL.Managers;
using ProiectDAW.DAL;
using ProiectDAW.DAL.Models;
using ProiectDAW.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarManager manager;

        public CarController (ICarManager carManager)
        {
            this.manager = carManager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetCars()
        {
            var cars = manager.GetCars();

            return Ok(cars);
        }

        [HttpGet("cars-manufacturer")]
        public async Task<IActionResult> CarsJoinManufac()
        {
            var carsJoinManufac = manager.GetCarsWithManufacturer();

            return Ok(carsJoinManufac);
        }

        [HttpGet("byId/{id}")]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var car = manager.GetCarById(id);

            return Ok(car);
        }

        [HttpGet("prices")]

        public async Task<IActionResult> GetPrices()
        {
            var cars = manager.GetCarsWithAvgPrice();

            return Ok(cars);
        }

        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] CarModel carModel)
        {
            manager.Create(carModel);

            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Moderator")]
        public async Task<IActionResult> Update([FromBody] CarModel carModel)
        {
            manager.Update(carModel);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

    }
}
