using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPersonDal
    {
        bool Add(Person person);
        List<Person> GetAll();
        Person GetByPersonID(int personID);
        PersonDetailDTO GetPersonDetailsByID(int personID);
        List<PersonDetailDTO> GetAllPersonDetails();
    }
}
