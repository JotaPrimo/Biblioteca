﻿using Biblioteca.Context;
using Biblioteca.Models;
using Biblioteca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
