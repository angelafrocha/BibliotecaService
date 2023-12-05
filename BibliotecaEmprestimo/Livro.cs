using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEmprestimo
{
    internal class Livro
    {
        public string IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Genero { get; set; }
        public bool StatusLivro { get; set; }

        public Livro(string idLivro, string titulo, string autor, int anoPublicacao, string genero)
        {
            IdLivro = idLivro;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Genero = genero;
            StatusLivro = true;
        }

        public Livro(Dictionary<string, string> dadosLivro)
        {
            IdLivro = dadosLivro["id"];
            Titulo = dadosLivro["titulo"];
            Autor = dadosLivro["autor"];
            AnoPublicacao = int.Parse(dadosLivro["anoPublicacao"]);
            Genero = dadosLivro["genero"];
            StatusLivro = true;
        }
        public override string ToString()
        {
            return $"ID: {IdLivro}, \nTítulo: {Titulo}, \nAutor: {Autor}, \nAno de Publicação: {AnoPublicacao}, \nGênero: {Genero}, \nStatus: {(StatusLivro ? "Disponível" : "Indisponível")}";
        }
    }
}
