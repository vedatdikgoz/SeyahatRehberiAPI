using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeyahatRehberi.Business.Abstract;
using SeyahatRehberi.Business.BusinessAspects.Autofac;
using SeyahatRehberi.Business.Constants;
using SeyahatRehberi.Core.Utilities.Business;
using SeyahatRehberi.Core.Utilities.Results;
using SeyahatRehberi.DataAccess.Abstract;
using SeyahatRehberi.Entities.Concrete;

namespace SeyahatRehberi.Business.Concrete
{
    public class CityManager:ICityService
    {
        ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityRepository.GetAll(),Messages.CitiesListed);
        }

        //Select * from Cities where CityId = 4
        public IDataResult<City> GetById(int cityId)
        {
            return new SuccessDataResult<City>(_cityRepository.Get(c => c.CityId == cityId));
        }


        [SecuredOperation("admin")]
        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run(CheckIfCityNameExists(city.CityName));

            if (result != null)
            {
                return result;
            }

            _cityRepository.Add(city);

            return new SuccessResult(Messages.CityAdded);
        }


        private IResult CheckIfCityNameExists(string cityName)
        {
            var result = _cityRepository.GetAll(p => p.CityName == cityName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
