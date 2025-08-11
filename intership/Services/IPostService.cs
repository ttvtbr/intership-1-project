
using intership.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace intership.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post post);
    }
}
