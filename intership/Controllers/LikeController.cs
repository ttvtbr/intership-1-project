
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using intership.Services;

namespace intership.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService _likes;
        public LikeController(ILikeService likes) => _likes = likes;

        [HttpPost]
        public async Task<IActionResult> Toggle(int postId, string userName)
        {
            var count = await _likes.ToggleLikeAsync(postId, userName ?? "Anon");
            return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
