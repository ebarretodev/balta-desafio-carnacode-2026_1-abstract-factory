using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.PagSeguro;

public class PagSeguroFactory : IPaymentGatewayFactory
{
    public IPaymentLogger CreateLogger()
    {
        return new PagSeguroLogger();
    }

    public IPaymentProcessor CreateProcessor()
    {
        return new PagSeguroProcessor();
    }

    public IPaymentValidator CreateValidator()
    {
        return new PagSeguroValidator();
    }
}