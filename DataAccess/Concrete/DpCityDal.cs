using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class DpCityDal : ICityDal
    {
        IDbConnection _dbConnection;
        public DpCityDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<City> GetAll()
        {
            try
            {
                string sql = @"select * from City";

                var cityList = _dbConnection.Query<City>(sql).ToList();
                return cityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City GetByCityID(int cityID)
        {
            try
            {
                string sql = @"select * from City where CityID = " + cityID;

                var city = _dbConnection.Query<City>(sql).FirstOrDefault();
                return city;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
