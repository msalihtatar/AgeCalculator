using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<int> AddPerson(PersonDetailDTO person);
        IDataResult<List<Person>> GetAll();
        IDataResult<Person> GetByPersonID(int personID);
        IDataResult<PersonDetailDTO> GetPersonDetailsByID(int personID);
        IDataResult<List<PersonDetailDTO>> GetAllPersonDetails();
        Task<IDataResult<List<PersonDetailDTO>>> GetAllPersonDetailsAsync();
    }
}
