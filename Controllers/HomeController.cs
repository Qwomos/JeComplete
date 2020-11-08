using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeComplete.Data;
using JeComplete.Models;

namespace JeComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
