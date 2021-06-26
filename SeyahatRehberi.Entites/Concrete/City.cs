using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.Entities;

namespace SeyahatRehberi.Entities.Concrete
{
    public class City:IEntity
    {
        public int CityId { get; set; }
        public int PlateCode { get; set; }
        public string CityName { get; set; }
    }
}
