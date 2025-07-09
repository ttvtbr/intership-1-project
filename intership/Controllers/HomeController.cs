using System.Diagnostics;
using intership.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace intership.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int _visitorCount = 0;

        // Static dictionary to track likes per visitor (by IP) and item
        private static Dictionary<string, Dictionary<int, int>> _visitorLikes = new Dictionary<string, Dictionary<int, int>>();

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

        // Returns how many times the current visitor liked a specific item
        public IActionResult LikeCount(int itemId)
        {
            var visitorIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            int likeCount = 0;

            if (_visitorLikes.TryGetValue(visitorIp, out var itemLikes))
            {
                itemLikes.TryGetValue(itemId, out likeCount);
            }

            return Json(new { itemId = itemId, likeCount = likeCount });
        }

        // Increments and returns the like count for the current visitor and item
        [HttpPost]
        public IActionResult LikeItem(int itemId)
        {
            var visitorIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            if (!_visitorLikes.ContainsKey(visitorIp))
            {
                _visitorLikes[visitorIp] = new Dictionary<int, int>();
            }

            if (!_visitorLikes[visitorIp].ContainsKey(itemId))
            {
                _visitorLikes[visitorIp][itemId] = 0;
            }

            _visitorLikes[visitorIp][itemId]++;

            return Json(new { itemId = itemId, likeCount = _visitorLikes[visitorIp][itemId] });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }