# 🏦 MiniBanco .Net
 > Um motor de gestão de contas bancárias em C#, com paradigma em Programação Orientada a Objeto (POO), tratamento de exceções customizadas e logs de transações.

---

## 💻 Tecnologias Utilizadas

O projeto foi construído utilizando as seguintes tecnologias e ferramentas:

* **Linguagem:** C# (.NET 10)
* **Arquitetura:** Orientada a Objetos (OOP)
* **Controle de Versão:** Git e GitHub
* **Ambiente de Desenvolvimento:** VS Code

---

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter os seguintes itens instalados na sua máquina:
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* Um editor de código de sua preferência (ex: **VS Code**)

---

## 📥 Como Instalar e Executar

Siga os passos abaixo para clonar e rodar o projeto localmente:

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/fullEdvan/minibanco-dotnet.git

2. Entre na pasta do projeto:
   ```bash
   cd .\minibanco-dotnet\src\MiniBanco.ConsoleApp\
3. Execute a aplicação:
   ```bash
   dotnet run

## 🎮 Como Usar
Assim que a aplicação iniciar, o console exibirá o menu interativo com as seguintes opções:

1- Conta Corrente  2- Conta Poupança  3- Conta Salário  0- Cancelar

## ⚙️ Principais Funcionalidades & Regras de Negócio
- **Gestão de Contas:** Suporte a Conta Corrente, Conta Poupança e Conta Salário.
- **Movimentações:** Registro de depósitos e saques com validação de saldo e exceções customizadas (`SaldoInsuficienteException`).
- **Fechamento Mensal e Relatórios:** Processamento automatizado de extratos, cálculo de pontuação de saúde financeira e emissão de recomendações gerenciais.

## ⚠️ Limitações Conhecidas
- Por ser uma aplicação de console (Console Application), os dados de contas e transações são armazenados em memória volátil e serão reiniciados ao fechar o programa (sem banco de dados relacional persistente nesta versão).

## 📂 Estrutura do Projeto

```text
minibanco-dotnet/
├── src/
│   └── MiniBanco.ConsoleApp/
│       ├── Program.cs
│       ├── Models/
│       │   ├── Transacao.cs
│       │   ├── Conta.cs
│       │   ├── ContaCorrente.cs
│       │   ├── ContaPoupanca.cs
│       │   └── ContaSalario.cs
│       ├── Exceptions/
│       │   └── SaldoInsuficienteException.cs
│       ├── Views/
│       │   └── ConsoleUI.cs
│       └── MiniBanco.ConsoleApp.csproj
└── README.md


## 🤝 Contribuindo

Contribuições são sempre bem-vindas!
Se você precisar, ou souber de quem esteja precisando de um desenvolvendor back-end C# .Net, o autor aqui está em formação pelo SCTEC/SENAI, e amará colocar os seus conhecimentos a serviço da sua empresa e/ou dos seus projetos.
Ou abra um Pull Request para sugestões de melhoria do projeto.

## 📝 Licença

MIT License - código livre para aproveitar, e deixa uma ⭐️ no repositório, se ele lhe ajudar! ✌️
