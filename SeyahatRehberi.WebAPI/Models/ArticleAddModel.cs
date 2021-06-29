using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SeyahatRehberi.WebAPI.Models
{
    public class ArticleAddModel
    {
        public int ArticleId { get; set; }
        public int CityId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public IFormFile Image { get; set; }
    }
}
