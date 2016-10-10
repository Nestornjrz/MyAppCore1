﻿using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Services;
using MyAppCore1.ViewModels;

namespace MyAppCore1.Controllers {
    public class HomeController:Controller
    {
        private IRestauranteData _restauranteData;
        private ISaludo _saludo;

        public HomeController(IRestauranteData restauranteData, ISaludo saludo) {
            _restauranteData = restauranteData;
            _saludo = saludo;
        }
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
    }
}
