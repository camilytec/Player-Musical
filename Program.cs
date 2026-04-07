using PlayerMusical.Classes;
using System;

namespace PlayerMusical.Classes
{
    class Program
    {
        static void Main()
        {
            PlayerMusical player = new PlayerMusical(100, 10);
            ArvoreGenerosMusicais arvoreGeneros = new ArvoreGenerosMusicais();
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n--- PLAYER MUSICAL ---");
                Console.WriteLine("1. Gerenciar Catálogo");
                Console.WriteLine("2. Criar Playlist");
                Console.WriteLine("3. Adicionar Música à Playlist");
                Console.WriteLine("4. Adicionar Música na Fila");
                Console.WriteLine("5. Tocar Próxima Música");
                Console.WriteLine("6. Mostrar Fila de Reprodução");
                Console.WriteLine("7. Mostrar Histórico");
                Console.WriteLine("8. Mostrar Playlists");
                Console.WriteLine("9. Mostrar músicas por Gênero");
                Console.WriteLine("10. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        GerenciarCatalogo(player, arvoreGeneros);
                        break;
                    case "2":
                        CriarPlaylist(player);
                        break;
                    case "3":
                        AdicionarMusicaNaPlaylist(player);
                        break;
                    case "4":
                        AdicionarMusicaFila(player);
                        break;
                    case "5":
                        player.TocarProxima();
                        break;
                    case "6":
                        player.MostrarFila();
                        break;
                    case "7":
                        player.MostrarHistorico();
                        break;
                    case "8":
                        MostrarPlaylists(player);
                        break;
                    case "9":
                        arvoreGeneros.MostrarTodos();
                        break;
                    case "10":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void GerenciarCatalogo(PlayerMusical player, ArvoreGenerosMusicais arvoreGeneros)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.WriteLine("\n--- GERENCIAR CATÁLOGO ---");
                Console.WriteLine("1. Listar músicas");
                Console.WriteLine("2. Adicionar música");
                Console.WriteLine("3. Remover música");
                Console.WriteLine("4. Buscar música");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (player.CatalogoPrincipal.Count == 0)
                            Console.WriteLine("O catálogo está vazio!");
                        else
                        {
                            Console.WriteLine("Músicas no catálogo:");
                            foreach (var kvp in player.CatalogoPrincipal)
                                Console.WriteLine($"{kvp.Key} | Gênero: {kvp.Value.Genero} | Duração: {kvp.Value.Duracao}s");
                        }
                        break;

                    case "2":
                        Console.Write("Título da música: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Artista: ");
                        string artista = Console.ReadLine();

                        Console.Write("Gênero: ");
                        string genero = Console.ReadLine();

                        Console.Write("Duração (em segundos): ");
                        int duracao;
                        while (!int.TryParse(Console.ReadLine(), out duracao))
                            Console.Write("Digite um valor válido para a duração: ");

                        Musica novaMusica = new Musica(titulo, artista, genero, duracao);
                        player.AdicionarMusicaAoCatalogo(novaMusica);

                        
                        arvoreGeneros.Inserir(novaMusica);

                        Console.WriteLine("Música adicionada ao catálogo!");
                        break;

                    case "3":
                        Console.Write("Digite a chave da música (Título - Artista) para remover: ");
                        string chaveRemover = Console.ReadLine();

                        Musica musicaARemover = player.BuscarMusica(chaveRemover);

                        if (musicaARemover != null)
                        {
                            
                            arvoreGeneros.RemoverMusica(musicaARemover.Genero, musicaARemover);

                            
                            player.CatalogoPrincipal.Remove(chaveRemover);

                            Console.WriteLine("Música removida do catálogo!");
                        }
                        else
                        {
                            Console.WriteLine("Música não encontrada no catálogo.");
                        }

                    case "4":
                        Console.Write("Digite a chave da música (Título - Artista) para buscar: ");
                        string chaveBuscar = Console.ReadLine();

                        player.CatalogoPrincipal.TryGetValue(chaveBuscar, out Musica musicaBuscada);
                        if (musicaBuscada != null)
                            Console.WriteLine($"{musicaBuscada.Chave} | Gênero: {musicaBuscada.Genero} | Duração: {musicaBuscada.Duracao}s");
                        else
                            Console.WriteLine("Música não encontrada no catálogo.");
                        break;

                    case "5":
                        voltar = true;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void CriarPlaylist(PlayerMusical player)
        {
            Console.Write("Nome da Playlist: ");
            string nome = Console.ReadLine();
            player.CriarPlaylist(nome);
            Console.WriteLine("Playlist criada com sucesso!");
        }

        static void AdicionarMusicaNaPlaylist(PlayerMusical player)
        {
            if (player.Playlists.Count == 0)
            {
                Console.WriteLine("Nenhuma playlist criada.");
                return;
            }

            Console.WriteLine("Playlists disponíveis:");
            for (int i = 0; i < player.Playlists.Count; i++)
                Console.WriteLine($"{i + 1}. {player.Playlists[i].Nome}");

            Console.Write("Escolha o número da playlist: ");
            if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 1 || numero > player.Playlists.Count)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Playlist playlist = player.Playlists[numero - 1];

            Console.WriteLine("Músicas disponíveis no catálogo:");
            foreach (string chave in player.CatalogoPrincipal.Keys)
                Console.WriteLine(chave);

            Console.Write("Digite a chave da música (Título - Artista) para adicionar: ");
            string chaveMusica = Console.ReadLine();

            player.CatalogoPrincipal.TryGetValue(chaveMusica, out Musica musica);
            if (musica != null)
            {
                playlist.AdicionarMusica(musica);
                Console.WriteLine("Música adicionada à playlist!");
            }
            else
            {
                Console.WriteLine("Música não encontrada no catálogo.");
            }
        }

        static void AdicionarMusicaFila(PlayerMusical player)
        {
            if (player.CatalogoPrincipal.Count == 0)
            {
                Console.WriteLine("O catálogo está vazio!");
                return;
            }

            Console.WriteLine("Músicas disponíveis no catálogo:");
            foreach (string chave in player.CatalogoPrincipal.Keys)
                Console.WriteLine(chave);

            Console.Write("Digite a chave da música (Título - Artista) para adicionar na fila: ");
            string chaveMusica = Console.ReadLine();

            player.CatalogoPrincipal.TryGetValue(chaveMusica, out Musica musica);
            if (musica != null)
            {
                player.AdicionarMusicaNaFila(musica);
                Console.WriteLine("Música adicionada à fila!");
            }
            else
            {
                Console.WriteLine("Música não encontrada no catálogo.");
            }
        }

        static void MostrarPlaylists(PlayerMusical player)
        {
            if (player.Playlists.Count == 0)
            {
                Console.WriteLine("Nenhuma playlist criada.");
                return;
            }

            Console.WriteLine("Playlists disponíveis:");
            for (int i = 0; i < player.Playlists.Count; i++)
                Console.WriteLine($"{i + 1}. {player.Playlists[i].Nome}");

            Console.Write("Digite o número da playlist para ver suas músicas: ");
            if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 1 || numero > player.Playlists.Count)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            player.Playlists[numero - 1].MostrarPlaylist();
        }
    }
}