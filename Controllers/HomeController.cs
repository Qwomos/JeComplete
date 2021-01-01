using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeComplete.Models;

namespace JeComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeIndexModel model = new HomeIndexModel();
            
            model.Autocomplete = new AutocompleteModel 
            {
                Id = "ddlSearch"
            };

            return View(model);
        }
    }
}
