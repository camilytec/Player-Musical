using System;

namespace PlayerMusical.Classes
{
    public class NoArvoreGenero
    {
        private string genero;
        private ListaMusicas musicas;
        private NoArvoreGenero esquerda;
        private NoArvoreGenero direita;

        public NoArvoreGenero(string genero)
        {
            this.genero = genero;
            musicas = new ListaMusicas();
            esquerda = null;
            direita = null;
        }

        public string GetGenero()
        {
            return genero;
        }

        public ListaMusicas GetMusicas()
        {
            return musicas;
        }

        public NoArvoreGenero GetEsquerda()
        {
            return esquerda;
        }

        public NoArvoreGenero GetDireita()
        {
            return direita;
        }

        public void SetEsquerda(NoArvoreGenero no)
        {
            esquerda = no;
        }

        public void SetDireita(NoArvoreGenero no)
        {
            direita = no;
        }
    }

    public class ArvoreGenerosMusicais
    {
        private NoArvoreGenero raiz;

        public ArvoreGenerosMusicais()
        {
            raiz = null;
        }

        public void Inserir(Musica musica)
        {
            raiz = InserirRecursivo(raiz, musica);
        }

        private NoArvoreGenero InserirRecursivo(NoArvoreGenero no, Musica musica)
        {
            if (no == null)
            {
                NoArvoreGenero novo = new NoArvoreGenero(musica.GetGenero());
                novo.GetMusicas().Adicionar(musica);
                return novo;
            }

            int comparacao = musica.GetGenero().CompareTo(no.GetGenero());

            if (comparacao < 0)
                no.SetEsquerda(InserirRecursivo(no.GetEsquerda(), musica));
            else if (comparacao > 0)
                no.SetDireita(InserirRecursivo(no.GetDireita(), musica));
            else
                no.GetMusicas().Adicionar(musica);

            return no;
        }

        public ListaMusicas Buscar(string genero)
        {
            NoArvoreGenero no = BuscarRecursivo(raiz, genero);
            if (no == null) return null;
            return no.GetMusicas();
        }

        private NoArvoreGenero BuscarRecursivo(NoArvoreGenero no, string genero)
        {
            if (no == null) return null;

            int comparacao = genero.CompareTo(no.GetGenero());

            if (comparacao == 0)
                return no;

            if (comparacao < 0)
                return BuscarRecursivo(no.GetEsquerda(), genero);

            return BuscarRecursivo(no.GetDireita(), genero);
        }

        public void MostrarTodos()
        {
            MostrarRecursivo(raiz);
        }

        private void MostrarRecursivo(NoArvoreGenero no)
        {
            if (no == null) return;

            MostrarRecursivo(no.GetEsquerda());

            Console.WriteLine("Gênero: " + no.GetGenero());
            no.GetMusicas().Mostrar();

            MostrarRecursivo(no.GetDireita());
        }

        public void RemoverMusica(string genero, Musica musica)
        {
            NoArvoreGenero no = BuscarRecursivo(raiz, genero);
            if (no != null)
            {
                no.GetMusicas().Remover(musica);
            }
        }
    }
   
}
