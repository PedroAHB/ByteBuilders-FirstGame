# 🎮 Plataforma 2D – Unity C#

## 📌 Sobre o Projeto
Este é um **jogo de plataforma 2D completo**, desenvolvido na **Unity** com **C#**.  
Criado como o desafio final para a **Liga Acadêmica de introdução ao desenvolvimento de jogos ByteBuilders da UFVJM**, ele aplica conceitos fundamentais de **gamedev** e boas práticas de arquitetura.

O **player** foi estruturado com o **Padrão de Projeto State Machine**, permitindo gerenciar de forma limpa e escalável estados como **Parado**, **Correndo** e **Pulando**.

---

## ✨ Principais Características
- 🕹 **Movimentação e Física 2D** – Controle responsivo com pulo, corrida e colisões.
- 🧠 **Máquina de Estados (State Machine)** – Lógica modular para cada estado (Idle, Run, Jump, etc.).
- 🎨 **Sistema de Animação** – Animações sincronizadas com a máquina de estados via Animator Controller.
- 👾 **IA de Inimigo Simples** – Patrulhamento com detecção de paredes usando OverlapBox.
- 💰 **Colecionáveis e Pontuação** – Moedas que aumentam o **score** via `ScoreManager`.
- 🏆 **Condições de Vitória e Derrota** – Ganhe ao chegar no objetivo, perca ao encostar em inimigos.

---

## 🛠 Tecnologias Utilizadas
- **Engine:** Unity
- **Linguagem:** C#
- **Controles:** Novo Input System da Unity
- **UI:** Unity UI + TextMeshPro

---

## 🎮 Como Jogar
| Tecla | Ação |
|-------|------|
| ⬅ / ➡ | Mover |
| Barra de Espaço | Pular |

---

## 🚀 Como Executar
1. Clone o repositório:
   ```bash
   git clone https://github.com/PedroAHB/ByteBuilders-FirstGame
