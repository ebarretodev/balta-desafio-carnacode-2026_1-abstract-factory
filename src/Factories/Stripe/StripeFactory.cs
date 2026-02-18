using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.Stripe;

public class StripeFactory : IPaymentGatewayFactory
{
    public IPaymentLogger CreateLogger()
    {
        return new StripeLogger();
    }

    public IPaymentProcessor CreateProcessor()
    {
        return new StripeProcessor();
    }

    public IPaymentValidator CreateValidator()
    {
        return new StripeValidator();
    }
}