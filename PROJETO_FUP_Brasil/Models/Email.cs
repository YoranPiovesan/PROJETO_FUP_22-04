﻿using Remake_FUP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignKey_Email
{
    public class Email
    {
       [Key]
        public int Id_Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string _Email { get; set; }
        public Aluno Aluno { get; set; }
        public Funcionario Funcionario { get; set; }
        public Chefia Chefia { get; set; }
    }
    
}
