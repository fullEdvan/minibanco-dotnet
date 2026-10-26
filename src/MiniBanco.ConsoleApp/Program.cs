namespace MiniBanco.ConsoleApp;

using MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Views;

class Program
{
  static void Main(string[] args)
  {
    List<Conta> contas = new List<Conta>();
    int opcao;

    do
    {
      ConsoleUI.MostrarMenuPrincipal();
      Console.Write("Escolha uma opção: ");

      if (int.TryParse(Console.ReadLine(), out opcao))
      {
        switch (opcao)
        {
          case 1: ConsoleUI.AbrirNovaConta(contas); break;
          case 2: ConsoleUI.RegistrarMovimentação(contas); break;
          case 3: ConsoleUI.AplicarFechamentoMensal(contas); break;
          case 4: ConsoleUI.ExibirRelatorio(contas); break;
          case 0: Console.WriteLine("Saindo do sistema... Até logo!\n"); break;
          default: Console.WriteLine("❌  Opção inválida!\nEscolha um número entre 0 e 4."); break;
        }
      }
      else
      {
        opcao = -1;
        Console.WriteLine("❌  Opção inválida!\nDigite um número válido.");
      }

      Console.WriteLine("\nPressione qualquer tecla para continuar...");
      Console.ReadKey();
      Console.Clear();

    } while (opcao != 0);
  }
}
