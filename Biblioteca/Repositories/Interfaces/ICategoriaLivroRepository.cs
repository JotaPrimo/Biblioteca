using Biblioteca.Models;

namespace Biblioteca.Repositories.Interfaces
{
    public interface ICategoriaLivroRepository
    {
        IEnumerable<CategoriaLivro> GetAll { get; }
        CategoriaLivro FindById(int id);
        CategoriaLivro? Create(CategoriaLivro categoriaLivro);

        void Update(CategoriaLivro categoriaLivro);
        void Delete(int id);

    }
}
