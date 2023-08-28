using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repositories.Interfaces;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class CategoriaLivroController : Controller
    {
        private readonly ICategoriaLivroRepository _categoriaLivroRepository;

        private readonly PdfService _pdfService;

        public CategoriaLivroController(ICategoriaLivroRepository categoriaLivroRepository, PdfService pdfService)
        {
            _categoriaLivroRepository = categoriaLivroRepository;
            _pdfService = pdfService;
        }

        [HttpGet]
        public IActionResult Index(string searchTerm)
        {
            List<CategoriaLivro> categorias;
            IQueryable<CategoriaLivro> categoriasQueryable = _categoriaLivroRepository.ReturnQuerable;

            if (! string.IsNullOrEmpty(searchTerm))
            {
                TempData["searchTerm"] = searchTerm;
                var dataFound = categoriasQueryable.Where(c => c.Nome.Contains(searchTerm));
                categorias = dataFound.ToList();
            }
            else
            {               
                categorias = _categoriaLivroRepository.GetAll.ToList();
            }          

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoriaLivro categoria = _categoriaLivroRepository.FindById(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Update(int id, CategoriaLivro categoriaLivro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoriaLivro categoria = _categoriaLivroRepository.FindById(id);

            _categoriaLivroRepository.Update(id, categoriaLivro);
            TempData["success"] = "Categoria atualizada com sucesso";

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

        public IActionResult GeneratePdf()
        {
            string htmlContent = "<html><body><h1 style='color: blue;'>Styled PDF Example</h1><p>This is a styled PDF generated using DinkToPdf.</p></body></html>";

            byte[] pdfBytes = _pdfService.GeneratePdf(htmlContent);

            return File(pdfBytes, "application/pdf", "StyledPDF.pdf");
        }


    }
}
