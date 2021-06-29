using System;
using System.Collections.Generic;
using System.Text;
using SeyahatRehberi.Core.Entities;
using SeyahatRehberi.Entities.Concrete;

namespace SeyahatRehberi.Entities.DTOs
{
    public class ArticleDetailDto:IDto
    {
        public int ArticleId { get; set; }
        public string CityName { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
