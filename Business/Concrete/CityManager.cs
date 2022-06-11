using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IDataResult<List<City>> GetAll()
        {
            try
            {
                var cityList = _cityDal.GetAll();
                if (cityList != null && cityList.Count > 0)
                {
                    return new SuccessDataResult<List<City>>(cityList, "Şehirler getirildi.");
                }
                else
                {
                    return new ErrorDataResult<List<City>>("Şehir bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<City> GetByCityID(int cityID)
        {
            try
            {
                var city = _cityDal.GetByCityID(cityID);
                if (city != null)
                {
                    return new SuccessDataResult<City>(city, "Şehir getirildi.");
                }
                else
                {
                    return new ErrorDataResult<City>("Şehir bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
