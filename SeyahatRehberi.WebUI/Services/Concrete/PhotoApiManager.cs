using System;
using System.Net.Http;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Services.Abstract;

namespace SeyahatRehberi.WebUI.Services.Concrete
{
    public class PhotoApiManager : IPhotoApiService
    {
        private readonly HttpClient _httpClient;
        public PhotoApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44317/api/images/");
        }

        public async Task<string> GetArticleImageByIdAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"getarticleimagebyid/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();
                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }

            return null;
        }
    }
}
