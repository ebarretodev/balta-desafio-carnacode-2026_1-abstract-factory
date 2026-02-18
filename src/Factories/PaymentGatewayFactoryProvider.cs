using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;
using DesignPatternChallenge.Factories.MercadoPago;
using DesignPatternChallenge.Factories.PagSeguro;
using DesignPatternChallenge.Factories.Stripe;

namespace DesignPatternChallenge.Factories;
 public static class PaymentGatewayFactoryProvider
    {
        public static IPaymentGatewayFactory GetFactory(GatewayTypes gatewayType)
        {
            return gatewayType switch
            {
                GatewayTypes.MercadoPago => new MercadoPagoFactory(),
                GatewayTypes.PagSeguro => new PagSeguroFactory(),
                GatewayTypes.Stripe => new StripeFactory(),
                _ => throw new ArgumentException($"Gateway '{gatewayType}' não é suportado", nameof(gatewayType))
            };
        }
    }