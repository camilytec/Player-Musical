using System;

namespace PlayerMusical.Classes
{
    public class FilaReproducao
    {
        private Musica[] elementos;
        private int inicio;
        private int fim;
        private int capacidade;
        private int tamanho;

        public FilaReproducao(int tamanhoMaximo)
        {
            capacidade = tamanhoMaximo > 0 ? tamanhoMaximo : 10;
            elementos = new Musica[capacidade];
            inicio = 0;
            fim = -1;
            tamanho = 0;
        }

        public bool EstaVazia()
        {
            return tamanho == 0;
        }

        public bool EstaCheia()
        {
            return tamanho == capacidade;
        }

        public bool Enfileirar(Musica musica)
        {
            if (musica == null)
            {
                return false;
            }

            if (EstaCheia())
            {
                return false;
            }

            fim = (fim + 1) % capacidade;
            elementos[fim] = musica;
            tamanho++;
            return true;
        }

        public Musica Desenfileirar()
        {
            if (EstaVazia())
            {
                return null;
            }

            Musica musica = elementos[inicio];
            elementos[inicio] = null;
            inicio = (inicio + 1) % capacidade;
            tamanho--;
            return musica;
        }

        public Musica VerPrimeiro()
        {
            if (EstaVazia())
            {
                return null;
            }

            return elementos[inicio];
        }

        public void Mostrar()
        {
            Console.WriteLine("Fila de Reprodução:");
            for (int i = 0; i < tamanho; i++)
            {
                int indice = (inicio + i) % capacidade;
                Console.WriteLine(elementos[indice]);
            }
        }
    }
}
