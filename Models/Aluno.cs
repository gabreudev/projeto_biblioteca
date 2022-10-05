using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Aluno
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public string Turma { get; set; }
        public string Livro { get; set; }
    }
}