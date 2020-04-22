using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_FUP_Brasil.Models
{
    public class Cursos
    {
        [Key]
        public int Id_Curso { get; set; }
        public string NomeCurso { get; set; }
        public int ValorCurso { get; set; }
        public string  ProfessorCurso { get; set; }
    }
}
