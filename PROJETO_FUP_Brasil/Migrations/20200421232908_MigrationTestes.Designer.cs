﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJETO_FUP_Brasil.Data;

namespace PROJETO_FUP_Brasil.Migrations
{
    [DbContext(typeof(PROJETO_FUP_BrasilContext))]
    [Migration("20200421232908_MigrationTestes")]
    partial class MigrationTestes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ForeignKey_Email.Email", b =>
                {
                    b.Property<int>("Id_Email")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId_Matricula")
                        .HasColumnType("int");

                    b.Property<int?>("ChefiaId_Chefia")
                        .HasColumnType("int");

                    b.Property<int?>("FuncionarioId_Funcionario")
                        .HasColumnType("int");

                    b.Property<string>("_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Email");

                    b.HasIndex("AlunoId_Matricula");

                    b.HasIndex("ChefiaId_Chefia");

                    b.HasIndex("FuncionarioId_Funcionario");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("PROJETO_FUP_Brasil.Models.Cursos", b =>
                {
                    b.Property<int>("Id_Curso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCurso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfessorCurso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ValorCurso")
                        .HasColumnType("int");

                    b.HasKey("Id_Curso");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Remake_FUP.Models.Aluno", b =>
                {
                    b.Property<int>("Id_Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datanascimento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuncionarioId_Funcionario")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<int?>("cursoId_Curso")
                        .HasColumnType("int");

                    b.HasKey("Id_Matricula");

                    b.HasIndex("FuncionarioId_Funcionario");

                    b.HasIndex("cursoId_Curso");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Remake_FUP.Models.Chefia", b =>
                {
                    b.Property<int>("Id_Chefia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id_Chefia");

                    b.ToTable("Chefia");
                });

            modelBuilder.Entity("Remake_FUP.Models.Financeiro", b =>
                {
                    b.Property<int>("Id_Financeiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aluno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao_Financeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Direcao_Financeira")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<double>("Valor")
                        .HasColumnType("float")
                        .HasMaxLength(10);

                    b.Property<int?>("alunoId_Matricula")
                        .HasColumnType("int");

                    b.HasKey("Id_Financeiro");

                    b.HasIndex("alunoId_Matricula");

                    b.ToTable("Financeiro");
                });

            modelBuilder.Entity("Remake_FUP.Models.Funcionario", b =>
                {
                    b.Property<int>("Id_Funcionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int?>("ChefiaId_Chefia")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Id_Funcionario");

                    b.HasIndex("ChefiaId_Chefia");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Remake_FUP.Models.Telefone", b =>
                {
                    b.Property<int>("Id_Telefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoId_Matricula")
                        .HasColumnType("int");

                    b.Property<int?>("ChefiaId_Chefia")
                        .HasColumnType("int");

                    b.Property<int?>("FuncionarioId_Funcionario")
                        .HasColumnType("int");

                    b.Property<string>("_Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Telefone");

                    b.HasIndex("AlunoId_Matricula");

                    b.HasIndex("ChefiaId_Chefia");

                    b.HasIndex("FuncionarioId_Funcionario");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("ForeignKey_Email.Email", b =>
                {
                    b.HasOne("Remake_FUP.Models.Aluno", "Aluno")
                        .WithMany("Email")
                        .HasForeignKey("AlunoId_Matricula");

                    b.HasOne("Remake_FUP.Models.Chefia", "Chefia")
                        .WithMany("Email")
                        .HasForeignKey("ChefiaId_Chefia");

                    b.HasOne("Remake_FUP.Models.Funcionario", "Funcionario")
                        .WithMany("Email")
                        .HasForeignKey("FuncionarioId_Funcionario");
                });

            modelBuilder.Entity("Remake_FUP.Models.Aluno", b =>
                {
                    b.HasOne("Remake_FUP.Models.Funcionario", null)
                        .WithMany("Aluno")
                        .HasForeignKey("FuncionarioId_Funcionario");

                    b.HasOne("PROJETO_FUP_Brasil.Models.Cursos", "curso")
                        .WithMany()
                        .HasForeignKey("cursoId_Curso");
                });

            modelBuilder.Entity("Remake_FUP.Models.Financeiro", b =>
                {
                    b.HasOne("Remake_FUP.Models.Aluno", "aluno")
                        .WithMany()
                        .HasForeignKey("alunoId_Matricula");
                });

            modelBuilder.Entity("Remake_FUP.Models.Funcionario", b =>
                {
                    b.HasOne("Remake_FUP.Models.Chefia", "Chefia")
                        .WithMany("Funcionario")
                        .HasForeignKey("ChefiaId_Chefia");
                });

            modelBuilder.Entity("Remake_FUP.Models.Telefone", b =>
                {
                    b.HasOne("Remake_FUP.Models.Aluno", null)
                        .WithMany("Telefone")
                        .HasForeignKey("AlunoId_Matricula");

                    b.HasOne("Remake_FUP.Models.Chefia", null)
                        .WithMany("Telefone")
                        .HasForeignKey("ChefiaId_Chefia");

                    b.HasOne("Remake_FUP.Models.Funcionario", null)
                        .WithMany("Telefone")
                        .HasForeignKey("FuncionarioId_Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
