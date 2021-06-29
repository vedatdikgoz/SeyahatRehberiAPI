using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeyahatRehberi.Business.Abstract;


namespace SeyahatRehberi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ImagesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("getarticleimagebyid/{id}")]
        public IActionResult GetArticleImageById(int id)
        {
            var article=  _articleService.GetById(id);
            if (string.IsNullOrWhiteSpace(article.Data.ImagePath))
            {
                return NotFound("resim yok");
            }
            return File($"/img/{article.Data.ImagePath}", "image/jpeg");
        }
    }
}
