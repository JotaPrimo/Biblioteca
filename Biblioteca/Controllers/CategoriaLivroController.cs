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

        [HttpGet]
        public IActionResult Index()
        {
            List<CategoriaLivro> categorias = _categoriaLivroRepository.GetAll.ToList();

            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create() =>  View();

        [HttpPost]
        public IActionResult Store(CategoriaLivro categoriaLivro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _categoriaLivroRepository.Create(categoriaLivro);
            TempData["success"] = "Categoria cadastrada com sucesso";

            return RedirectToAction("Index");
        }


    }
}
