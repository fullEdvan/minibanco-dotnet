namespace MiniBanco.ConsoleApp;

using MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Views;

class Program
{
  static void Main(string[] args)
  {
    // ConsoleUI.MostrarTitulo();

    int opcao = -1;
    List<Conta> contas = new List<Conta>();

    while (opcao != 0)
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
          case 0: Console.WriteLine("Saindo...\n"); break;
          default: Console.WriteLine("Opção inválida!\nDigite um número válido."); break;
        }
      }
      else
      {
        opcao = -1;
        Console.WriteLine("Opção inválida!\nDigite um número válido.");
      }
    }
  }
}
