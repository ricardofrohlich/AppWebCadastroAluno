using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebCadastroAluno.Models
{
    public class MatriculaDisciplina
    {
        [Key]
        public int MatriculaDsciplinaId { get; set; }

        [Display(Name = "ID da disciplina")]
        public int DisciplinaId { get; set; }

        [ForeignKey("DisciplinaId")]
        public virtual Disciplina? Disciplina { get; set; }


        [Display(Name = "ID da matricula")]
        public int MatriculaId { get; set; }

        [ForeignKey("MatriculaId")]
        public virtual Matricula? Matricula { get; set; }

    }
}
