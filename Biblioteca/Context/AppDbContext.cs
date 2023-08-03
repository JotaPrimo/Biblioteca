using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // db sets para mapear as models para o banco
        public DbSet<CategoriaLivro>? CategoriaLivros { get; set; }

    }

}
