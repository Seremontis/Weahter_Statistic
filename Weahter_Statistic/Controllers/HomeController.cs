using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather_Statistic.Models;

namespace Weather_Statistic.Controllers
{
    /// <summary>
    ///  Main page and future date
    /// </summary>
    public partial class HomeController : Controller
    {
        private CollectData collect = new CollectData();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FutureDay()
        {
            ViewBag.flag = false;       
            return View();
        }

        public IActionResult FutureDayResult(string town)
        {
            if (town == null)
            {
                return RedirectToAction("FutureDay");
            }
            else
            {
                ViewBag.flag = true;
                var models = collect.CreateListFuture(town);
                return View("FutureDay", models);
            }
       
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
