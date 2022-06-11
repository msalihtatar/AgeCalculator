using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICityDal
    {
        List<City> GetAll();
        City GetByCityID(int cityID);
    }
}
