using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
