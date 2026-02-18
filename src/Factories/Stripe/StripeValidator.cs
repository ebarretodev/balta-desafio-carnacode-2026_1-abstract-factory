using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.Stripe;

public class StripeValidator : IPaymentValidator
{
    public bool ValidateCard(string cardNumber)
    {
        Console.WriteLine("Stripe: Validando cartão...");
        return cardNumber.Length == 16 && cardNumber.StartsWith("4");
    }
}
