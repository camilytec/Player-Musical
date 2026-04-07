using System;

namespace PlayerMusical.Classes
{
    public class HistoricoReproducao
    {
        private Musica[] elementos;
        private int topo;
        private int capacidade;

        public HistoricoReproducao(int tamanho)
        {
            if (tamanho > 0)
            {
                capacidade = tamanho;
            }
            else
            {
                capacidade = 10;
            }

            elementos = new Musica[capacidade];
            topo = -1;
        }

        public bool EstaVazia()
        {
            if (topo == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Empilhar(Musica musica)
        {
            if (musica == null)
            {
                return false;
            }

            if (topo < capacidade - 1)
            {
                topo = topo + 1;
                elementos[topo] = musica;
                return true;
            }

            int i = 0;
            while (i < capacidade - 1)
            {
                elementos[i] = elementos[i + 1];
                i = i + 1;
            }

            elementos[capacidade - 1] = musica;
            topo = capacidade - 1;
            return true;
        }

        public Musica Desempilhar()
        {
            if (EstaVazia())
            {
                return null;
            }

            Musica musica = elementos[topo];
            elementos[topo] = null;
            topo = topo - 1;
            return musica;
        }

        public Musica VerTopo()
        {
            if (EstaVazia())
            {
                return null;
            }

            return elementos[topo];
        }

        public void Mostrar()
        {
            Console.WriteLine("Histórico de Reprodução:");

            int i = topo;
            while (i >= 0)
            {
                Console.WriteLine(elementos[i]);
                i = i - 1;
            }
        }
    }
}
