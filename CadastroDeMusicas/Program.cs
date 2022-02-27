using CadastroDeMusicas.Classes;
using CadastroDeMusicas.Enums;
using System;

namespace CadastroDeMusicas
{
    class Program
    {
        static MusicaRepositorio _repositorio = new MusicaRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while (opcaoUsuario.ToUpper() != "X") //ToUpper = Tudo maiuscula - ToLower = Tudo minuscula
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarMusica();
                        break;
                    case "2":
                        InserirMusica();
                        break;
                    case "3":
                        AtualizarMusica();
                        break;
                    case "4":
                        ExcluirMusica();
                        break;
                    case "5":
                        VisualizarMusica();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoDoUsuario();
            }

            ExibeTextoNaTela("Obrigado por utilizar nossos serviços.");

            Console.ReadLine();
        }

        private static void ListarMusica()
        {
            ExibeTextoNaTela("Listar musica");

            var musicas = _repositorio.Lista();

            if (musicas.Count == 0)
            {
                ExibeTextoNaTela("Nenhuma musica cadastrada.");
                return;
            }

            foreach (var musica in musicas)
            {
                var excluido = musica.RetornaExcluido();
                var stringExcluido = excluido ? "Excluído" : "";
                ExibeTextoNaTela($"#ID: {musica.RetornaId()} - {musica.RetornaTitulo()} - {stringExcluido}");
            }
        }

        private static void InserirMusica()
        {
            ExibeTextoNaTela("Inserir nova musica");

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                ExibeTextoNaTela($"{(int)i} - {System.Enum.GetName(typeof(Genero), i)}");
            }

            ExibeTextoNaTela("Digite o gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            ExibeTextoNaTela("Digite o título da musica: ");
            string titulo = Console.ReadLine();

            ExibeTextoNaTela("Digite o ano de início da musica: ");
            int ano = int.Parse(Console.ReadLine());

            ExibeTextoNaTela("Digite a descrição da musica: ");
            string descricao = Console.ReadLine();

            var novaMusica = new Musica(_repositorio.ProximoId(),
                                      (Genero)genero,
                                      titulo,
                                      descricao,
                                      ano);

            _repositorio.Insere(novaMusica);
        }

        private static void AtualizarMusica()
        {
            ExibeTextoNaTela("Digite o id da musica: ");
            var id = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                ExibeTextoNaTela($"{(int)i} - {Enum.GetName(typeof(Genero), i)}");
            }

            ExibeTextoNaTela("Digite o gênero entre as opções acima: ");
            var genero = int.Parse(Console.ReadLine());

            ExibeTextoNaTela("Digite o título da musica: ");
            var titulo = Console.ReadLine();

            ExibeTextoNaTela("Digite o ano de início da musica: ");
            var ano = int.Parse(Console.ReadLine());

            ExibeTextoNaTela("Digite a descrição da musica: ");
            var descricao = Console.ReadLine();

            var novaMusica = new Musica(_repositorio.ProximoId(),
                                      (Genero)genero,
                                      titulo,
                                      descricao,
                                      ano);

            _repositorio.Atualiza(id, novaMusica);
        }

        private static void ExcluirMusica()
        {
            ExibeTextoNaTela("Digite o id da musica: ");
            int id = int.Parse(Console.ReadLine());

            _repositorio.Exclui(id);
        }

        private static void VisualizarMusica()
        {
            ExibeTextoNaTela("Digite o id da musica: ");
            int id = int.Parse(Console.ReadLine());

            var musica = _repositorio.RetornarPorId(id);

            Console.WriteLine(musica);
        }

        private static string ObterOpcaoDoUsuario()
        {
            ExibeTextoNaTela("");
            ExibeTextoNaTela("Playlist Evelin Musica a seu dispor!");
            ExibeTextoNaTela("Informe a opção desejada:");
            ExibeTextoNaTela("");
            ExibeTextoNaTela("1 - Listar musica");
            ExibeTextoNaTela("2 - Inserir nova musica");
            ExibeTextoNaTela("3 - Atualizar musica");
            ExibeTextoNaTela("4 - Excluir musica");
            ExibeTextoNaTela("5 - Visualizar musica");
            ExibeTextoNaTela("C - Limpar tela");
            ExibeTextoNaTela("X - Sair");
            ExibeTextoNaTela("");

            string opcaoUsuario = Console.ReadLine().ToUpper();

            ExibeTextoNaTela("");

            return opcaoUsuario;
        }

        private static void ExibeTextoNaTela(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}
