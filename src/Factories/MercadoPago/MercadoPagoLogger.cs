using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.MercadoPago;

public class MercadoPagoLogger : IPaymentLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[MercadoPago Log] {DateTime.Now}: {message}");
    }
}

