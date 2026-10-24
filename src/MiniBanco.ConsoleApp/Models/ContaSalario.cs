namespace MiniBanco.ConsoleApp.Models;

public class ContaSalario : Conta
{
  public string Empregador { get; }
  public int LimiteSaquesMensais { get; set; } 

  public ContaSalario(string titular, int numero, string tipo = "Conta Salário", decimal saldoInicial = 0.00m, int limiteSaquesMensais = 5, string empregador = "") : base(titular, numero, tipo, saldoInicial)
  {
    LimiteSaquesMensais = limiteSaquesMensais;
    Empregador = empregador;
  }

  public override void Sacar(string nomeTitular, int numeroConta, decimal valor)
  {
    if (valor <= 0)
    {
      Console.WriteLine("Valor de saque inválido.");
      return;
    }

    if (valor > Saldo)
    {
      Console.WriteLine("Saldo insuficiente para o saque.");
      return;
    }

    Saldo -= valor;
    RegistrarTransacao($"Saque de {valor:C}", "Saque", valor, numeroConta);
    LimiteSaquesMensais -= 1;

    if (LimiteSaquesMensais < 0)
    {
      decimal tarifa = 5m;
      Saldo -= tarifa;
      RegistrarTransacao("Tarifa de saque extra", "Tarifa", tarifa, numeroConta);
    }
  }

  public override void AplicarFechamentoMensal(int numeroConta)
  {
    LimiteSaquesMensais = 5;
  }
}