using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJETO_FUP_Brasil.Migrations
{
    public partial class MigrationTestes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Financeiro_FinanceiroId_Financeiro",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Financeiro_FinanceiroId_Financeiro",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_FinanceiroId_Financeiro",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_FinanceiroId_Financeiro",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "FinanceiroId_Financeiro",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "FinanceiroId_Financeiro",
                table: "Aluno");

            migrationBuilder.AddColumn<string>(
                name: "Aluno",
                table: "Financeiro",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "alunoId_Matricula",
                table: "Financeiro",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financeiro_alunoId_Matricula",
                table: "Financeiro",
                column: "alunoId_Matricula");

            migrationBuilder.AddForeignKey(
                name: "FK_Financeiro_Aluno_alunoId_Matricula",
                table: "Financeiro",
                column: "alunoId_Matricula",
                principalTable: "Aluno",
                principalColumn: "Id_Matricula",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financeiro_Aluno_alunoId_Matricula",
                table: "Financeiro");

            migrationBuilder.DropIndex(
                name: "IX_Financeiro_alunoId_Matricula",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "Aluno",
                table: "Financeiro");

            migrationBuilder.DropColumn(
                name: "alunoId_Matricula",
                table: "Financeiro");

            migrationBuilder.AddColumn<int>(
                name: "FinanceiroId_Financeiro",
                table: "Funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinanceiroId_Financeiro",
                table: "Aluno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_FinanceiroId_Financeiro",
                table: "Funcionario",
                column: "FinanceiroId_Financeiro");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_FinanceiroId_Financeiro",
                table: "Aluno",
                column: "FinanceiroId_Financeiro");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Financeiro_FinanceiroId_Financeiro",
                table: "Aluno",
                column: "FinanceiroId_Financeiro",
                principalTable: "Financeiro",
                principalColumn: "Id_Financeiro",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Financeiro_FinanceiroId_Financeiro",
                table: "Funcionario",
                column: "FinanceiroId_Financeiro",
                principalTable: "Financeiro",
                principalColumn: "Id_Financeiro",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
