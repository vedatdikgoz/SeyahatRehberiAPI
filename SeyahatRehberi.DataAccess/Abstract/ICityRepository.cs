using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.DataAccess;
using SeyahatRehberi.Entities.Concrete;

namespace SeyahatRehberi.DataAccess.Abstract
{
    public interface ICityRepository : IEntityRepository<City>
    {
    }
}
