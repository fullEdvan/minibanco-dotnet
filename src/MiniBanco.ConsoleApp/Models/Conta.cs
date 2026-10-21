namespace MiniBanco.ConsoleApp.Models;

public abstract class Conta
{
  public string Titular { get; }
  public int Numero { get; }
  public string Tipo {get; protected set;} // Adicionei a propriedade Tipo para armazenar o tipo de conta
  public decimal Saldo { get; protected set; }
  public List<Transacao> Extrato { get; } = []; //inicialização simplificada de lista

public Conta(string titular, int numero, string tipo, decimal saldoInicial)
  {
    Titular = titular;
    Numero = numero;
    Tipo = tipo;
    Saldo = saldoInicial;
  }

  public void RegistrarTransacao(string descricao, string tipo, decimal valor)
  {
    var transacao = new Transacao(descricao, tipo, valor);
    Extrato.Add(transacao);
  }
  public void Depositar(string titular, int numero, decimal valor)
  {
    RegistrarTransacao($"Depósito de {valor:C}", "Deposito", valor);
    Saldo += valor;
    Console.WriteLine($"Depósito realizado com sucesso.");
  }
  public virtual void Sacar(decimal valor) { }
  public virtual void AplicarFechamentoMensal() { }
}