using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.MercadoPago;

public class MercadoPagoProcessor : IPaymentProcessor
{
    public string ProcessTransaction(decimal amount, string cardNumber)
    {
        Console.WriteLine($"MercadoPago: Processando R$ {amount}...");
        return $"MP-{Guid.NewGuid().ToString().Substring(0, 8)}";
    }
}

