using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ForeignKey_Email;

namespace Remake_FUP.Models
{
    public class Funcionario
    {
        [Key]
        public int Id_Funcionario { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        public string Nome { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cargo { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Gênero inválido")]
        public string Genero { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tamanho do CPF inválido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CPF inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Tamanho do RG inválido")]
        public string Rg { get; set; }
        public ICollection<Email> Email { get; set; }
        public ICollection<Telefone> Telefone { get; set; }
        public Chefia Chefia { get; set; }
        public string NomeChefe { get; set; }
        public List<Aluno> Aluno { get; set; }
    }
}
