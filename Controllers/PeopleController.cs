using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JeComplete.Services;
using JeComplete.Models;

namespace JeComplete.Controllers
{
    public class PeopleController : Controller 
    {

        private readonly ILogger<HomeController> Logger;
        private readonly PersonService Service;

        public PeopleController (ILogger<HomeController> logger, PersonService service)
        {
            Logger = logger;
            Service = service;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            PeopleListModel model = new PeopleListModel()
            {
                PeopleList = Service.GetPeopleList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult PersonnelFile(string id)
        {
            PersonnelFileModel model = new PersonnelFileModel
            {
                Person = Service.GetPerson(id)
            };

            if (model.Person != null)
                ViewData["Title"] = $"Dossier personnel de {model.Person.FirstName} {model.Person.LastName}";

            return View(model);
        }

        [HttpGet]
        public IActionResult SearchPeopleByNames(string query)
        {
            return Json(Service.SearchPeopleByNames(query));
        }
    }
}