using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.Models
{
    public class UserRegisterModel
    {
        [JsonProperty("email")]
        [Required]
        public string Email { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }

        [JsonProperty("firstname")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        [Required]
        public string LastName { get; set; }
    }
}
