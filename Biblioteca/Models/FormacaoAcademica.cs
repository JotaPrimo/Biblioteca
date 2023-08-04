using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Biblioteca.Models
{
    [Table("formacao_academicas")]
    public class FormacaoAcademica
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }

}
