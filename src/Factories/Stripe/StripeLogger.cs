using DesignPatternChallenge.Factories.Interfaces;
namespace DesignPatternChallenge.Factories.Stripe;

public class StripeLogger : IPaymentLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[Stripe Log] {DateTime.Now}: {message}");
    }
}

