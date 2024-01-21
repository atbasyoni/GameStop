using GameStop.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStop.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDBContext _context;

        public GamesController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateGameVM vModel = new()
            {
                Categories = _context.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .ToList(),
                Devices = _context.Devices
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .ToList()
            };
            return View(vModel);
        }

        [HttpPost]
        public IActionResult Create(CreateGameVM vModel)
        {
            return View();
        }
    }
}
