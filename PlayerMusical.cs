using System;
using System.Collections.Generic;
using System.IO;

namespace PlayerMusical.Classes
{
    public class PlayerMusical
    {
        private Dictionary<string, Musica> catalogoPrincipal;
        private List<Playlist> playlists;
        private FilaReproducao filaReproducao;
        private HistoricoReproducao historico;
        private string caminhoLog = "log.txt";
        private string caminhoCSV = "musicas.csv";

        public PlayerMusical(int capacidadeFila, int capacidadeHistorico)
        {
            catalogoPrincipal = new Dictionary<string, Musica>();
            playlists = new List<Playlist>();
            filaReproducao = new FilaReproducao(capacidadeFila);
            historico = new HistoricoReproducao(capacidadeHistorico);
            CarregarCatalogoDoCSV();
        }

        public Dictionary<string, Musica> CatalogoPrincipal
        {
            get { return catalogoPrincipal; }
            set { catalogoPrincipal = value; }
        }

        public List<Playlist> Playlists
        {
            get { return playlists; }
            set { playlists = value; }
        }

        public FilaReproducao FilaReproducao
        {
            get { return filaReproducao; }
            set { filaReproducao = value; }
        }

        public HistoricoReproducao Historico
        {
            get { return historico; }
            set { historico = value; }
        }

        private void CarregarCatalogoDoCSV()
        {
            if (!File.Exists(caminhoCSV))
                return;

            string[] linhas = File.ReadAllLines(caminhoCSV, System.Text.Encoding.UTF8);

            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha))
                    continue;

                linha = linha.Trim('"');

                string[] dados = linha.Split(';');
                if (dados.Length >= 4)
                {
                    string titulo = dados[0];
                    string artista = dados[1];
                    string genero = dados[2];

                    if (int.TryParse(dados[3], out int duracao))
                    {
                        Musica musica = new Musica(titulo, artista, genero, duracao);
                        AdicionarMusicaAoCatalogo(musica, false);
                    }
                }
            }
        }

        public void AdicionarMusicaAoCatalogo(Musica musica)
        {
            AdicionarMusicaAoCatalogo(musica, true);
        }

        public void AdicionarMusicaAoCatalogo(Musica musica, bool atualizarCSV)
        {
            if (musica == null)
                return;

            string chave = musica.Chave;

            if (!catalogoPrincipal.ContainsKey(chave))
            {
                catalogoPrincipal[chave] = musica;
                RegistrarLog("Música adicionada ao catálogo: " + chave);

                if (atualizarCSV)
                    AtualizarCSV(musica);
            }
        }

        private void AtualizarCSV(Musica musica)
        {
            using (StreamWriter sw = new StreamWriter(caminhoCSV, true))
            {
                sw.WriteLine(musica.Titulo + ";" + musica.Artista + ";" + musica.Genero + ";" + musica.Duracao);
            }
        }

        public Musica BuscarMusica(string chave)
        {
            if (string.IsNullOrEmpty(chave))
                return null;

            if (catalogoPrincipal.ContainsKey(chave))
                return catalogoPrincipal[chave];

            return null;
        }

        public void CriarPlaylist(string nome)
        {
            Playlist playlist = new Playlist(nome);
            playlists.Add(playlist);
            RegistrarLog("Playlist criada: " + nome);
        }

        public Playlist BuscarPlaylist(string nome)
        {
            foreach (Playlist p in playlists)
            {
                if (p.Nome == nome)
                    return p;
            }

            return null;
        }

        public void AdicionarMusicaNaFila(Musica musica)
        {
            if (musica == null)
                return;

            bool adicionou = filaReproducao.Enfileirar(musica);

            if (adicionou)
                RegistrarLog("Música adicionada à fila: " + musica.Chave);
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
            {
                Console.WriteLine(chave);
            }

            Console.Write("Digite a chave da música (Título - Artista) para adicionar na fila: ");
            string entrada = Console.ReadLine();

            Musica musica = null;

            foreach (var kvp in player.CatalogoPrincipal)
            {
                if (kvp.Key.Equals(entrada, StringComparison.OrdinalIgnoreCase))
                {
                    musica = kvp.Value;
                    break;
                }
            }

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

        public void TocarProxima()
        {
            Musica musica = filaReproducao.Desenfileirar();

            if (musica != null)
            {
                historico.Empilhar(musica);
                Console.WriteLine("Tocando: " + musica.ToString());
                RegistrarLog("Tocando música: " + musica.Chave);
            }
            else
            {
                Console.WriteLine("Fila vazia.");
            }
        }

        public void MostrarHistorico()
        {
            historico.Mostrar();
        }

        public void MostrarFila()
        {
            filaReproducao.Mostrar();
        }

        private void RegistrarLog(string acao)
        {
            using (StreamWriter sw = new StreamWriter(caminhoLog, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ": " + acao);
            }
        }
    }
}
