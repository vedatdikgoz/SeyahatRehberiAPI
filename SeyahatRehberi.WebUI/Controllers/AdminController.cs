using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SeyahatRehberi.WebUI.ExtensionMethods;
using SeyahatRehberi.WebUI.Filters;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Controllers
{
    [JwtAuthorize]
    public class AdminController : Controller
    {
        private IArticleApiService _articleApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminController(IArticleApiService articleApiService, IHttpContextAccessor httpContextAccessor)
        {
            _articleApiService = articleApiService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var user = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>("activeUser");
            var articles = await _articleApiService.GetAllByUserAsync(user.Id);
            return View(articles);
        }


        [HttpGet]
        public IActionResult AddArticle()
        {
            return View(new ArticleAddModel());
        }


        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddModel model)
        {
            if (ModelState.IsValid)
            {
                await _articleApiService.AddAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var article = await _articleApiService.GetByIdAsync(id);

            return View(new ArticleUpdateModel
            {
                ArticleId = article.Data.ArticleId,
                ArticleName = article.Data.ArticleName,
                ArticleContent = article.Data.ArticleContent
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleUpdateModel model)
        { 
            if (ModelState.IsValid)
            {
                await _articleApiService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleApiService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
