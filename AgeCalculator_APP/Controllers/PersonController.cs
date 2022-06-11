using AgeCalculator_APP.Models.Entity;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _personService;
        ICityService _cityService;

        PersonViewModel personModel = new PersonViewModel();

        public PersonController(ICityService cityService, IPersonService personService)
        {
            _personService = personService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CalculateAge()
        {
            var cityList = _cityService.GetAll();
            if (cityList.Success && cityList.Data.Count > 0)
            {
                personModel.Cities = cityList.Data;
            }

            return View(personModel);
        }

        [HttpPost]
        public IActionResult Calculate(PersonViewModel personViewModel)
        {
            var cityList = _cityService.GetAll();
            if (cityList.Success && cityList.Data.Count > 0)
            {
                personModel.Cities = cityList.Data;
            }

            if (!ModelState.IsValid)
            {
                personViewModel.Cities = cityList.Data;
                return View("CalculateAge", personViewModel);
            }
            personModel.Age = 17;



            return View("CalculateAge",personModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
