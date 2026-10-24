namespace MiniBanco.ConsoleApp;

using MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Views;

class Program
{
  static void Main(string[] args)
  {
    ConsoleUI.MostrarTitulo();

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
          case 1:
            {
              ConsoleUI.AbrirNovaConta(contas);
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
