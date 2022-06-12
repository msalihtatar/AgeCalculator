using AgeCalculator_APP.Models.Entity;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeCalculator_APP.Controllers
{
    public class BarChartController : Controller
    {
        IPersonService _personService;
        public BarChartController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VisualizeAgeMeanResult()
        {
            return Json(PersonAgeMeanList().ToList());
        }

        public List<PersonAgeMeanModel> PersonAgeMeanList()
        {
            var result = _personService.GetAllPersonDetails();

            var peopleList = result.Data;

            List<PersonAgeMeanModel> repartitions = new List<PersonAgeMeanModel>();

            var range1 = new PersonAgeMeanModel();
            range1.range = "0-15";
            var ageSum1 = peopleList.Where(x => 0 <= x.Age && x.Age < 15).Select(y => y.Age).Sum();
            var count = peopleList.Where(x => 0 <= x.Age && x.Age < 15).Select(y => y.PersonID).Count();
            range1.mean = ageSum1 / count;

            var range2 = new PersonAgeMeanModel();
            range2.range = "15-30";
            range2.mean = peopleList.Where(x => 15 <= x.Age && x.Age < 30).Select(y => y.Age).Sum() / peopleList.Where(x => 15 <= x.Age && x.Age < 30).Select(y => y.PersonID).Count();

            var range3 = new PersonAgeMeanModel();
            range3.range = "30-45";
            range3.mean = peopleList.Where(x => 30 <= x.Age && x.Age < 45).Select(y => y.Age).Sum() / peopleList.Where(x => 30 <= x.Age && x.Age < 45).Select(y => y.PersonID).Count();

            var range4 = new PersonAgeMeanModel();
            range4.range = "45+";
            range4.mean = peopleList.Where(x => 45 <= x.Age).Select(y => y.Age).Sum() / peopleList.Where(x => 45 <= x.Age).Select(y => y.PersonID).Count();

            repartitions.Add(range1);
            repartitions.Add(range2);
            repartitions.Add(range3);
            repartitions.Add(range4);

            return repartitions;
        }
    }
}
