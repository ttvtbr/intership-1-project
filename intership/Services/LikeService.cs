
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using intership.Data;
using intership.Models;

namespace intership.Services
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;
        public LikeService(ApplicationDbContext context) => _context = context;

        public async Task<int> ToggleLikeAsync(int postId, string userName)
        {
            var existing = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserName == userName);
            if (existing == null)
            {
                _context.Likes.Add(new Like { PostId = postId, UserName = userName });
            }
            else
            {
                _context.Likes.Remove(existing);
            }
            await _context.SaveChangesAsync();
            return await _context.Likes.CountAsync(l => l.PostId == postId);
        }
    }
}
