using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJETO_FUP_Brasil.Migrations
{
    public partial class PrimeiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chefia",
                columns: table => new
                {
                    Id_Chefia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(maxLength: 9, nullable: false),
                    Setor = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefia", x => x.Id_Chefia);
                });

            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    Id_Financeiro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direcao_Financeira = table.Column<string>(maxLength: 1, nullable: false),
                    Descricao_Financeira = table.Column<string>(maxLength: 80, nullable: false),
                    Valor = table.Column<double>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.Id_Financeiro);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id_Funcionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Cargo = table.Column<string>(maxLength: 60, nullable: false),
                    Genero = table.Column<string>(maxLength: 60, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(maxLength: 9, nullable: false),
                    ChefiaId_Chefia = table.Column<int>(nullable: true),
                    FinanceiroId_Financeiro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id_Funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Chefia_ChefiaId_Chefia",
                        column: x => x.ChefiaId_Chefia,
                        principalTable: "Chefia",
                        principalColumn: "Id_Chefia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionario_Financeiro_FinanceiroId_Financeiro",
                        column: x => x.FinanceiroId_Financeiro,
                        principalTable: "Financeiro",
                        principalColumn: "Id_Financeiro",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Genero = table.Column<string>(nullable: false),
                    Curso = table.Column<string>(maxLength: 10, nullable: false),
                    FinanceiroId_Financeiro = table.Column<int>(nullable: true),
                    FuncionarioId_Funcionario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id_Matricula);
                    table.ForeignKey(
                        name: "FK_Aluno_Financeiro_FinanceiroId_Financeiro",
                        column: x => x.FinanceiroId_Financeiro,
                        principalTable: "Financeiro",
                        principalColumn: "Id_Financeiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Funcionario_FuncionarioId_Funcionario",
                        column: x => x.FuncionarioId_Funcionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id_Funcionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id_Email = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Email = table.Column<string>(nullable: false),
                    AlunoId_Matricula = table.Column<int>(nullable: true),
                    FuncionarioId_Funcionario = table.Column<int>(nullable: true),
                    ChefiaId_Chefia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id_Email);
                    table.ForeignKey(
                        name: "FK_Email_Aluno_AlunoId_Matricula",
                        column: x => x.AlunoId_Matricula,
                        principalTable: "Aluno",
                        principalColumn: "Id_Matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Chefia_ChefiaId_Chefia",
                        column: x => x.ChefiaId_Chefia,
                        principalTable: "Chefia",
                        principalColumn: "Id_Chefia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_Funcionario_FuncionarioId_Funcionario",
                        column: x => x.FuncionarioId_Funcionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id_Funcionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id_Telefone = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Telefone = table.Column<string>(nullable: true),
                    AlunoId_Matricula = table.Column<int>(nullable: true),
                    ChefiaId_Chefia = table.Column<int>(nullable: true),
                    FuncionarioId_Funcionario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id_Telefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Aluno_AlunoId_Matricula",
                        column: x => x.AlunoId_Matricula,
                        principalTable: "Aluno",
                        principalColumn: "Id_Matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefone_Chefia_ChefiaId_Chefia",
                        column: x => x.ChefiaId_Chefia,
                        principalTable: "Chefia",
                        principalColumn: "Id_Chefia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefone_Funcionario_FuncionarioId_Funcionario",
                        column: x => x.FuncionarioId_Funcionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id_Funcionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_FinanceiroId_Financeiro",
                table: "Aluno",
                column: "FinanceiroId_Financeiro");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_FuncionarioId_Funcionario",
                table: "Aluno",
                column: "FuncionarioId_Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Email_AlunoId_Matricula",
                table: "Email",
                column: "AlunoId_Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Email_ChefiaId_Chefia",
                table: "Email",
                column: "ChefiaId_Chefia");

            migrationBuilder.CreateIndex(
                name: "IX_Email_FuncionarioId_Funcionario",
                table: "Email",
                column: "FuncionarioId_Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_ChefiaId_Chefia",
                table: "Funcionario",
                column: "ChefiaId_Chefia");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_FinanceiroId_Financeiro",
                table: "Funcionario",
                column: "FinanceiroId_Financeiro");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_AlunoId_Matricula",
                table: "Telefone",
                column: "AlunoId_Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_ChefiaId_Chefia",
                table: "Telefone",
                column: "ChefiaId_Chefia");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_FuncionarioId_Funcionario",
                table: "Telefone",
                column: "FuncionarioId_Funcionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Chefia");

            migrationBuilder.DropTable(
                name: "Financeiro");
        }
    }
}
