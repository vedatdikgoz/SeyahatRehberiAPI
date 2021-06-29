using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeyahatRehberi.Core.DataAccess.EntityFramework;
using SeyahatRehberi.DataAccess.Abstract;
using SeyahatRehberi.DataAccess.Concrete.Context;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.Entities.DTOs;

namespace SeyahatRehberi.DataAccess.Concrete.EntityFramework
{
    public class EfArticleRepository:EfEntityRepositoryBase<Article, DataContext>,IArticleRepository
    {
        
        public List<ArticleDetailDto> GetArticleDetails()
        {
            using (DataContext context = new DataContext())
            {
                var result = from p in context.Articles
                    join c in context.Cities
                        on p.CityId equals c.CityId
                    join u in context.Users on p.UserId equals u.Id
                    select new ArticleDetailDto
                    {
                        ArticleId = p.ArticleId,
                        ArticleName = p.ArticleName,
                        CityName = c.CityName,
                        ArticleContent = p.ArticleContent,
                        Author = u.FirstName +" "+ u.LastName,
                        CreatedDate = p.CreatedDate
                    };
                return result.ToList();
            }
        }

    }
}
