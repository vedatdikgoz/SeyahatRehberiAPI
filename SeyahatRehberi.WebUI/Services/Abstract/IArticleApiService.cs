using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Models;


namespace SeyahatRehberi.WebUI.Services.Abstract
{
    public interface IArticleApiService
    {
        Task<ArticleResponseModel> GetAllAsync();
        Task<ArticleResponseModel> GetAllByCityAsync(int cityId);
    }
}
