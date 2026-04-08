# 🎵 Player Musical (C#)

![C#](https://img.shields.io/badge/Language-C%23-blue) ![.NET](https://img.shields.io/badge/.NET-Console-green) ![Estruturas de Dados](https://img.shields.io/badge/Data%20Structures-Lista%20%7C%20Fila%20%7C%20Pilha%20%7C%20Árvore-orange)

Projeto desenvolvido como trabalho final da disciplina **Algoritmos e Estruturas de Dados**.  
Player de música em **console**, focado na aplicação de estruturas como listas duplamente encadeadas, filas, pilhas e árvores binárias de gênero.

---

## 🚀 Funcionalidades

- 🎵 Gerenciar catálogo de músicas (adicionar, remover, buscar)
- 🎶 Criar e gerenciar playlists
- ⏯️ Adicionar músicas à fila de reprodução
- ▶️ Tocar próxima música
- 📜 Visualizar fila de reprodução e histórico de músicas tocadas
- 🌳 Organização de músicas em árvore binária por gênero

---

## 🛠️ Tecnologias e Conceitos

- Linguagem: C#
- Tipo de projeto: .NET Console Application (aplicação de console)
- Estruturas de dados aplicadas:
  - Lista duplamente encadeada (`ListaMusicas`)
  - Fila circular (`FilaReproducao`)
  - Pilha limitada (`HistoricoReproducao`)
  - Árvore binária (`ArvoreGenerosMusicais`)

---

## 📂 Como rodar
1. Clone o repositório:  
   ```bash
git clone https://github.com/camilytec/Player-Musical.git ````  

## 🗂️ Estrutura do projeto
PlayerMusical/
│
├─ Classes/                 # Classes do player: Música, Playlist, FilaReproducao, HistoricoReproducao, ArvoreGenerosMusicais etc.
├─ Program.cs               # Menu principal e lógica de interação
├─ musicas.csv              # Arquivo opcional para carregar músicas automaticamente
└─ log.txt                  # Histórico de ações

## 💡 Observações
Funciona totalmente via console.
A chave das músicas é formada por Título - Artista.
Estruturas de dados aplicadas para controle de catálogo, fila, histórico e organização por gênero.

## 👩‍💻 Autores
Camily Barbosa
Gabriel
