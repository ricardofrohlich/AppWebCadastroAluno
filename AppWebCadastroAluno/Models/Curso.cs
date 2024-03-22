using System.ComponentModel.DataAnnotations;

namespace AppWebCadastroAluno.Models
{
    public class Curso
    {
        [Display(Name = "Id do curso")]
        [Key]
        public int CursoId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public int Anos { get; set; }
        [Required]
        public int Horas { get; set; }  


        //Conecart a minha classe curso com a classe Aluno através de uma classe Matricula

        public ICollection<Matricula>? Matriculas { get; set;} //Carregamento dos regisrtos que estao relacionados
    }
}
