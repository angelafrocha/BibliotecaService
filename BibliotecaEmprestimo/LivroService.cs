using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEmprestimo
{
    internal class LivroService
    {
        public List<Livro> Livros { get; } = new List<Livro>();

        public LivroService()
        {
            // Adiciona os livros iniciais
            Livros.Add(new Livro("1", "O Senhor dos Anéis", "J.R.R. Tolkien", 1954, "Fantasia"));
            Livros.Add(new Livro("2", "Orgulho e Preconceito", "Jane Austen", 1813, "Romance"));
            Livros.Add(new Livro("4", "A Guerra dos Mundos", "H.G. Wells", 1898, "Ficção Científica"));
        }

        public List<Livro> GetLivros()
        {
            return Livros;
        }

        public Livro GetLivroPorId(string idLivro)
        {
            idLivro = idLivro.ToLower();
            return Livros.FirstOrDefault(l => l.IdLivro.ToLower() == idLivro);
        }

        public Livro GetLivroPorTitulo(string titulo)
        {
            titulo = titulo.ToLower();
            return Livros.FirstOrDefault(l => l.Titulo.ToLower() == titulo);
        }

        public void CadastrarLivro(Dictionary<string, string> dados)
        {
            // Valida os dados
            if (!dados.ContainsKey("id"))
            {
                throw new ArgumentException("O ID do livro é obrigatório.");
            }

            if (!dados.ContainsKey("titulo"))
            {
                throw new ArgumentException("O título do livro é obrigatório.");
            }

            // Cria o livro
            Livro livro = new Livro(dados["id"], dados["titulo"], dados["autor"], int.Parse(dados["anoPublicacao"]), dados["genero"]);

            // Adiciona o livro à lista
            Livros.Add(livro);
        }
    }
}

