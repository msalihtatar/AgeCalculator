using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonDal
    {
        bool Add(Person person);
        List<Person> GetAll();
        Person GetByPersonID(int personID);
        PersonDetailDTO GetPersonDetailsByID(int personID);
        Task<List<PersonDetailDTO>> GetAllPersonDetailsAsync();

        List<PersonDetailDTO> GetAllPersonDetails();
    }
}
