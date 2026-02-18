using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.PagSeguro;

// Componentes do PagSeguro
public class PagSeguroValidator : IPaymentValidator
{
    public bool ValidateCard(string cardNumber)
    {
        Console.WriteLine("PagSeguro: Validando cartão...");
        return cardNumber.Length == 16;
    }
}

