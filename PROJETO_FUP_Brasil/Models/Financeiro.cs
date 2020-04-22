using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Remake_FUP.Models
{
    public class Financeiro
    {
        [Key]
        public int Id_Financeiro { get; set; }

        // [Required(ErrorMessage = "Campo obrigatório (Entrada/Saída)")]
        //// [RegularExpression(@"E (Entrada)/S(Saída)", ErrorMessage = "Resposta inválida")]
        // [StringLength(1, MinimumLength = 1, ErrorMessage = "Deve ser informado (E) para entrada ou (S) para saída")]
        public string Direcao_Financeira { get; set; }


        //[Required(ErrorMessage = "Campo obrigatório (Descrição da transação)")]
        //[RegularExpression(@"Descrição de transação.", ErrorMessage = "Resposta inválida")]
        //[StringLength(80, MinimumLength = 10, ErrorMessage = "Descreva a transação")]
        public string Descricao_Financeira { get; set; }


        //[Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression(@"Valor da transação", ErrorMessage = "Resposta inválida!")]
        //[StringLength(10, MinimumLength = 4, ErrorMessage = "Informe o valor de entrada ou saida!")]
        public double Valor { get; set; }

        public string Aluno { get; set; }
        public Aluno aluno { get; set; }

    }
}
