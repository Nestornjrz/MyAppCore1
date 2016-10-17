using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAppCore1.Entities;
using MyAppCore1.ViewModels;
using System.Threading.Tasks;

namespace MyAppCore1.Controllers {
    public class AccountController : Controller {
        private SignInManager<User> _gerenciaDeLogeo;
        private UserManager<User> _gerenciaDeUsuario;

        public AccountController(UserManager<User> gerenciaDeUsuario, SignInManager<User> gerenciaDeLogeo) {
            _gerenciaDeUsuario = gerenciaDeUsuario;
            _gerenciaDeLogeo = gerenciaDeLogeo;

        }
        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model) {
            if (ModelState.IsValid) {
                var user = new User { UserName = model.Username };
                var createResul = await _gerenciaDeUsuario.CreateAsync(user, model.Password);
                if (createResul.Succeeded) {
                    await _gerenciaDeLogeo.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                } else {
                    foreach (var error in createResul.Errors) {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await _gerenciaDeLogeo.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var loginResult = await _gerenciaDeLogeo.PasswordSignInAsync(
                                       model.Username,
                                       model.Password,
                                       model.RememberMe, false);
                if (loginResult.Succeeded) {
                    if (Url.IsLocalUrl(model.ReturnUrl)) {
                        return Redirect(model.ReturnUrl);
                    }else {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            ModelState.AddModelError("","No se puede loguear");
            return View(model);
        }
    }
}
