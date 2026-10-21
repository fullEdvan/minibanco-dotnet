namespace MiniBanco.ConsoleApp.Models;

public class ContaPoupanca : Conta
{
    public decimal TaxaRendimentoMensal { get; }
    public int DiaAniversario { get; } = 1; // Dia do mês em que o rendimento é aplicado

    public ContaPoupanca(string titular, int numero, string tipo = "Conta Poupança", decimal saldoInicial = 0.00m, decimal taxaRendimentoMensal = 0.005m) : base(titular, numero, tipo, saldoInicial)
    {
        TaxaRendimentoMensal = taxaRendimentoMensal;
    }

    public override void Sacar(decimal valor)
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
        RegistrarTransacao($"Saque de {valor:C}", "Saque", valor);
    }

    public override void AplicarFechamentoMensal()
    {
        decimal rendimento = Saldo * TaxaRendimentoMensal;
        Saldo += rendimento;
        RegistrarTransacao("Fechamento Mensal", "Deposito", rendimento);
    }
}