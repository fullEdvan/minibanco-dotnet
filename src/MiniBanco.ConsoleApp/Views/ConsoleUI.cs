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

  public static void MostrarFim()
  {
    Console.WriteLine("\n\t\t\t\t=========================================================");
    Console.WriteLine("\t\t\t\t\t\tFIM DO PROCESSAMENTO DE CONTAS\t\t");
    Console.WriteLine("\t\t\t\t=========================================================\n");
  }

  public static void MostrarMenuPrincipal()
  {
    MostrarTitulo();
    Console.WriteLine("\n> MENU PRINCIPAL");
    Console.Write("\n1- Abrir Nova Conta\t  ");
    Console.Write("2- Registrar Movimentação\t");
    Console.Write("3- Aplicar Fechamento Mensal\t");
    Console.Write("4- Exibir Relatório das Contas\t");
    Console.WriteLine("0- Sair\t");
  }

  public static void AbrirNovaConta(List<Conta> contas)
  {
    MostrarTitulo();
    Console.WriteLine("\n> ABRIR NOVA CONTA\n");
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
    MostrarTitulo();
    Console.WriteLine("\n> REGISTRAR MOVIMENTAÇÃO\n");
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
          Console.Write("\nQual a descrição do depósito? ");
          string descricaoOperacao = Console.ReadLine();

          Console.Write("\nQuanto deseja depositar? R$");
          decimal valor = decimal.Parse(Console.ReadLine());
          contaEncontrada.Depositar(contaEncontrada.Titular, contaEncontrada.Numero, valor, descricaoOperacao);
        }
        else if (operacao == "2")
        {
          Console.Write("\nQuanto deseja sacar? R$");
          decimal valor = decimal.Parse(Console.ReadLine());
          contaEncontrada.Sacar(contaEncontrada.Titular, contaEncontrada.Numero, valor);
        }
      }
      else
      {
        Console.WriteLine("\nNúmero de conta inexistente.");
      }
    }
  }

  public static void AplicarFechamentoMensal(List<Conta> contas)
  {
    MostrarTitulo();
    Console.WriteLine("\n> APLICAR FECHAMENTO MENSAL\n");

    if (contas.Count == 0)
    {
      Console.WriteLine("Não há contas cadastradas para realizar o fechamento.");
      return;
    }

    foreach (var conta in contas)
    {
      conta.AplicarFechamentoMensal(conta.Numero);
    }

    Console.WriteLine("Fechamento mensal aplicado com sucesso para todas as contas!");
  }

  public static void ExibirResumoDaConta(Conta conta)
  {
    Console.WriteLine($"\nConta Número: {conta.Numero}, Titular: {conta.Titular}, Tipo: {conta.Tipo}, Saldo: {conta.Saldo:C}");
  }

  public static void ExibirRelatorio(List<Conta> contas)
  {
    MostrarTitulo();
    int indice = 1;

    if (contas.Count == 0) Console.WriteLine("\n> Nenhuma conta aberta até o momento.");

    foreach (var conta in contas)
    {
      string atributoEspecifico = conta.Tipo switch
      {
        "Conta Corrente" => "Limite Cheque Especial: R$500,00",
        "Conta Poupança" => "Rendimento: 0,5% ao mês | Aniversário: dia 10",
        _ => "Nenhum"
      };

      Console.WriteLine($"\n[{indice}/{contas.Count}] PROCESSANDO CONTA");
      Console.WriteLine("---------------------------------------------------------");
      Console.WriteLine($@"> DADOS DA CONTA:
  - Tipo: {conta.Tipo}
  - Titular: {conta.Titular} | Conta: {conta.Numero}
  - Atributo Específico: {atributoEspecifico}
  - Saldo Atual: R${conta.Saldo:N2}");

      int trasacoes = conta.Extrato.Count;
      string classificacao = conta.ClassificarConta(conta.Numero);

      Console.WriteLine($"\n> MOVIMENTAÇÕES REGISTRADAS ({trasacoes} TRANSAÇÕES):");
      foreach (var transacao in conta.Extrato)
      {
        int pontuacao = 0;
        if (transacao.Tipo == "Deposito") pontuacao = 10;
        else if (transacao.Tipo == "Saque") pontuacao = 5;
        else if (transacao.Tipo == "Tarifa") pontuacao = 0;

        string checkFormatado = transacao.Check.Length == 1 ? $" {transacao.Check} " : $" {transacao.Check}";
        Console.WriteLine($"  [{checkFormatado}] {transacao.Descricao.PadRight(30, '-')} {transacao.Tipo}: R$ {transacao.Valor:N2} ({pontuacao} pts)");
      }

      (double percentual, int pontuacaoObtida, int pontuacaoMaxima) = conta.CalcularPontuacaoEPercentual(conta.Numero);
      Console.WriteLine("\n> RESUMO DA PONTUAÇÃO:");
      Console.WriteLine($@"  - Pontuação Atingida: {pontuacaoObtida} de {pontuacaoMaxima} pontos possíveis
  - Índice de Saúde: {percentual:F1}%
  - Classificação Final: [ {classificacao} ]");


      Console.WriteLine("\n> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES DA GERÊNCIA:");

      if (classificacao == "CONTA SAUDÁVEL") Console.WriteLine("\n🟢 Oferecer produtos de investimentos ao cliente, e avaliar aumento de limite.");
      else if (classificacao == "CONTA EM ATENÇÃO") Console.WriteLine("🟡 Contato da gerência para orientação financeira e revisão de tarifas.");
      else if (classificacao == "CONTA EM RISCO") Console.WriteLine("🔴 Bloquear aumento de limite e abrir análise de crédito.");

      Console.WriteLine("---------------------------------------------------------");
      indice++;
    }

    MostrarFim();
  }
}
