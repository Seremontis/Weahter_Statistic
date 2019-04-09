using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Weather_Statistic.Models;

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
            if(town == null)
            {
                return RedirectToAction("Searcher");
            }
            else{ 
            ViewBag.flag = true;
            ViewBag.operation = "Town";
            ViewBag.days = days;
            var models = collect.CreateList(town, days);
            return View("Searcher", models);
            }
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
            if (town1 == null || town2 == null)
            {
                return RedirectToAction("SearcherTwo");
            }
            else
            {
            ViewBag.flag = true;
            ViewBag.days = days;
            var models = collect.CreateList(town1, town2, days);

            return View("SearcherTwo", models);
            }
        }

        public IActionResult ManyDaysCity(int days = 3)
        {
            ViewBag.flag = false;
            ViewBag.days = days;
            return View();
        }

        public IActionResult ManyDaysCityResult(string town, int days)
        {
            if (town == null)
            {
                return RedirectToAction("ManyDaysCity");
            }
            else
            {
                ViewBag.flag = true;
                ViewBag.days = days;
                var models = collect.CreateList(town, days);
                return View("ManyDaysCity", models);
            }
        }
        public IActionResult ManyDaysCompares(int days = 2)
        {
            ViewBag.flag = false;
            ViewBag.days = days;
            return View();
        }

        public IActionResult ManyDaysComparesResult(string town1, string town2, int days)
        {
            if (town1 == null || town2==null)
            {
                return RedirectToAction("ManyDaysCompares");
            }
            else
            {
                var models = collect.CreateList(town1, town2, days);
                StatisticOperation statistic = new StatisticOperation();
                ViewBag.DevTempTown1 = statistic.Devation(models.City1.Select(x => x.MaxTemp).ToArray());
                ViewBag.DevTempTown2 = statistic.Devation(models.City1.Select(x => x.MaxTemp).ToArray());
                ViewBag.DevPresTown1 = statistic.Devation(models.City1.Select(x => x.Pressure).ToArray());
                ViewBag.DevPresTown2 = statistic.Devation(models.City1.Select(x => x.Pressure).ToArray());
                ViewBag.flag = true;
                ViewBag.days = days;              
                return View("ManyDaysCompares", models);
            }
        }

    }
}