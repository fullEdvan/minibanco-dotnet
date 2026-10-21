namespace MiniBanco.ConsoleApp;

using MiniBanco.ConsoleApp.Models;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("\n\t\t\t\t=========================================================");
    Console.WriteLine("\t\t\t\t|\tMINIBANCO .NET - MOTOR DE GESTÃO DE CONTAS\t|");
    Console.WriteLine("\t\t\t\t=========================================================\n");

    int opcao = -1;
    List<Conta> contas = new List<Conta>();
    int numero = 0;

    while (opcao != 0)
    {
      // MostrarMenu();
      Console.WriteLine("\nMENU PRINCIPAL");
      Console.Write("\n1- Abrir Nova Conta\t  ");
      Console.Write("2- Registrar Movimentação\t");
      Console.Write("3- Aplicar Fechamento Mensal\t");
      Console.Write("4- Exibir Relatório  das Contas\t");
      Console.WriteLine("0- Sair\t");
      Console.Write("Escolha uma opção: ");

      if (int.TryParse(Console.ReadLine(), out opcao))
      {
        switch (opcao)
        {
          case 1:
            {
              Console.WriteLine("\nABRIR NOVA CONTA\n");
              Console.WriteLine("1- Conta Corrente\t2- Conta Poupança \t3- Conta Salário \t0- Cancelar");
              Console.Write("Qual o tipo de conta deseja abrir? ");
              if (int.TryParse(Console.ReadLine(), out opcao))
              {
                if (opcao == 1)
                {
                  Console.WriteLine("\nCONTA CORRENTE\n");
                  Console.Write("Digite o nome do titular da conta: ");
                  string entrada = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(entrada))
                  {
                    string titular = entrada;
                    numero++;
                    Conta conta = new ContaCorrente(titular, numero);
                    contas.Add(conta);
                    Console.WriteLine("Conta aberta com sucesso!");
                  }
                  else
                  {
                    Console.WriteLine("Nome do titular inválido. Operação cancelada.");
                  }
                } else if (opcao == 2)
                {
                  Console.WriteLine("\nCONTA POUPANÇA\n");
                  Console.Write("Digite o nome do titular da conta: ");
                  string entrada = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(entrada))
                  {
                    string titular = entrada;
                    numero++;
                    Conta conta = new ContaPoupanca(titular, numero);
                    contas.Add(conta);
                    Console.WriteLine("Conta aberta com sucesso!");
                  }
                  else
                  {
                    Console.WriteLine("Nome do titular inválido. Operação cancelada.");
                  }
                } else if (opcao == 3)
                {
                  Console.WriteLine("\nCONTA SALARIO\n");
                  Console.Write("Digite o nome do titular da conta: ");
                  string entrada = Console.ReadLine();
                  if (!string.IsNullOrWhiteSpace(entrada))
                  {
                    string titular = entrada;
                    numero++;
                    Conta conta = new ContaSalario(titular, numero);
                    contas.Add(conta);
                    Console.WriteLine("Conta aberta com sucesso!");
                  }
                  else
                  {
                    Console.WriteLine("Nome do titular inválido. Operação cancelada.");
                  }
                } 
              }
              break;
            }
          case 2: Console.WriteLine("Registrar Movimentação"); break;
          case 3: Console.WriteLine("Aplicar Fechamento Mensal"); break;
          case 4: Console.WriteLine("Exibir Relatório  das Contas"); break;
          case 0: Console.WriteLine("Saindo...\n"); break;
          default: Console.WriteLine("Opção inválida!\nDigite um número válido."); break;
        }
      }
      else
      {
        opcao = -1; // Reset opcao to continue the loop
        Console.WriteLine("Opção inválida!\nDigite um número válido.");
      }

      Console.WriteLine(contas.Count > 0 ? "\nContas cadastradas: " + contas.Count : "\nNenhuma conta cadastrada.");

      for (int i = 0; i < contas.Count; i++)
      {
        Console.WriteLine($"Conta Número: {contas[i].Numero}, Titular: {contas[i].Titular}, Tipo: {contas[i].Tipo}, Saldo: {contas[i].Saldo:C}");
      }
    }
  }
}
