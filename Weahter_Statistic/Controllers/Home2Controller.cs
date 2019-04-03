using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Weather_Statistic.Controllers
{

    /// <summary>
    /// Past data of page
    /// </summary>
    public partial class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Searcher(int days)
        {
            ViewBag.flag = false;
            ViewBag.operation = "Town";
            ViewBag.days = days;
            return View();
        }

        [HttpGet]
        public IActionResult Town(string town, int days = 1)
        {
            ViewBag.flag = true;
            ViewBag.operation = "Town";
            ViewBag.days = days;
            var models = collect.CreateList(town, days);
            return View("Searcher", models);
        }

        public IActionResult SearcherTwo(int days)
        {
            ViewBag.flag = false;
            ViewBag.days = days;
            return View();
        }

        [HttpGet]
        public IActionResult TwoTowns(string town1, string town2, int days = 1)
        {
            ViewBag.flag = true;
            ViewBag.days = days;
            var models = collect.CreateList(town1, town2, days);

            return View("SearcherTwo", models);
        }

        public IActionResult ManyDaysCity(int days = 3)
        {
            ViewBag.flag = false;
            ViewBag.days = days;
            return View();
        }

        public IActionResult ManyDaysCityResult(string town, int days)
        {
            ViewBag.flag = true;
            ViewBag.days = days;
            var models = collect.CreateList(town, days);
            return View("ManyDaysCity", models);
        }
        public IActionResult ManyDaysCompares(int days = 2)
        {
            ViewBag.flag = false;
            ViewBag.days = days;
            return View();
        }

        public IActionResult ManyDaysComparesResult(string town1, string town2, int days)
        {
            ViewBag.flag = true;
            ViewBag.days = days;
            var models = collect.CreateList(town1, town2, days);
            return View("ManyDaysCompares", models);
        }
    }
}