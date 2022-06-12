using AgeCalculator_APP.Models.Entity;
using AgeCalculator_APP.Models.Enum;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Controllers
{
    public class PieChartController : Controller
    {
        IPersonService _personService;
        public PieChartController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeGenderResult()
        {
            return Json(PersonGenderList().ToList());
        }

        public List<PersonGenderModel> PersonGenderList()
        {
            var result = _personService.GetAllPersonDetails();
            
            var peopleList = result.Data;
            
            List<PersonGenderModel> repartitions = new List<PersonGenderModel>();

            var genderMale = new PersonGenderModel();
            genderMale.gender = "Kadın";
            genderMale.count = peopleList.Where(x => x.Gender == 1).Select(y => y.PersonID).Count();

            var genderFemale = new PersonGenderModel();
            genderFemale.gender = "Erkek";
            genderFemale.count = peopleList.Where(x => x.Gender == 2).Select(y => y.PersonID).Count();

            repartitions.Add(genderFemale);
            repartitions.Add(genderMale);

            return repartitions;
        }
    }
}
