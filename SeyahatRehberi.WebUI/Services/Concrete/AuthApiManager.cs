using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SeyahatRehberi.WebUI.Models;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Services.Concrete
{
    public class AuthApiManager:IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:44317/api/auth/");
        }
        public async Task<bool> Login(UserLoginModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", content);
            
                if (response.IsSuccessStatusCode)
                {
                    var accessToken = JsonConvert.DeserializeObject<AccessTokenModel>(await response.Content.ReadAsStringAsync());
                    _httpContextAccessor.HttpContext.Session.SetString("token", accessToken.Token);
                    return true;
                }
            

            return false;
        }

        public async Task<bool> Register(UserRegisterModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("register", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
