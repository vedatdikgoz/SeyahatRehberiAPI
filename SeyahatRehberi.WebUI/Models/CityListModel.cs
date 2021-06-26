using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeyahatRehberi.WebUI.Models
{
    public class CityListModel
    {
        [JsonPropertyName("cityId")]
        public int CityId { get; set; }

        [JsonPropertyName("plateCode")]
        public int PlateCode { get; set; }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }
    }
}
