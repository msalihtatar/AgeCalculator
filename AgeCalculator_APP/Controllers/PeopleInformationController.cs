using AgeCalculator_APP.Models.Entity;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Controllers
{
    public class PeopleInformationController : Controller
    {
        IPersonService _personService;
        ICityService _cityService;
        public PeopleInformationController(IPersonService personService, ICityService cityService)
        {
            _personService = personService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            List<PersonViewModel> personModelList = new List<PersonViewModel>();
            var peopleList = _personService.GetAllPersonDetails();
            var cityList = _cityService.GetAll();

            peopleList.Data.ForEach(x => {
                var person = new PersonViewModel
                {
                    PersonID = x.PersonID,
                    CityID = x.CityID,
                    Name = x.Name,
                    Surname = x.Surname,
                    BirthDate = x.BirthDate,
                    CityName = cityList.Data.Where(y => y.CityID == x.CityID).Select(z => z.CityName).FirstOrDefault(),
                    Age = x.Age,
                    GenderName = x.Gender == 1 ? "Kadın" : "Erkek"
                };

                personModelList.Add(person);
            });
            return View(personModelList);
        }

    }
}
