﻿// <auto-generated />
using AppWebCadastroAluno.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppWebCadastroAluno.Migrations
{
    [DbContext(typeof(INFNETContexto))]
    [Migration("20240319000443_outro")]
    partial class outro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AppWebCadastroAluno.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Horas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Matricula", b =>
                {
                    b.Property<int>("MatriculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnoIngresso")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatriculaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.MatriculaDisciplina", b =>
                {
                    b.Property<int>("MatriculaDsciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatriculaDsciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("MatriculaId");

                    b.ToTable("MatriculaDisciplina");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Aluno", b =>
                {
                    b.HasOne("AppWebCadastroAluno.Models.Endereco", "Endereco")
                        .WithOne("Aluno")
                        .HasForeignKey("AppWebCadastroAluno.Models.Aluno", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Matricula", b =>
                {
                    b.HasOne("AppWebCadastroAluno.Models.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppWebCadastroAluno.Models.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.MatriculaDisciplina", b =>
                {
                    b.HasOne("AppWebCadastroAluno.Models.Disciplina", "Disciplina")
                        .WithMany("MatriculasDisciplina")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppWebCadastroAluno.Models.Matricula", "Matricula")
                        .WithMany("MatriculasDisciplina")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Curso", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Disciplina", b =>
                {
                    b.Navigation("MatriculasDisciplina");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Endereco", b =>
                {
                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("AppWebCadastroAluno.Models.Matricula", b =>
                {
                    b.Navigation("MatriculasDisciplina");
                });
#pragma warning restore 612, 618
        }
    }
}