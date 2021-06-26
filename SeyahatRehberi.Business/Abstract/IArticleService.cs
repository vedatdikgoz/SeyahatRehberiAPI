using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.Utilities.Results;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.Entities.DTOs;

namespace SeyahatRehberi.Business.Abstract
{
    public interface IArticleService
    {
        IDataResult<List<Article>> GetAll();
        IDataResult<List<Article>> GetAllByCityId(int id);
        IDataResult<List<ArticleDetailDto>> GetArticleDetails();
        IDataResult<Article> GetById(int articleId);
        IResult Add(Article article);
        IResult Update(Article article);
    }
}
