using Biblioteca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class CategoriaLivroController : Controller
    {
        private readonly ICategoriaLivroRepository _categoriaLivroRepository;

        public CategoriaLivroController(ICategoriaLivroRepository categoriaLivroRepository)
        {
            _categoriaLivroRepository = categoriaLivroRepository;
        }

        public IActionResult Index()
        {
            var categorias = _categoriaLivroRepository.GetAll;

            return View(categorias);
        }

    }
}
