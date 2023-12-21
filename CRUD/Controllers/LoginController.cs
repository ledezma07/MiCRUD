using CRUD.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CRUD.Controllers
{
    public class LoginController : Controller
    {
        private MiContext _miContext;

        public LoginController(MiContext miContext)
        {
            _miContext = miContext; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var user = await _miContext.Usuarios
                                .Where(x => x.Email == correo && x.Password == contrasena)
                                .FirstOrDefaultAsync();
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Correo o Contrasena incorrectos";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Logout()
        {
            //cambiar a la pantalla login
            return RedirectToAction("Index");
        }
        public async Task< IActionResult> CerrarSesion()
        {
          //  await HttpContext.SignOutAsync();//*CookieAuthenticationDefaults.AuthenticationScheme*/);
          //await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Login");
        }

    }
}
