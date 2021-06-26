

using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{
    public class AccessTokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
    }
}
