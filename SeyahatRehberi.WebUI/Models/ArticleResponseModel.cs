using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SeyahatRehberi.WebUI.Models
{
    
    public class ArticleResponseModel
    {
        [JsonProperty("data")]
        public List<ArticleListModel> Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
        
    }

  
}



