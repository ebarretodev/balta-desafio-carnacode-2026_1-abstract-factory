using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge.Factories.MercadoPago;

public class MercadoPagoFactory : IPaymentGatewayFactory
{
    public IPaymentLogger CreateLogger()
    {
        return new MercadoPagoLogger();
    }

    public IPaymentProcessor CreateProcessor()
    {
        return new MercadoPagoProcessor();
    }

    public IPaymentValidator CreateValidator()
    {
        return new MercadoPagoValidator();
    }
}