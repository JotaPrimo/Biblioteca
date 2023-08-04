using Biblioteca.Models;
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
            List<CategoriaLivro> categorias = _categoriaLivroRepository.GetAll.ToList();

            return View(categorias);
        }

    }
}
