using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Person : IEntity
    {
        public int PersonID { get; set; }
        public string PhotoFile { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
    }
}
