using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Models;

namespace MyAppCore1.Controllers {
    public class HomeController:Controller
    {
        public IActionResult Index() {               
            return Content("Hola, desde el HomeController");
        }
    }
}
