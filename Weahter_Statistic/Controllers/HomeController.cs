using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather_Statistic.Models;

namespace Weather_Statistic.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Searcher()
        {
            ViewBag.flag = false;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Town(string town)
        {
            ViewBag.flag= true;
            var Weather = new WeatherConnect();
            LocationName name = new LocationName();

            var address = name.GetPoint(town);         
            var model1 = await Weather.ResultOneSearch(address.Item1,address.Item2);
            model1.Place = address.Item3;

            return View("Searcher",model1);
        }

        public IActionResult SearcherTwo()
        {
            return View();
        }
        public IActionResult ManyDaysCity()
        {
            return View();
        }
        public IActionResult ManyDaysCompares()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
