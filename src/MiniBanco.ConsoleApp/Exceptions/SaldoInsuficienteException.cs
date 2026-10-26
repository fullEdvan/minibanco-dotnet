namespace MiniBanco.ConsoleApp.Exceptions;

public class SaldoInsuficienteException : Exception
{
  public SaldoInsuficienteException() : base("⚠️  Saldo insuficiente para realizar esta operação.") { }
  public SaldoInsuficienteException(string message) : base(message) { }
}
