namespace DesignPatternChallenge.Factories.Interfaces;

public interface IPaymentValidator
{
    bool ValidateCard(string cardNumber);
}
