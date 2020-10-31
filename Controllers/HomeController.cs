using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeComplete.Data;
using JeComplete.Models.Home;

namespace JeComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBService _service;

        public HomeController(ILogger<HomeController> logger, DBService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            IndexModel model = new IndexModel {PeopleList = _service.PeopleList};

            return View(model);
        }
    }
}
