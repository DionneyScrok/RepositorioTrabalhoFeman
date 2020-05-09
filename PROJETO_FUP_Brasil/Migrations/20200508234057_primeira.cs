using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJETO_FUP_Brasil.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id_Matricula = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Rg = table.Column<string>(maxLength: 9, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Datanascimento = table.Column<DateTime>(nullable: false),
                    Genero = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id_Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id_Curso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCurso = table.Column<string>(maxLength: 60, nullable: false),
                    ValorCurso = table.Column<double>(nullable: false),
                    ProfessorCurso = table.Column<string>(maxLength: 60, nullable: false),
                    AlunoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id_Curso);
                    table.ForeignKey(
                        name: "FK_Cursos_Aluno_AlunoID",
                        column: x => x.AlunoID,
                        principalTable: "Aluno",
                        principalColumn: "Id_Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id_Email = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Email = table.Column<string>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id_Email);
                    table.ForeignKey(
                        name: "FK_Email_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id_Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id_Telefone = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Telefone = table.Column<string>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id_Telefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id_Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_AlunoID",
                table: "Cursos",
                column: "AlunoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Email_AlunoId",
                table: "Email",
                column: "AlunoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_AlunoId",
                table: "Telefone",
                column: "AlunoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
