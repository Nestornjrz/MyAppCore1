using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Models;
using MyAppCore1.Services;

namespace MyAppCore1.Controllers {
    public class HomeController:Controller
    {
        private IRestauranteData _restauranteData;

        public HomeController(IRestauranteData restauranteData) {
            _restauranteData = restauranteData;
        }
        public IActionResult Index() {
            var model = _restauranteData.GetAll();

            return View(model);
        }
    }
}
