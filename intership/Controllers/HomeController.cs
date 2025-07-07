using System.Diagnostics;
using intership.Models;
using Microsoft.AspNetCore.Mvc;

namespace intership.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _visitorCount = 0;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is the About page. Here you can find more information about our application and team.";
            return View();
        }

        public IActionResult VisitorCount()
        {
            _visitorCount++;
            return Json(new { count = _visitorCount });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
