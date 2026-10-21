namespace MiniBanco.ConsoleApp.Models;

public class ContaCorrente : Conta
{
    public decimal LimiteChequeEspecial { get; }
 
    public ContaCorrente(string titular, int numero, string tipo = "Conta Corrente", decimal saldoInicial = 0.00m, decimal limite = 500.00m) : base(titular, numero, tipo, saldoInicial)
    {
        LimiteChequeEspecial = limite;
    }
 
    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Valor de saque inválido.");
            return;
        }

        if (valor > Saldo + LimiteChequeEspecial)
        {
            Console.WriteLine("Saldo insuficiente para o saque.");
            return;
        }

        Saldo -= valor;
        RegistrarTransacao($"Saque de {valor:C}", "Saque", valor);
    }
 
    public override void AplicarFechamentoMensal()
    {
        decimal taxaManutencao = -10.00m;
        Saldo += taxaManutencao;
        RegistrarTransacao("Fechamento Mensal", "Tarifa", taxaManutencao);
    }
}