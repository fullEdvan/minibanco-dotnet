namespace MiniBanco.ConsoleApp.Models;

public class Transacao
{
  public string Check {get; } 
  public string Descricao { get; }
  public string Tipo { get; }
  public decimal Valor { get; }
  public int NumeroConta {get;}

  public Transacao(string check, string descricao, string tipo, decimal valor, int numeroConta)
  {
    if (tipo != "Deposito" && tipo != "Saque" && tipo != "Tarifa")
    {
      throw new ArgumentException("⚠️  Tipo de transação inválido.");
    }

    this.Check = check;
    this.Descricao = descricao;
    this.Tipo = tipo;
    this.Valor = valor;
    this.NumeroConta = numeroConta;
  }
}
