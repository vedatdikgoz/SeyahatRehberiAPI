using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeyahatRehberi.WebUI.ExtensionMethods;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;


namespace SeyahatRehberi.WebUI.Services.Concrete
{
    public class ArticleApiManager : IArticleApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44317/api/articles/");
        }
        public async Task<ArticlesResponseModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("getall");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticlesResponseModel>(await response.Content
                    .ReadAsStringAsync());
             
            }

            return null;

        }

        public async Task<ArticlesResponseModel> GetAllByCityAsync(int cityId)
        {
            var response = await _httpClient.GetAsync("getbycity?cityid="+ cityId);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticlesResponseModel>(await response.Content
                    .ReadAsStringAsync());

            }

            return null;

        }


        public async Task<ArticlesResponseModel> GetAllByUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync("getbyuser?userid=" + userId);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticlesResponseModel>(await response.Content
                    .ReadAsStringAsync());

            }

            return null;

        }

        public async Task<ArticleResponseModel> GetByIdAsync(int articleId)
        {
            var response = await _httpClient.GetAsync("getbyid?id=" + articleId);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticleResponseModel>(await response.Content
                    .ReadAsStringAsync());

            }

            return null;

        }



        public async Task AddAsync(ArticleAddModel model)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (model.Image != null)
            {
                var stream = new MemoryStream();
                await model.Image.CopyToAsync(stream);
                var bytes = stream.ToArray();

                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteContent, nameof(ArticleAddModel.Image), model.Image.FileName);
            }

            var user = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>("activeUser");

            model.UserId = user.Id;

            formData.Add(new StringContent(model.UserId.ToString()), nameof(ArticleAddModel.UserId));
            formData.Add(new StringContent(model.ArticleName), nameof(ArticleAddModel.ArticleName));
            formData.Add(new StringContent(model.ArticleContent), nameof(ArticleAddModel.ArticleContent));

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PostAsync("add", formData);
        }


        public async Task UpdateAsync(ArticleUpdateModel model)
        {
            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (model.Image != null)
            {
                var stream = new MemoryStream();
                await model.Image.CopyToAsync(stream);
                var bytes = stream.ToArray();

                ByteArrayContent byteContent = new ByteArrayContent(bytes);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(model.Image.ContentType);

                formData.Add(byteContent, nameof(ArticleAddModel.Image), model.Image.FileName);
            }

            var user = _httpContextAccessor.HttpContext.Session.GetObject<UserViewModel>("activeUser");

            model.UserId = user.Id;

            formData.Add(new StringContent(model.ArticleId.ToString()), nameof(ArticleUpdateModel.ArticleId));
            formData.Add(new StringContent(model.UserId.ToString()), nameof(ArticleUpdateModel.UserId));
            formData.Add(new StringContent(model.ArticleName), nameof(ArticleUpdateModel.ArticleName));
            formData.Add(new StringContent(model.ArticleContent), nameof(ArticleUpdateModel.ArticleContent));
            

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                _httpContextAccessor.HttpContext.Session.GetString("token"));

            await _httpClient.PutAsync($"update/{model.ArticleId}", formData);
        }


        public async Task DeleteAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                _httpContextAccessor.HttpContext.Session.GetString("token"));
            await _httpClient.DeleteAsync($"delete/{id}");

        }
    }
}
