using System.Diagnostics;
using intership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace intership.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _visitorCount;
        private static Dictionary<string, Dictionary<int, int>> _visitorLikes = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

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

        public IActionResult LikeCount(int itemId)
        {
            var visitorIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var likeCount = _visitorLikes.TryGetValue(visitorIp, out var itemLikes) && itemLikes.TryGetValue(itemId, out var count)
                ? count
                : 0;
            return Json(new { itemId, likeCount });
        }

        [HttpPost]
        public IActionResult LikeItem(int itemId)
        {
            var visitorIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            if (!_visitorLikes.ContainsKey(visitorIp))
                _visitorLikes[visitorIp] = new Dictionary<int, int>();

            if (!_visitorLikes[visitorIp].ContainsKey(itemId))
                _visitorLikes[visitorIp][itemId] = 0;

            _visitorLikes[visitorIp][itemId]++;

            return Json(new { itemId, likeCount = _visitorLikes[visitorIp][itemId] });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
