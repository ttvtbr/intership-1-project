
using intership.Models;
using System.Threading.Tasks;

namespace intership.Services
{
    public interface ILikeService
    {
        Task<int> ToggleLikeAsync(int postId, string userName);
    }
}
