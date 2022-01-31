using System;

namespace DIO.Livros
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarLivros();
						break;
					case "2":
						InserirLivro();
						break;
					case "3":
						AtualizarLivro();
						break;
					case "4":
						ExcluirLivro();
						break;
					case "5":
						VisualizarLivro();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirLivro()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivro);
		}

        private static void VisualizarLivro()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			var Livro = repositorio.RetornaPorId(indiceLivro);

			Console.WriteLine(Livro);
		}

        private static void AtualizarLivro()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Qual o genero do livro? ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Qual o titulo do livro? ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Qual foi o ano de inicio do livro? ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro atualizaLivro = new Livro(id: indiceLivro,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceLivro, atualizaLivro);
		}
        private static void ListarLivros()
		{
			Console.WriteLine("Listar livros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Livro cadastrado.");
				return;
			}

			foreach (var Livro in lista)
			{
                var excluido = Livro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Livro.retornaId(), Livro.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirLivro()
		{
			Console.WriteLine("Inserir novo livro");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Qual o genero do livro? ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Qual o titulo do livro? ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Qual o ano de inicio do livro? ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro novaLivro = new Livro(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaLivro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Qual a leitura de hoje?!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar livros");
			Console.WriteLine("2- Inserir novo livro");
			Console.WriteLine("3- Atualizar livro");
			Console.WriteLine("4- Excluir livro");
			Console.WriteLine("5- Visualizar livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

