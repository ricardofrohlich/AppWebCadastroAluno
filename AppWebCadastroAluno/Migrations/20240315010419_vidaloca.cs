using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebCadastroAluno.Migrations
{
    /// <inheritdoc />
    public partial class vidaloca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "Alunos");

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    Professor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaId);
                });

            migrationBuilder.CreateTable(
                name: "MatriculaDisciplina",
                columns: table => new
                {
                    MatriculaDsciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MatriculaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatriculaDisciplina", x => x.MatriculaDsciplinaId);
                    table.ForeignKey(
                        name: "FK_MatriculaDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatriculaDisciplina_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "MatriculaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplina_DisciplinaId",
                table: "MatriculaDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_MatriculaDisciplina_MatriculaId",
                table: "MatriculaDisciplina",
                column: "MatriculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatriculaDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.AddColumn<string>(
                name: "Matricula",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
