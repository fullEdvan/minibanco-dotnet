namespace MiniBanco.ConsoleApp.Models;

public class Transacao
{
  public string Descricao { get; }
  public string Tipo { get; }
  public decimal Valor { get; }
  public int NumeroConta {get;}

  public Transacao(string descricao, string tipo, decimal valor, int numeroConta)
  {
    if (tipo != "Deposito" && tipo != "Saque" && tipo != "Tarifa")
    {
      throw new ArgumentException("Tipo de transação inválido.");
    }

    if (valor <= 0)
    {
      throw new ArgumentException("Valor da transação deve ser maior que zero.");
    }

    this.Descricao = descricao;
    this.Tipo = tipo;
    this.Valor = valor;
    this.NumeroConta = numeroConta;
  }
}