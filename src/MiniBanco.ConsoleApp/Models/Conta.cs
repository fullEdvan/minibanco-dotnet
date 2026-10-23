namespace MiniBanco.ConsoleApp.Models;

public abstract class Conta
{
  public string Titular { get; }
  public int Numero { get; }
  public string Tipo { get; protected set; } // Adicionei a propriedade Tipo para armazenar o tipo de conta
  public decimal Saldo { get; protected set; }
  public List<Transacao> Extrato { get; } = []; //inicialização simplificada de lista

  public Conta(string titular, int numero, string tipo, decimal saldoInicial)
  {
    Titular = titular;
    Numero = numero;
    Tipo = tipo;
    Saldo = saldoInicial;
  }

  public void RegistrarTransacao(string descricao, string tipo, decimal valor, int numeroConta)
  {
    var transacao = new Transacao(descricao, tipo, valor, numeroConta);
    Extrato.Add(transacao);
  }
  public void Depositar(string titular, int numero, decimal valor)
  {
    RegistrarTransacao($"Depósito de {valor:C}", "Deposito", valor, numero);
    Saldo += valor;
    Console.WriteLine($"Depósito realizado com sucesso.");
  }
  public virtual void Sacar(string nomeTitular, int numeroConta, decimal valor) { }
  public virtual void AplicarFechamentoMensal(int numeroConta) { }

  public double CalcularPontuacaoEPercentual(int numeroConta)
  {
    int pontuacaoObtida = 0;
    int pontuacaoMaxima = Extrato.Count * 10;
    double percentual = 0;
    foreach (Transacao t in Extrato)
    {
      if (t.NumeroConta == numeroConta)
      {
        if (t.Tipo == "Deposito") pontuacaoObtida += 10;
        else if (t.Tipo == "Saque") pontuacaoObtida += 5;
      }
    }
    percentual = ((double)pontuacaoObtida / pontuacaoMaxima) * 100;
    return percentual;
  }

  public string ClassificarConta(int numeroConta)
  {
    string classificacao;
    double percentual = CalcularPontuacaoEPercentual(numeroConta);

    if (percentual >= 90)
      classificacao = "Conta Saudável";
    else if (percentual >= 60)
      classificacao = "Conta em Atenção";
    else
      classificacao = "Conta em Risco";

      return classificacao;
  }
}


