using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.Entities;
using SeyahatRehberi.Core.Entities.Concrete;

namespace SeyahatRehberi.Entities.Concrete
{
    public class Article:IEntity
    {
        public int ArticleId { get; set; }
        public int CityId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public City City { get; set; }

    }
}
