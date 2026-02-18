using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.Stripe;

public class StripeProcessor : IPaymentProcessor
{
    public string ProcessTransaction(decimal amount, string cardNumber)
    {
        Console.WriteLine($"Stripe: Processando R$ {amount}...");
        return $"STRIPE-{Guid.NewGuid().ToString().Substring(0, 8)}";
    }
}
