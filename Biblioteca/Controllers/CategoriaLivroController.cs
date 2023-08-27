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

        [HttpPost]
        public IActionResult Delete(int id)
        {           
            // recuperando o registro do banco
            var categoriaLivro = _categoriaLivroRepository.FindById(id);

            // checando se o registro existe
            if (categoriaLivro == null)
            {
                TempData["error"] = "Registro não encontrado";
                return RedirectToAction("Index");
            }

            // deletando o registro
            _categoriaLivroRepository.Delete(id);

            // mensagem de alerta
            TempData["success"] = $"Categoria {categoriaLivro.Nome} foi deletada com sucesso";

            return RedirectToAction("Index");
        }



    }
}
