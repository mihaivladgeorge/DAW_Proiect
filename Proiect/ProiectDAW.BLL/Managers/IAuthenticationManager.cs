using ProiectDAW.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDAW.BLL.Managers
{
    public interface IAuthenticationManager
    {
        Task SignUp(RegisterModel registerModel);

        Task<TokenModel> Login(LoginModel loginModel);
    }
}