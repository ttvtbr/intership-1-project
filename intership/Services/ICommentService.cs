
using intership.Models;
using System.Threading.Tasks;

namespace intership.Services
{
    public interface ICommentService
    {
        Task<Comment> CreateAsync(Comment comment);
    }
}
