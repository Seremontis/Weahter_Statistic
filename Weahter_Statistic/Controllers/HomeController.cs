using System.Diagnostics;
using System.Linq;
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
                StatisticOperation statistic = new StatisticOperation();
                ViewBag.flag = true;
                var models = collect.CreateListFuture(town);
                ViewBag.medianTemp = statistic.Median(models.Select(x => x.MaxTemp).ToArray());
                ViewBag.medianPressure = statistic.Median(models.Select(x => x.Pressure).ToArray());
                ViewBag.devationTemp = statistic.Devation(models.Select(x => x.MaxTemp).ToArray());
                ViewBag.devationPress = statistic.Devation(models.Select(x => x.Pressure).ToArray());
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
