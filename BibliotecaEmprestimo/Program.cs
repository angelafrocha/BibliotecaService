using BibliotecaEmprestimo;
using System;

class Program
{
    static void Main()
    {
        LivroService livroService = new LivroService();
        EmprestimoService emprestimoService = new EmprestimoService(livroService);

        

        while (true)
        {

            Console.WriteLine("Bem-vindo à Biblioteca!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Emprestar Livro");
            Console.WriteLine("3 - Devolver Livro");
            Console.WriteLine("4 - Consultar Livro");
            Console.WriteLine("5 - Ver Estatísticas");
            Console.WriteLine("0 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarLivro(livroService);
                    break;
                case "2":
                    EmprestarLivro(emprestimoService);
                    break;
                case "3":
                    DevolverLivro(emprestimoService);
                    break;
                case "4":
                    ConsultarLivro(livroService);
                    break;
                case "5":
                    VerEstatisticas(emprestimoService);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void CadastrarLivro(LivroService livroService)
    {
        try
        {
            Console.WriteLine("Informe os dados do livro:");
            Console.Write("ID: ");
            string idLivro = Console.ReadLine();

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Ano de Publicação: ");
            int anoPublicacao = int.Parse(Console.ReadLine());

            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            Dictionary<string, string> dadosLivro = new Dictionary<string, string>
            {
                {"id", idLivro},
                {"titulo", titulo},
                {"autor", autor},
                {"anoPublicacao", anoPublicacao.ToString()},
                {"genero", genero}
            };

            livroService.CadastrarLivro(dadosLivro);
            Console.WriteLine("Livro cadastrado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar o livro: {ex.Message}");
        }
    }

    private static void EmprestarLivro(EmprestimoService emprestimoService)
    {
        try
        {
            Console.WriteLine("Informe os dados para realizar o empréstimo:");
            Console.Write("ID do Aluno: ");
            string idAluno = Console.ReadLine();

            Console.Write("ID do Livro: ");
            string idLivro = Console.ReadLine();

            DateTime dataEmprestimo = DateTime.Now;

            // Chama o método do serviço de empréstimo para realizar o empréstimo
            emprestimoService.EmprestarLivro(idAluno, idLivro, dataEmprestimo);
            Console.WriteLine("Empréstimo realizado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao realizar o empréstimo: {ex.Message}");
        }
    }

    private static void DevolverLivro(EmprestimoService emprestimoService)
    {
        try
        {
            Console.WriteLine("Informe o ID do Livro para realizar a devolução:");
            Console.Write("ID do Livro: ");
            string idLivro = Console.ReadLine();

            DateTime dataDevolucao = DateTime.Now;

            // Chama o método do serviço de empréstimo para realizar a devolução
            emprestimoService.DevolverLivro(idLivro, dataDevolucao);
            Console.WriteLine("Devolução realizada com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao realizar a devolução: {ex.Message}");
        }
    }


    private static void ConsultarLivro(LivroService livroService)
    {
        Console.Clear();
        Console.WriteLine("Consulta de Livro");
        Console.Write("Informe o ID ou o Título do Livro: ");
        string termo = Console.ReadLine().ToLower();

        Livro livro = livroService.GetLivroPorId(termo) ?? livroService.GetLivroPorTitulo(termo);

        if (livro != null)
        {
            Console.WriteLine($"\nLivro encontrado:\n{livro}");
        }
        else
        {
            Console.WriteLine("\nLivro não encontrado.");
        }
    }

    private static void VerEstatisticas(EmprestimoService emprestimoService)
    {
        Console.Clear();
        Console.WriteLine("Estatísticas");
        emprestimoService.GerarEstatisticas();
    }
}
