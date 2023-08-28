using Biblioteca.Models;

namespace Biblioteca.Repositories.Interfaces
{
    public interface ICategoriaLivroRepository
    {
        IQueryable<CategoriaLivro> ReturnQuerable { get; }
        IEnumerable<CategoriaLivro> GetAll { get; }
        CategoriaLivro FindById(int id);
        CategoriaLivro? Create(CategoriaLivro categoriaLivro);
        void Update(int IdCategoriaLivro, CategoriaLivro categoriaLivro);
        void Delete(int id);

    }
}
