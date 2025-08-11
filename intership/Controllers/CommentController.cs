
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using intership.Services;
using intership.DTOs;
using intership.Models;

namespace intership.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _comments;
        private readonly IMapper _mapper;

        public CommentController(ICommentService comments, IMapper mapper)
        {
            _comments = comments;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity = _mapper.Map<Comment>(dto);
            await _comments.CreateAsync(entity);
            return RedirectToAction("Details", "Post", new { id = dto.PostId });
        }
    }
}
