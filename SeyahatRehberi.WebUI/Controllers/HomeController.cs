using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleApiService _articleApiService;
        private readonly ICityApiService _cityApiService;

        public HomeController(IArticleApiService articleApiService, ICityApiService cityApiService)
        {
            _articleApiService = articleApiService;
            _cityApiService = cityApiService;
        }
        public async Task<IActionResult> Index()
        {

            var cities = await _cityApiService.GetAllAsync();
            
            return View(cities);
            
        }


        public async Task<IActionResult> Articles(int cityId)
        {
            var articles = await _articleApiService.GetAllByCityAsync(cityId);
            return View(articles);

        }
    }
}
