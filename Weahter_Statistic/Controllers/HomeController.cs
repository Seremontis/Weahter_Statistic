using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weahter_Statistic.Models;

namespace Weahter_Statistic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Searcher()
        {
            return View();
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
