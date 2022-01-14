using System;
using SERIES;
using System.Collections.Generic;

namespace SERIES
{
    class Program
    {
        static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {
        inicio:
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        DetalharSerie();
                        break;
                    case "5":
                        ExcluirSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        System.Console.WriteLine("Opção Incorreta! Digite outra opção: ");
                        goto inicio;

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }



            System.Console.WriteLine("Obrigado por utilizar o DIO Séries... Volte Sempre!");
            Console.ReadKey();
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("# EXCLUSÃO DE SÉRIES: #");
            System.Console.WriteLine();
            ListarSerie();
            System.Console.WriteLine();
            Console.WriteLine("Digite o id da Série que deseja excluir: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine($"Deseja realmente excluir a série o Id: {indiceSerie}? Y/N");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "Y")
            {
                repositorio.Exclui(indiceSerie);
                System.Console.WriteLine($"Id: {indiceSerie} excluído com Sucesso!");
            }
            else if (resposta == "N")
            {
                System.Console.WriteLine($"Id: {indiceSerie} Não foi Excluído!");
            }
            else
            {
                System.Console.WriteLine($"Opção Incorreta! Realize o procedimento novamente!");
            }

        }

        private static void DetalharSerie()
        {
            System.Console.WriteLine();
            ListarSerie();
            System.Console.WriteLine();
            Console.WriteLine("Digite o id da Série que deseja detalhar: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("# SERIE DETALHADA: #");
            var serie = repositorio.RetornaporId(indiceSerie);
            Console.WriteLine(serie);

        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("# ATUALIZAÇÃO DE SÉRIES #");
            System.Console.WriteLine();
            ListarSerie();
            System.Console.WriteLine();
            System.Console.Write("Digite o Id da Série que deseja Atualizar: ");
            int indiceSerie = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();

            System.Console.WriteLine("Série a ser atualizada: ");
            var serie = repositorio.RetornaporId(indiceSerie);
            Console.WriteLine(serie);
            System.Console.WriteLine();

        Atualizacao:
            if (serie.retornaExcluido() == false)
            {
                int opcaoUsuario = ObterOpcaoAtualizacao();

                switch (opcaoUsuario)
                {
                    case 1:

                        foreach (int i in Enum.GetValues(typeof(genero)))
                        {
                            System.Console.WriteLine($"{i} {Enum.GetName(typeof(genero), i)}");
                        }
                        System.Console.WriteLine("Digite o gênero entre as opções acima: ");
                        int entradaGenero = Convert.ToInt32(Console.ReadLine());
                        serie atualizaSerie1 = new serie(id: indiceSerie,
                                            genero: (genero)entradaGenero,
                                            titulo: serie.retornaTitulo(),
                                            descricao: serie.retornaDescricao(),
                                            ano: serie.retornaAno());
                        repositorio.Atualiza(indiceSerie, atualizaSerie1);
                        System.Console.WriteLine($"Gênero da série {serie.retornaTitulo()} alterado com Sucesso!");

                        break;

                    case 2:
                        System.Console.WriteLine("Digite o Título da série: ");
                        string entradaTitulo = Console.ReadLine();
                        serie atualizaSerie2 = new serie(id: indiceSerie,
                                            genero: (genero)serie.retornaGenero(),
                                            titulo: entradaTitulo,
                                            descricao: serie.retornaDescricao(),
                                            ano: serie.retornaAno());
                        repositorio.Atualiza(indiceSerie, atualizaSerie2);
                        System.Console.WriteLine($"Título da série de Id: {indiceSerie} alterado com Sucesso!");
                        break;

                    case 3:
                        System.Console.WriteLine("Digite o Ano da série: ");
                        int entradaAno = Convert.ToInt32(Console.ReadLine());
                        serie atualizaSerie3 = new serie(id: indiceSerie,
                                            genero: (genero)serie.retornaGenero(),
                                            titulo: serie.retornaTitulo(),
                                            descricao: serie.retornaDescricao(),
                                            ano: entradaAno);
                        repositorio.Atualiza(indiceSerie, atualizaSerie3);
                        System.Console.WriteLine($"Ano da série {serie.retornaTitulo()} alterado com Sucesso!");
                        break;
                    case 4:
                        System.Console.WriteLine("Digite a descrição da Série: ");
                        string entradaDescricao = Console.ReadLine();
                        serie atualizaSerie4 = new serie(id: indiceSerie,
                                          genero: (genero)serie.retornaGenero(),
                                          titulo: serie.retornaTitulo(),
                                          descricao: entradaDescricao,
                                          ano: serie.retornaAno());
                        repositorio.Atualiza(indiceSerie, atualizaSerie4);
                        System.Console.WriteLine($"Descrição da série {serie.retornaTitulo()} alterado com Sucesso!");
                        break;
                    case 5:
                        foreach (int i in Enum.GetValues(typeof(genero)))
                        {
                            System.Console.WriteLine($"{i} {Enum.GetName(typeof(genero), i)}");
                        }
                        System.Console.WriteLine("Digite o gênero entre as opções acima: ");
                        int entradaGenero5 = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Digite o Título da série: ");
                        string entradaTitulo5 = Console.ReadLine();
                        System.Console.WriteLine("Digite o Ano da série: ");
                        int entradaAno5 = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Digite a descrição da Série: ");
                        string entradaDescricao5 = Console.ReadLine();
                        serie atualizaSerie5 = new serie(id: indiceSerie,
                                                genero: (genero)entradaGenero5,
                                                titulo: entradaTitulo5,
                                                ano: entradaAno5,
                                                descricao: entradaDescricao5);
                        repositorio.Atualiza(indiceSerie, atualizaSerie5);
                        System.Console.WriteLine($"Itens da série de Id: {indiceSerie} alterados com Sucesso!");
                        break;
                    default:
                        System.Console.WriteLine("Opção Incorreta! Tente Novamente!");
                        break;
                }


            }
            else
            {
                System.Console.WriteLine($"A série {serie.retornaTitulo()} está excluída, deseja atualizar mesmo assim? Y/N");
                System.Console.WriteLine("Importante: Atualizando uma série excluída, ela deixará de ser excluída!");
                string resp = Console.ReadLine().ToUpper();
                if (resp == "Y")
                {
                    serie.AtualizarExclusao();
                    goto Atualizacao;
                }
                else if (resp == "N")
                {
                    System.Console.WriteLine($"Série {serie.retornaTitulo()} não foi alterada!");
                }
                else
                {
                    System.Console.WriteLine("Opção Inválida! Tente novamente!");
                }

            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("# INSERIR NOVA SÉRIE: #");

            foreach (int i in Enum.GetValues(typeof(genero)))
            {
                System.Console.WriteLine($"{i} {Enum.GetName(typeof(genero), i)}");
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Digite o Ano da série: ");
            int entradaAno = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            serie novaSerie = new serie(id: repositorio.ProximoId(),
                                        genero: (genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            System.Console.WriteLine();
            System.Console.WriteLine("Série Cadastrada com Sucesso!");

        }

        private static void ListarSerie()
        {
            System.Console.WriteLine("# LISTA DE SÉRIES CADASTRADAS: #");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Série cadastrada!");
                return;
            }

            foreach (var series in lista)
            {
                var excluido = (series.retornaExcluido() ? "- SÉRIE EXCLUÍDA PELO USUÁRIO!" : " ");
                System.Console.WriteLine("# ID {0}: {1} {2}", series.retornaId(), series.retornaTitulo(), excluido);
            }
            
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" # DIO SÉRIES A SEU DISPOR # ");
            Console.WriteLine("  Informe a opção desejada: ");
            Console.WriteLine("----------------------------");
            Console.WriteLine("    1. Listar Série         ");
            Console.WriteLine("    2. Inserir Nova Série   ");
            Console.WriteLine("    3. Atualizar Série      ");
            Console.WriteLine("    4. Detalhar Série       ");
            Console.WriteLine("    5. Excluir Série        ");
            Console.WriteLine("    C. Limpar a Tela        ");
            Console.WriteLine("    X. Sair                 ");
            Console.WriteLine("----------------------------");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
            
        }
        private static int ObterOpcaoAtualizacao()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o que deseja atualizar:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("        1. Gênero             ");
            Console.WriteLine("        2. Título             ");
            Console.WriteLine("        3. Ano                ");
            Console.WriteLine("        4. Descrição          ");
            Console.WriteLine("        5. Todas as opções    ");
            Console.WriteLine("------------------------------");

            int opcaoUsuario = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

