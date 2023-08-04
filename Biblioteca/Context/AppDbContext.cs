using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteca.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // db sets para mapear as models para o banco
        public DbSet<CategoriaLivro>? CategoriaLivros { get; set; }
        public DbSet<FormacaoAcademica> FormacaoAcademicas { get; set; }

    }

}
