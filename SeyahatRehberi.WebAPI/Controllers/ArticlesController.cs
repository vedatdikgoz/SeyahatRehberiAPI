using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SeyahatRehberi.Business.Abstract;
using SeyahatRehberi.Business.Constants;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.Entities.DTOs;
using SeyahatRehberi.WebAPI.Enums;
using SeyahatRehberi.WebAPI.Models;

namespace SeyahatRehberi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _articleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _articleService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycity")]
        public IActionResult GetByCity(int cityId)
        {
            var result = _articleService.GetAllByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyuser")]
        public IActionResult GetByUser(int userId)
        {
            var result = _articleService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getarticledetails")]
        public IActionResult GetArticleDetails()
        {
            var result = _articleService.GetArticleDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        

        [HttpPost("add")]
        public IActionResult Add([FromForm]ArticleAddModel articleAddModel)
        {
            var uploadModel = UploadFile(articleAddModel.Image, "image/jpeg");

            if (uploadModel.UploadState==UploadState.Success)
            {
                articleAddModel.ImagePath = uploadModel.NewName;
                var result = _articleService.Add(_mapper.Map<Article>(articleAddModel));
                if (result.Success)
                {

                    return Ok(result);
                }
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var result = _articleService.Add(_mapper.Map<Article>(articleAddModel));
                if (result.Success)
                {

                    return Ok(result);
                }
            }

            return BadRequest(Messages.FailedToLoad);
        }


        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromForm] ArticleUpdateModel articleUpdateModel)
        {
            if (id != articleUpdateModel.ArticleId)
            {
                return BadRequest("Geçersiz id");
            }
            var uploadModel =  UploadFile(articleUpdateModel.Image, "image/jpeg");
            if (uploadModel.UploadState == UploadState.Success)
            {
                var updatedArticle =  _articleService.GetById(articleUpdateModel.ArticleId).Data;
                updatedArticle.ArticleName = articleUpdateModel.ArticleName;
                updatedArticle.ArticleContent = articleUpdateModel.ArticleContent;
                updatedArticle.ImagePath = uploadModel.NewName;
                _articleService.Update(_mapper.Map<Article>(updatedArticle));
                return NoContent();
                
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var updatedArticle =  _articleService.GetById(articleUpdateModel.ArticleId).Data;
                updatedArticle.ArticleName = articleUpdateModel.ArticleName;
                updatedArticle.ArticleContent = articleUpdateModel.ArticleContent;
                _articleService.Update(_mapper.Map<Article>(updatedArticle));                 
                return NoContent();
                
            }
            else
            {
                return BadRequest(Messages.FailedToUpdated);
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete( _articleService.GetById(id).Data);
            return NoContent();
        }




        //////////////////////////////////////////////////////////////////////////

        public UploadModel UploadFile(IFormFile file, string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyTo(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;

            }

            return uploadModel;
        }

    }
}
