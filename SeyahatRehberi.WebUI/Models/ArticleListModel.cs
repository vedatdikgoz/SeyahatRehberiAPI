using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{

    public class ArticleListModel
    {
        [JsonPropertyName("articleId")]
        public int ArticleId { get; set; }
        [JsonPropertyName("cityId")]
        public int CityId { get; set; }
        [JsonPropertyName("articleName")]
        public string ArticleName { get; set; }
        [JsonPropertyName("articleContent")]
        public string ArticleContent { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

    }
}
