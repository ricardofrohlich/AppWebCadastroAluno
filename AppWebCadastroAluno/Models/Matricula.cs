using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebCadastroAluno.Models
{
    public class Matricula
    {
        [Display(Name = "Id da Matricula")]
        [Key]
        public int MatriculaId { get; set; }
        [Required]
        [Display (Name = "Ano de ingresso")]
        public int AnoIngresso { get; set; }
        //chaves estrangeiras - são as conexões com as duas classes que geraram esta
        [Display(Name = "ID do aluno")]
        public int AlunoId { get; set; }

        [Display(Name="ID do curso")]
        public int CursoId { get; set; }

        [ForeignKey("AlunoId")]
        public virtual Aluno? Aluno { get; set; }

        [Display(Name = "Curso matriculado")]
        [ForeignKey("CursoId")]
        public virtual Curso? Curso { get; set; }

        public ICollection<MatriculaDisciplina>? MatriculasDisciplina { get; set; } //Carregamento dos regisrtos que estao relacionados
    }
}
