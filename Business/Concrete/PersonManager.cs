using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        IPersonDal _personDal;
        IPhotoService _photoService;
        public PersonManager(IPersonDal personDal, IPhotoService photoService)
        {
            _personDal = personDal;
            _photoService = photoService;
        }

        private int calculateAge(DateTime birthDate)
        {
            // Yıl farkı
            int age = DateTime.Today.Year - birthDate.Year;
            // Bu günün tarihinden yıl farkını çıkar. Doğum günü bu
            // tarihten büyük ise yılı bir azalt.
            // (Açıklaması altta)
            if (birthDate > DateTime.Today.AddYears(-age))
                age--;
            return age;
        }

        public IDataResult<int> AddPerson(PersonDetailDTO person)
        {
            try
            {
                if (person != null)
                {
                    Person addPerson = new Person();

                    if (!string.IsNullOrEmpty(person.PhotoFile))
                    {
                        
                    }

                    addPerson.Name = person.Name;
                    addPerson.Surname = person.Surname;
                    addPerson.BirthDate = person.BirthDate;
                    addPerson.CityID = person.CityID;
                    addPerson.Age = calculateAge(person.BirthDate);
                    addPerson.Gender = person.Gender;
                    addPerson.PhotoFile = person.PhotoFile;

                    var isAdded = _personDal.Add(addPerson);

                    if (isAdded)
                    {
                        return new SuccessDataResult<int>(addPerson.Age,"Kişi veritabanına eklendi.");
                    }
                    else
                    {
                        return new ErrorDataResult<int>("Kişi veritabanına eklenemedi.");
                    }
                }
                return new ErrorDataResult<int>("Kişi bulunamadı.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<List<Person>> GetAll()
        {
            try
            {
                var personList = _personDal.GetAll();
                if (personList != null && personList.Count > 0)
                {
                    return new SuccessDataResult<List<Person>>("Kişiler getirildi.");
                }
                else
                {
                    return new ErrorDataResult<List<Person>>("Kişi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<List<PersonDetailDTO>> GetAllPersonDetails()
        {
            try
            {
                var personList = _personDal.GetAllPersonDetails();
                if (personList != null && personList.Count > 0)
                {
                    return new SuccessDataResult<List<PersonDetailDTO>>(personList,"Kişiler getirildi.");
                }
                else
                {
                    return new ErrorDataResult<List<PersonDetailDTO>>("Kişi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<Person> GetByPersonID(int personID)
        {
            try
            {
                var person = _personDal.GetByPersonID(personID);
                if (person != null)
                {
                    return new SuccessDataResult<Person>("Kişi getirildi.");
                }
                else
                {
                    return new ErrorDataResult<Person>("Kişi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<PersonDetailDTO> GetPersonDetailsByID(int personID)
        {
            try
            {
                var person = _personDal.GetPersonDetailsByID(personID);
                if (person != null)
                {
                    return new SuccessDataResult<PersonDetailDTO>("Kişi getirildi.");
                }
                else
                {
                    return new ErrorDataResult<PersonDetailDTO>("Kişi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
