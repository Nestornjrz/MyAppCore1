using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Entities;
using MyAppCore1.Services;
using MyAppCore1.ViewModels;


namespace MyAppCore1.Controllers {
    [Authorize]
    public class HomeController : Controller {
        private IRestauranteData _restauranteData;
        private ISaludo _saludo;

        public HomeController(IRestauranteData restauranteData, ISaludo saludo) {
            _restauranteData = restauranteData;
            _saludo = saludo;
        }
        [AllowAnonymous]
        public IActionResult Index() {
            var model = new HomePageViewModel();
            model.Restaurantes = _restauranteData.GetAll();
            model.MensajeActual = _saludo.GetSaludo();

            return View(model);
        }       
        public IActionResult Details(int id) {
            var model = _restauranteData.Get(id);
            if (model == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var model = _restauranteData.Get(id);
            if (model == null) {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestauranteEditViewModel model) {
            var restaurante = _restauranteData.Get(id);
            if (ModelState.IsValid) {
                restaurante.Cosina = model.Cosina;
                restaurante.Nombre = model.Nombre;
                _restauranteData.Commit();
                return RedirectToAction("Details", id= restaurante.Id);
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestauranteEditViewModel model) {
            if (ModelState.IsValid) {
                var nuevoRestaurante = new Restaurante();
                nuevoRestaurante.Cosina = model.Cosina;
                nuevoRestaurante.Nombre = model.Nombre;

                nuevoRestaurante = _restauranteData.Add(nuevoRestaurante);
                _restauranteData.Commit();

                return RedirectToAction("Details", new { id = nuevoRestaurante.Id });
            }
            return View();
        }
    }
}
