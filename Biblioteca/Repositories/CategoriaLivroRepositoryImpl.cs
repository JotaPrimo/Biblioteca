﻿using Biblioteca.Context;
using Biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories
{
    public class CategoriaLivroRepositoryImpl : ICategoriaLivroRepository
    {

        private readonly AppDbContext _dbContext;

        public CategoriaLivroRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IQueryable<CategoriaLivro> ReturnQuerable => _dbContext.CategoriaLivros.AsQueryable();

        public IEnumerable<CategoriaLivro> GetAll => _dbContext.CategoriaLivros.ToList();

        public CategoriaLivro FindById(int id)
        {
            return _dbContext.CategoriaLivros.FirstOrDefault(categoriaLivro => categoriaLivro.Id == id);
        }

        public CategoriaLivro Create(CategoriaLivro categoriaLivro)
        {
            _dbContext.Add(categoriaLivro);
            _dbContext.SaveChanges();
            return categoriaLivro;
        }     
         

        public void Delete(int id)
        {
            var categoria = _dbContext.CategoriaLivros.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
            {
                _dbContext.CategoriaLivros.Remove(categoria);
                _dbContext.SaveChanges();
            }
        }

        public void Update(int idCategoriaLivro, CategoriaLivro categoriaLivro)
        {
            var existingCategoria = _dbContext.CategoriaLivros.FirstOrDefault();

            if (existingCategoria == null)
            {
                throw new Exception("Registro não encontrado");

            }

            existingCategoria.Descricao = categoriaLivro.Descricao;
            existingCategoria.Nome = categoriaLivro.Nome;
            _dbContext.SaveChanges();


        }

    }


}
