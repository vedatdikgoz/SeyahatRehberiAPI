using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;


namespace SeyahatRehberi.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authApiService;
        public AccountController(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (await _authApiService.Login(model))
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            if (await _authApiService.Register(model))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
