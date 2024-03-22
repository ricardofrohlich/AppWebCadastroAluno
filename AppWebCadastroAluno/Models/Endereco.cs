using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebCadastroAluno.Models
{
    public class Endereco
    {
        [Display(Name = "Id do endereço")]
        [Key]
        public int EnderecoId { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Cidade { get; set; }

        public virtual Aluno? Aluno { get; set; } //requisito lazy load 
    }
}
