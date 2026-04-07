using System;
using System.IO;

namespace PlayerMusical.Classes
{
    public class Playlist
    {
        private string nome;
        private ListaMusicas musicas;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public ListaMusicas Musicas
        {
            get { return musicas; }
            set { musicas = value; }
        }

        public Playlist(string nome)
        {
            Nome = nome;
            Musicas = new ListaMusicas();
        }

        public void AdicionarMusica(Musica musica)
        {
            Musicas.Adicionar(musica);
        }

        public void MostrarPlaylist()
        {
            Console.WriteLine("--- Playlist: " + Nome + " ---");
            Musicas.Mostrar();

            Console.WriteLine("Deseja ordenar as músicas?");
            Console.WriteLine("1. Por Título");
            Console.WriteLine("2. Por Duração");
            Console.WriteLine("3. Sem Ordenação");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Musicas.MostrarOrdenadoPorTitulo();
                    break;

                case "2":
                    Musicas.MostrarOrdenadoPorDuracao();
                    break;

                default:
                    break;
            }
        }
    }
}
