using ForeignKey_Email;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Remake_FUP.Models
{
    public class Chefia
    {
        [Key]
        public int Id_Chefia { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        public string Nome { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tamanho do CPF inválido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CPF inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Tamanho do RG inválido")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "RG inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rg { get; set; }
        [StringLength(25, MinimumLength = 8, ErrorMessage = "Informe o setor!")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Setor { get; set; }
        public List<Email> Email { get; set; }
        public List<Telefone> Telefone { get; set; }
        public List<Funcionario> Funcionario { get; set; }
    }
}
