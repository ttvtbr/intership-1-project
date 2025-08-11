
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using intership.Services;
using intership.DTOs;
using intership.Models;

namespace intership.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _posts;
        private readonly IMapper _mapper;

        public PostController(IPostService posts, IMapper mapper)
        {
            _posts = posts;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _posts.GetAllAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PostDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            var entity = _mapper.Map<Post>(dto);
            await _posts.CreateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var post = await _posts.GetByIdAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }
    }
}
