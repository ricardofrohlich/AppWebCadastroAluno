using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebCadastroAluno.Models
{
    public class Aluno
    {
        [Display(Name = "Id do aluno")]
        [Key]
        public int AlunoId { get; set; }
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        
        [Display(Name = "Endereço")]
        public virtual Endereco? Endereco { get; set; } //Lazy load


        public ICollection<Matricula>? Matriculas { get; set; } //Carregamento dos regisrtos que estao relacionados

    }
}
