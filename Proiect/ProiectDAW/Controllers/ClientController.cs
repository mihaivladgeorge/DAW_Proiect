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
    public class ClientController : ControllerBase
    {
        private readonly IClientManager manager;

        public ClientController (IClientManager clientManager)
        {
            this.manager = clientManager;
        }

        [HttpGet("all")]
        [Authorize(Policy = "Moderator")]
        public async Task<IActionResult> GetClients()
        {
            var clients = manager.GetClients();

            return Ok(clients);
        }

        [HttpGet("with-rentals")]
        [Authorize(Policy = "Moderator")]
        public async Task<IActionResult> GetClientsWithRentals()
        {
            var clients = manager.GetClientsWithRentalsInfo();

            return Ok(clients);
        }

        [HttpGet("info")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetClientsInfo()
        {
            var clients = manager.GetClientsWithInfo();

            return Ok(clients);
        }

        [HttpGet("byId/{id}")]
        [Authorize(Policy = "Moderator")]
        public async Task<IActionResult> GetClientsById([FromRoute] int id)
        {
            var client = manager.GetClientById(id);

            return Ok(client);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClientModel clientModel)
        {
            manager.Create(clientModel);

            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Moderator")]
        public async Task<IActionResult> Update([FromBody] ClientModel clientModel)
        {
            manager.Update(clientModel);

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
