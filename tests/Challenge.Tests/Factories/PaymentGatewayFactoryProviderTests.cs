using DesignPatternChallenge.Factories;
using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;
using FluentAssertions;
using Xunit;

namespace Challenge.Tests.Factories;

public class PaymentGatewayFactoryProviderTests
{
    [Theory]
    [InlineData(GatewayTypes.Stripe)]
    [InlineData(GatewayTypes.PagSeguro)]
    [InlineData(GatewayTypes.MercadoPago)]
    public void GetFactory_ShouldReturnCorrectFactory_ForValidGatewayType(GatewayTypes gatewayType)
    {
        // Act
        var factory = PaymentGatewayFactoryProvider.GetFactory(gatewayType);

        // Assert
        factory.Should().NotBeNull();
        factory.Should().BeAssignableTo<IPaymentGatewayFactory>();
    }

    [Fact]
    public void GetFactory_ShouldReturnDifferentInstances_ForDifferentGateways()
    {
        // Act
        var stripeFactory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.Stripe);
        var pagSeguroFactory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.PagSeguro);
        var mercadoPagoFactory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.MercadoPago);

        // Assert
        stripeFactory.Should().NotBeSameAs(pagSeguroFactory);
        pagSeguroFactory.Should().NotBeSameAs(mercadoPagoFactory);
        stripeFactory.Should().NotBeSameAs(mercadoPagoFactory);
    }
}
