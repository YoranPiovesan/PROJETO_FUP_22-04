using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ForeignKey_Email;
using PROJETO_FUP_Brasil.Models;

namespace Remake_FUP.Models
{
    public class Aluno
    {
        [Key]
        public int Id_Matricula { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Tamanho do RG inválido")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CPF inválido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tamanho do CPF inválido")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Datanascimento { get; set; }
        [Required(ErrorMessage = "Campo obrigatório (Feminino/Masculino)")]
        public string Genero { get; set; }
       //[StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Curso { get; set; }
        public Cursos curso { get; set; }
        public List<Email> Email { get; set; }
        public List<Telefone> Telefone { get; set; }
    }
}
