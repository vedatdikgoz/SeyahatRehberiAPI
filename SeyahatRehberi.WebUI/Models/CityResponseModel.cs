using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{
    public class CityResponseModel
    {
        [JsonProperty("data")]
        public List<CityListModel> Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
