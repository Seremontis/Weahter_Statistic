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
        public IActionResult Town(string town)
        {
            ViewBag.flag= true;
            var Weather = new WeatherConnect();
            LocationName name = new LocationName();

            var address = name.GetPoint(town);         
            var model1 = Weather.ResultOneSearch(address.Item1,address.Item2).Result;
            model1.Place = address.Item3;

            return View("Searcher",model1);
        }

        public IActionResult SearcherTwo()
        {
            ViewBag.flag = false;
            return View();
        }

        [HttpGet]
        public IActionResult TwoTowns(string town1,string town2)
        {
            ViewBag.flag = true;
            var Weather = new WeatherConnect();
            LocationName name = new LocationName();
            MultiDayCompares models = new MultiDayCompares();
            (double, double, string)[] locations = { (name.GetPoint(town1)), (name.GetPoint(town2)) };

            var mod = Weather.ResultOneSearch(locations[0].Item1, locations[0].Item2).Result;
            models.City1.Add(mod);
            models.City1[0].Place=locations[0].Item3;
            mod = null;
            mod= Weather.ResultOneSearch(locations[1].Item1, locations[1].Item2).Result;
            models.City2.Add(mod);
            models.City2[0].Place = locations[1].Item3;
            
            
            return View("SearcherTwo", models);
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
