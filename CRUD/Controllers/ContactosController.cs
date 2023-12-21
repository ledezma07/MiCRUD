using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class ContactosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
