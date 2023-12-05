using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaEmprestimo
{
    internal class EmprestimoService
    {
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();
        private LivroService _livroService;

        public EmprestimoService(LivroService livroService)
        {
            _livroService = livroService;
        }

        public void EmprestarLivro(string idAluno, string idLivro, DateTime dataEmprestimo)
        {
            try
            {
                Livro livro = _livroService.GetLivroPorId(idLivro);

                if (livro != null && livro.StatusLivro)
                {
                    
                    livro.StatusLivro = false; 
                    Emprestimo emprestimo = new Emprestimo(
                        Guid.NewGuid().ToString(), 
                        idAluno,
                        idLivro,
                        dataEmprestimo
                    );

                    _emprestimos.Add(emprestimo); 
                    Console.WriteLine("Empréstimo realizado com sucesso.");
                }
                else
                {
                    
                    throw new InvalidOperationException("Livro indisponível para empréstimo.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar o empréstimo: {ex.Message}");
            }
        }

        public void DevolverLivro(string idLivro, DateTime dataDevolucao)
        {
            try
            {
                Emprestimo emprestimo = _emprestimos.FirstOrDefault(e => e.IdLivro == idLivro && e.StatusEmprestimo);

                if (emprestimo != null)
                {
                    // Livro encontrado para devolução
                    emprestimo.StatusEmprestimo = false; // Muda o status do empréstimo
                    emprestimo.DataDevolucao = dataDevolucao; // Define a data de devolução

                    Livro livro = _livroService.GetLivroPorId(emprestimo.IdLivro);

                    if (livro != null)
                    {
                        livro.StatusLivro = true; // Muda o status do livro para disponível
                    }

                    Console.WriteLine("Devolução realizada com sucesso.");
                }
                else
                {
                    // Empréstimo não encontrado ou já devolvido
                    throw new InvalidOperationException("Empréstimo não encontrado ou já devolvido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar a devolução: {ex.Message}");
            }
        }




        public void GerarEstatisticas()
        {
            int totalLivros = _livroService.Livros.Count;
            int livrosDisponiveis = _livroService.Livros.Count(l => l.StatusLivro);
            int livrosEmprestados = _livroService.Livros.Count(l => !l.StatusLivro);
            int totalEmprestimos = _emprestimos.Count;

            Console.WriteLine($"Total de Livros: {totalLivros}");
            Console.WriteLine($"Livros Disponíveis: {livrosDisponiveis}");
            Console.WriteLine($"Livros Emprestados: {livrosEmprestados}");
            Console.WriteLine($"Total de Empréstimos: {totalEmprestimos}");
        }
    }
}
