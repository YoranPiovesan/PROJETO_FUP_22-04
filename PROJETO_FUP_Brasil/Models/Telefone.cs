using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Remake_FUP.Models
{
    public class Telefone
    {
        [Key]
        public int Id_Telefone { get; set; }
        [Phone(ErrorMessage = "Telefone inválido")]
        public string _Telefone { get; set; }
        
    }
}
