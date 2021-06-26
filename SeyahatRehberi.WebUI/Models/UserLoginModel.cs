

using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{
    public class UserLoginModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
