namespace PlayerMusical.Classes
{
    public class Musica
    {
        private string titulo;
        private string artista;
        private string genero;
        private int duracao;
        private string chave;

        public Musica(string t, string a, string g, int d)
        {
            titulo = t;
            artista = a;
            genero = g;
            duracao = d;
            chave = t + " - " + a;
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Artista
        {
            get { return artista; }
            set { artista = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public int Duracao
        {
            get { return duracao; }
            set { duracao = value; }
        }

        public string Chave
        {
            get { return chave; }
            set { chave = value; }
        }
        public string GetGenero()
        {
            return Genero;
        }

        public override string ToString()
        {
            return titulo + " - " + artista + " (" + genero + ") [" + duracao + "s]";
        }
    }
}
