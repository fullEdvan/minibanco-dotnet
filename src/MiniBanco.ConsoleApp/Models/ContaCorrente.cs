namespace MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Exceptions;

public class ContaCorrente : Conta
{
  public decimal LimiteChequeEspecial { get; }

  public ContaCorrente(string titular, int numero, string tipo = "Conta Corrente", decimal saldoInicial = 0.00m, decimal limite = 500.00m) : base(titular, numero, tipo, saldoInicial)
  {
    LimiteChequeEspecial = limite;
  }

  public override void Sacar(string nomeTitular, int numeroConta, decimal valor)
  {
    if (valor <= 0)
    {
      Console.WriteLine("⚠️  Valor de saque inválido.");
      return;
    }

    if (valor > Saldo + LimiteChequeEspecial)
    {
      throw new SaldoInsuficienteException("⚠️  Saldo insuficiente para o saque.");
    }

    Saldo -= valor;
    RegistrarTransacao("!", "Saque", "Saque", valor, numeroConta);
  }

  public override void AplicarFechamentoMensal(int numeroConta)
  {
    decimal taxaManutencao = -10.00m;
    Saldo += taxaManutencao;
    RegistrarTransacao("X", "Tarifa de manutenção", "Tarifa", taxaManutencao, numeroConta);
  }
}
