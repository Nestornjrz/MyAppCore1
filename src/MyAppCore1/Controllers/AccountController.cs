using Microsoft.AspNetCore.Mvc;
using MyAppCore1.ViewModels;

namespace MyAppCore1.Controllers
{
    public class AccountController:Controller
    {
        [HttpGet]
        public IActionResult Register() {
            return View();
        }

    }
}
