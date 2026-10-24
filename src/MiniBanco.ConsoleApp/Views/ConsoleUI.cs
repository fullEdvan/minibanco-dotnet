namespace MiniBanco.ConsoleApp.Views;

using MiniBanco.ConsoleApp.Models;

public class ConsoleUI
{
  private static int numero = 0;

  public static void MostrarTitulo()
  {
    Console.WriteLine("\n\t\t\t\t=========================================================");
    Console.WriteLine("\t\t\t\t|\tMINIBANCO .NET - MOTOR DE GESTÃO DE CONTAS\t|");
    Console.WriteLine("\t\t\t\t=========================================================\n");
  }

  public static void MostrarMenuPrincipal()
  {
    Console.WriteLine("\nMENU PRINCIPAL");
    Console.Write("\n1- Abrir Nova Conta\t  ");
    Console.Write("2- Registrar Movimentação\t");
    Console.Write("3- Aplicar Fechamento Mensal\t");
    Console.Write("4- Exibir Relatório  das Contas\t");
    Console.WriteLine("0- Sair\t");
  }

  public static void AbrirNovaConta(List<Conta> contas)
  {
    Console.WriteLine("\nABRIR NOVA CONTA\n");
    Console.WriteLine("1- Conta Corrente\t2- Conta Poupança \t3- Conta Salário \t0- Cancelar");
    Console.Write("Qual o tipo de conta deseja abrir? ");

    if (int.TryParse(Console.ReadLine(), out int opcao))
    {
      if (opcao == 0) return;

      string tipoConta = opcao switch
      {
        1 => "CONTA CORRENTE",
        2 => "CONTA POUPANÇA",
        3 => "CONTA SALÁRIO",
        _ => string.Empty
      };

      if (string.IsNullOrEmpty(tipoConta))
      {
        Console.WriteLine("Tipo de conta inválido. Operação cancelada.");
        return;
      }

      Console.WriteLine($"\n{tipoConta}\n");
      Console.Write("Digite o nome do titular da conta: ");
      string entrada = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(entrada))
      {
        numero++;
        Conta conta = opcao switch
        {
          1 => new ContaCorrente(entrada, numero),
          2 => new ContaPoupanca(entrada, numero),
          3 => new ContaSalario(entrada, numero),
          _ => null
        };

        if (conta != null)
        {
          contas.Add(conta);
          Console.WriteLine("Conta aberta com sucesso!");
        }
      }
      else
      {
        Console.WriteLine("Nome do titular inválido. Operação cancelada.");
      }
    }
  }

  public static void RegistrarMovimentação(List<Conta> contas)
  {
    Console.WriteLine("\nREGISTRAR MOVIMENTAÇÃO\n");
    Console.Write("Qual o número da conta que deseja movimentar? ");

    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int numeroConta))
    {
      Conta contaEncontrada = null;

      foreach (var conta in contas)
      {
        if (numeroConta == conta.Numero)
        {
          contaEncontrada = conta;
          break;
        }
      }

      if (contaEncontrada != null)
      {
        Console.WriteLine($"1- Depósito\t2- Saque");
        Console.Write($"Qual operação deseja realizar? ");
        string operacao = Console.ReadLine();
        if (operacao == "1")
        {
          Console.Write("\n\nQuanto deseja depositar? R$");
          decimal valor = decimal.Parse(Console.ReadLine());
          contaEncontrada.Depositar(contaEncontrada.Titular, contaEncontrada.Numero, valor);
        } else if (operacao == "2")
        {
          Console.Write("\n\nQuanto deseja sacar? R$");
          decimal valor = decimal.Parse(Console.ReadLine());
          contaEncontrada.Sacar(contaEncontrada.Titular, contaEncontrada.Numero, valor);
        }
      } else
      {
        Console.WriteLine("\nNúmero de conta inexistente.");
      }
    }
  }
}
