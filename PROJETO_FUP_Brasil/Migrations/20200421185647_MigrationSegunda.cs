using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJETO_FUP_Brasil.Migrations
{
    public partial class MigrationSegunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Curso",
                table: "Aluno",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "cursoId_Curso",
                table: "Aluno",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_cursoId_Curso",
                table: "Aluno",
                column: "cursoId_Curso");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Cursos_cursoId_Curso",
                table: "Aluno",
                column: "cursoId_Curso",
                principalTable: "Cursos",
                principalColumn: "Id_Curso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Cursos_cursoId_Curso",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_cursoId_Curso",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "cursoId_Curso",
                table: "Aluno");

            migrationBuilder.AlterColumn<string>(
                name: "Curso",
                table: "Aluno",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
