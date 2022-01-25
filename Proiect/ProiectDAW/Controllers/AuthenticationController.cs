using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.BLL.Managers;
using ProiectDAW.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {
            try
            {
                await authenticationManager.SignUp(registerModel);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var tokens = await authenticationManager.Login(loginModel);

                if (tokens != null)
                {
                    return Ok(tokens);
                }
                else
                {
                    return BadRequest("Can't login");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Error while logging in");
            }
        }
    }
}
