namespace DesignPatternChallenge.Factories.Interfaces;

public interface IPaymentGatewayFactory
{
    IPaymentValidator CreateValidator();
    IPaymentProcessor CreateProcessor();
    IPaymentLogger CreateLogger();
}