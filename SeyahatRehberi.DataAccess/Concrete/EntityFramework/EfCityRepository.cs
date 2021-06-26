using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Core.DataAccess.EntityFramework;
using SeyahatRehberi.DataAccess.Abstract;
using SeyahatRehberi.DataAccess.Concrete.Context;
using SeyahatRehberi.Entities.Concrete;

namespace SeyahatRehberi.DataAccess.Concrete.EntityFramework
{
    public class EfCityRepository: EfEntityRepositoryBase<City, DataContext>, ICityRepository
    {
    }
}
