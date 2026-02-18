using DesignPatternChallenge.Factories.Interfaces;
namespace DesignPatternChallenge.Factories.PagSeguro;

public class PagSeguroLogger : IPaymentLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[PagSeguro Log] {DateTime.Now}: {message}");
    }
}

