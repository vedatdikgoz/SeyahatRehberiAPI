using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeyahatRehberi.WebUI.Models;


namespace SeyahatRehberi.WebUI.Services.Abstract
{
    public interface IArticleApiService
    {
        Task<ArticlesResponseModel> GetAllAsync();
        Task<ArticlesResponseModel> GetAllByCityAsync(int cityId);
        Task<ArticleResponseModel> GetByIdAsync(int articleId);
        Task AddAsync(ArticleAddModel model);
        Task UpdateAsync(ArticleUpdateModel model);
        Task DeleteAsync(int id);

    }
}
