using AppWebCadastroAluno.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebCadastroAluno.DAL
{
    public class INFNETContexto : DbContext
    {
        public INFNETContexto(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //aqui que vamos definir o relacionamento entre as classes
            //O relacionamento da classe Aluno com a ENdereco
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Endereco) //Definindo que um aluno se relciona com um endereco
                .WithOne(e => e.Aluno) // Indicando que um endereço tem relacionamento com um aluno
                .HasForeignKey<Aluno>(a => a.EnderecoId); //Estou me referindo a chaven que vai mapear o relacionamento entre as classes é o EnderecoId

            //Configurar o relacionamento entre a matricula com aluno e curso
            //vamos iniciar com matricula e aluno
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno) // dizendo que uma matricula tem relacionamento com um aluno
                .WithMany(a => a.Matriculas) //dizendo que um aluno pode ter varias matriculas 
                .HasForeignKey(m => m.AlunoId); //Definindo a chave estrangeira do relacionamento entre Matricula e aluno

            //vamos seguindo com matricula e curso
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)//dizendo que uma matricula tem relacionamento com um curso
                .WithMany(c => c.Matriculas) // dizendo que um curso pode ter varias matriculas
                .HasForeignKey(m => m.CursoId); //definindo a chave estrangeira do relacionamento entre matricula e curso
                
        }   
        public DbSet<AppWebCadastroAluno.Models.Disciplina> Disciplina { get; set; } = default!;
        public DbSet<AppWebCadastroAluno.Models.MatriculaDisciplina> MatriculaDisciplina { get; set; } = default!;
    }
}
