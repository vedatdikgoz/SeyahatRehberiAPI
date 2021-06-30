using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SeyahatRehberi.WebUI.Models
{
    public class ArticleUpdateModel
    {
        public int ArticleId { get; set; }
        public int CityId { get; set; }
        [Display(Name = "Makale Başlığı")]
        public string ArticleName { get; set; }
        [Display(Name = "İçerik")]
        public string ArticleContent { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "Resim Ekle")]
        public IFormFile Image { get; set; }
    }
}
