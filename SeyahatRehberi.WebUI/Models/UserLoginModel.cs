

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{
    public class UserLoginModel
    {
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}
