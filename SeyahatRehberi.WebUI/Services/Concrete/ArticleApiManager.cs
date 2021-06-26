using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        public async Task<ArticleResponseModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("getall");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticleResponseModel>(await response.Content
                    .ReadAsStringAsync());
             
            }

            return null;

        }

        public async Task<ArticleResponseModel> GetAllByCityAsync(int cityId)
        {
            var response = await _httpClient.GetAsync("getbycity?cityid="+ cityId);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ArticleResponseModel>(await response.Content
                    .ReadAsStringAsync());

            }

            return null;

        }


    }
}
