using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CategoriaLivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
