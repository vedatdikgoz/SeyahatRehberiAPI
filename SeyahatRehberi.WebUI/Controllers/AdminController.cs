using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Filters;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Controllers
{
    [JwtAuthorize]
    public class AdminController : Controller
    {
        private IArticleApiService _articleApiService;

        public AdminController(IArticleApiService articleApiService)
        {
            _articleApiService = articleApiService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleApiService.GetAllAsync();

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
