using Microsoft.AspNetCore.Identity;
using ProiectDAW.BLL.Models;
using ProiectDAW.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> signInManager, ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }

        public async Task<TokenModel> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if(user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
                if(result.Succeeded)
                {
                    var token = await tokenManager.GenerateToken(user);

                    return new TokenModel
                    {
                        AccessToken = token
                    };
                }
            }

            return null;
            
        }

        public async Task SignUp(RegisterModel registerModel)
        {
            var user = new User
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.RoleId);
            }
        }
    }
}
