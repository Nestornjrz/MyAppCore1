using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCore1.ViewComponents
{
    public class SaludoViewComponent: ViewComponent
    {
        private ISaludo _saludo;
        public SaludoViewComponent(ISaludo saludo) {
            _saludo = saludo;
        }
        public IViewComponentResult Invoke() {
            var model = _saludo.GetSaludo();
            return View("Default",model);
        }
    }
}
