using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEmprestimo
{
    internal class Emprestimo
    {
        public string IdEmprestimo { get; set; }
        public string IdAluno { get; set; }
        public string IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public double Multa { get; set; }
        public bool StatusEmprestimo { get; set; }

        public Emprestimo(string idEmprestimo, string idAluno, string idLivro, DateTime dataEmprestimo)
        {
            IdEmprestimo = idEmprestimo;
            IdAluno = idAluno;
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = null;
            Multa = 0;
            StatusEmprestimo = true;
        }
        public double CalcularMulta()
        {
            const double valorMultaDiaria = 2.0;

            if (DataDevolucao.HasValue && StatusEmprestimo)
            {
                TimeSpan atraso = DataDevolucao.Value - DataEmprestimo;
                int diasAtraso = (int)atraso.TotalDays;

                if (diasAtraso > 10)
                {
                    return valorMultaDiaria * (diasAtraso - 10);
                }
            }

            return 0.0;
        }
    }
}

