using Biblioteca.Context;
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


        private int _nextId = 1;

        public IEnumerable<CategoriaLivro> GetAll => _dbContext.CategoriaLivros;

        public CategoriaLivro FindById(int id)
        {
            return _dbContext.CategoriaLivros.FirstOrDefault(categoriaLivro => categoriaLivro.Id == id);
        }

        public CategoriaLivro Create(CategoriaLivro categoriaLivro)
        {
            _dbContext.Add(categoriaLivro);
            return categoriaLivro;
        }     
         

        public void Update(int id, CategoriaLivroDTO categoriaLivroDTO)
        {
            var existingCategoria = _dbContext.CategoriaLivros.FirstOrDefault(c => c.Id == id);

          
        }

        public void Delete(int id)
        {
            var categoria = _dbContext.CategoriaLivros.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
            {
                _dbContext.CategoriaLivros.Remove(categoria);
            }
        }

        public void Update(CategoriaLivro categoriaLivro)
        {
            throw new NotImplementedException();
        }
    }


}
