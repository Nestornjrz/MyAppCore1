using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Models;

namespace MyAppCore1.Controllers {
    public class HomeController:Controller
    {
        public IActionResult Index() {
            var model = new Restaurante { Id = 1, Nombre = "La casa de las empanadas" };

            return View(model);
        }
    }
}
