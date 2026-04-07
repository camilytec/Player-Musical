using System;

namespace PlayerMusical.Classes
{
    public class NoLista
    {
        private Musica musica;
        private NoLista proximo;
        private NoLista anterior;

        public NoLista(Musica valor)
        {
            musica = valor;
            proximo = null;
            anterior = null;
        }

        public Musica Musica
        {
            get { return musica; }
            set { musica = value; }
        }

        public NoLista Proximo
        {
            get { return proximo; }
            set { proximo = value; }
        }

        public NoLista Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
    }

    public class ListaMusicas
    {
        private NoLista inicio;
        private NoLista fim;

        public ListaMusicas()
        {
            inicio = null;
            fim = null;
        }

        public void Adicionar(Musica musica)
        {
            NoLista novo = new NoLista(musica);

            if (inicio == null)
            {
                inicio = novo;
                fim = novo;
            }
            else
            {
                fim.Proximo = novo;
                novo.Anterior = fim;
                fim = novo;
            }
        }

        public void Mostrar()
        {
            NoLista atual = inicio;

            while (atual != null)
            {
                Console.WriteLine(atual.Musica);
                atual = atual.Proximo;
            }
        }

        public void MostrarOrdenadoPorTitulo()
        {
            NoLista[] vetor = ConverterParaVetor();
            OrdenarPorTitulo(vetor);

            int i = 0;
            while (i < vetor.Length)
            {
                Console.WriteLine(vetor[i].Musica);
                i++;
            }
        }

        public void MostrarOrdenadoPorDuracao()
        {
            NoLista[] vetor = ConverterParaVetor();
            OrdenarPorDuracao(vetor);

            int i = 0;
            while (i < vetor.Length)
            {
                Console.WriteLine(vetor[i].Musica);
                i++;
            }
        }

        private NoLista[] ConverterParaVetor()
        {
            int contador = 0;
            NoLista atual = inicio;

            while (atual != null)
            {
                contador++;
                atual = atual.Proximo;
            }

            NoLista[] vetor = new NoLista[contador];

            atual = inicio;
            int i = 0;

            while (atual != null)
            {
                vetor[i] = atual;
                i++;
                atual = atual.Proximo;
            }

            return vetor;
        }

        private void OrdenarPorTitulo(NoLista[] vetor)
        {
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                for (int j = i + 1; j < vetor.Length; j++)
                {
                    if (string.Compare(vetor[i].Musica.Titulo, vetor[j].Musica.Titulo) > 0)
                    {
                        NoLista aux = vetor[i];
                        vetor[i] = vetor[j];
                        vetor[j] = aux;
                    }
                }
            }
        }

        private void OrdenarPorDuracao(NoLista[] vetor)
        {
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                for (int j = i + 1; j < vetor.Length; j++)
                {
                    if (vetor[i].Musica.Duracao > vetor[j].Musica.Duracao)
                    {
                        NoLista aux = vetor[i];
                        vetor[i] = vetor[j];
                        vetor[j] = aux;
                    }
                }
            }
        }
        public void Remover(Musica musica)
        {
            NoLista atual = inicio;
            while (atual != null)
            {
                if (atual.Musica.Chave == musica.Chave)
                {
                    if (atual.Anterior != null)
                        atual.Anterior.Proximo = atual.Proximo;
                    else
                        inicio = atual.Proximo;

                    if (atual.Proximo != null)
                        atual.Proximo.Anterior = atual.Anterior;
                    else
                        fim = atual.Anterior;

                    break;
                }
                atual = atual.Proximo;
            }
        }
    }
}
