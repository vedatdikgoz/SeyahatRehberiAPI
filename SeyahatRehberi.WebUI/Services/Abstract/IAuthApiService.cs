using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Models;

namespace SeyahatRehberi.WebUI.Services.Abstract
{
    public interface IAuthApiService
    {
        Task<bool> Login(UserLoginModel model);
        Task<bool> Register(UserRegisterModel model);
    }
}
