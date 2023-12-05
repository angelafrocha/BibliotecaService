using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEmprestimo
{
    internal class Aluno
    {
        public string IdAluno { get; set; }
        public string Nome { get; set; }

        public Aluno(Dictionary<string, string> dadosAluno)
        {
            IdAluno = dadosAluno["idAluno"];
            Nome = dadosAluno["nome"];
        }
    }
}
