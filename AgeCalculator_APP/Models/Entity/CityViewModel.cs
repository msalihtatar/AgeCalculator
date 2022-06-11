using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Models.Entity
{
    public class CityViewModel
    {
        public int CityID { get; set; }
        public IList<City> Cities { get; set; }
    }
}
