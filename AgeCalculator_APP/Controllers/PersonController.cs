using AgeCalculator_APP.Models.Entity;
using AgeCalculator_APP.Models.Enum;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;

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

            //if (personViewModel.PhotoFile == null || personViewModel.PhotoFile.Length == 0)
            //    return Content("file not selected");
            
            var imageStr = string.Empty;
            if (personViewModel.PhotoFile != null)
            {
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        personViewModel.PhotoFile + ".jpg");

                byte[] b = System.IO.File.ReadAllBytes(path);
                imageStr = "data:image/png;base64," + Convert.ToBase64String(b);
            }

            PersonDetailDTO personDto = new PersonDetailDTO
            {
                Name = personViewModel.Name,
                Surname = personViewModel.Surname,
                BirthDate = personViewModel.BirthDate.Value,
                CityID = personViewModel.CityID,
                Gender = personViewModel.Gender,
                PhotoFile = string.IsNullOrEmpty(imageStr) ? null : imageStr
            };

            var result = _personService.AddPerson(personDto);

            if (result.Success)
            {
                personModel.Age = result.Data;
            }

            return View("CalculateAge",personModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
