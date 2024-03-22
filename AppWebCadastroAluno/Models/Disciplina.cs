using System.ComponentModel.DataAnnotations;

namespace AppWebCadastroAluno.Models
{
    public class Disciplina
    {
        [Key]
        [Display(Name ="Id da Disciplina")]
        public int DisciplinaId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set;  }
        [Required]
        [Display(Name="Carga Horária")]
        public int CargaHoraria { get; set; }
        [MaxLength(100)]
        public string Professor { get; set; }

        public ICollection<MatriculaDisciplina>? MatriculasDisciplina { get; set; } //Carregamento dos regisrtos que estao relacionados
    }
}
