using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.DataAccess;
using SeyahatRehberi.Entities.Concrete;
using SeyahatRehberi.Entities.DTOs;

namespace SeyahatRehberi.DataAccess.Abstract
{
    public interface IArticleRepository : IEntityRepository<Article>
    {
        List<ArticleDetailDto> GetArticleDetails();
    }
}
