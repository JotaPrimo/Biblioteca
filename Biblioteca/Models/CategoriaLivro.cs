using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("categoria_Livros")]
    public class CategoriaLivro
    {
        const int NAO_DELETADO = 0;
        const int DELETADO = 1;

        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        
        [Column(TypeName = "TEXT")]       
        public string Descricao { get; set; }

        [Column(TypeName = "INT")]
        public int Deletado { get; set; } = NAO_DELETADO;
        public DateTime Created_at { get; set; }
        public DateTime? Deleted_at { get; set; }

        public bool isDeletado() => this.Deletado == DELETADO;

        public String returnCreatedAtFormatado() =>  Created_at.ToString("dd/MM/yyyy");

        public String returnDeletedAtFormatado()
        {
            if (isDeletado())
            {
                return Created_at.ToString("dd/MM/yyyy");
            }

            return "";
        }
       
       
    }
}
