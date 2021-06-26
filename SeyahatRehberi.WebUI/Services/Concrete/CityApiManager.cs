using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Services.Concrete
{
    public class CityApiManager:ICityApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CityApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44317/api/cities/");
        }
        public async Task<CityResponseModel> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("getall");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CityResponseModel>(await response.Content
                    .ReadAsStringAsync());

            }

            return null;

        }
    }
}
