namespace MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Exceptions;

public class ContaPoupanca : Conta
{
    public decimal TaxaRendimentoMensal { get; }
    public int DiaAniversario { get; } = 1; // Dia do mês em que o rendimento é aplicado

    public ContaPoupanca(string titular, int numero, string tipo = "Conta Poupança", decimal saldoInicial = 0.00m, decimal taxaRendimentoMensal = 0.005m) : base(titular, numero, tipo, saldoInicial)
    {
        TaxaRendimentoMensal = taxaRendimentoMensal;
    }

    public override void Sacar(string nomeTitular, int numeroConta, decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("⚠️  Valor de saque inválido.");
            return;
        }

        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException("⚠️  Saldo insuficiente para o saque.");
        }

        Saldo -= valor;
        RegistrarTransacao("!", "Saque", "Saque", valor, numeroConta);
    }

    public override void AplicarFechamentoMensal(int numeroConta)
    {
        decimal rendimento = Saldo * TaxaRendimentoMensal;
        Saldo += rendimento;
        RegistrarTransacao("OK", "Rendimento Mensal", "Deposito", rendimento, numeroConta);
    }
}
