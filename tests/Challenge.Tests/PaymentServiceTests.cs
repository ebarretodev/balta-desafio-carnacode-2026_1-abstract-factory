using DesignPatternChallenge;
using DesignPatternChallenge.Factories.Enums;
using FluentAssertions;
using Xunit;

namespace Challenge.Tests;

public class PaymentServiceTests
{

    [Theory]
    [InlineData(GatewayTypes.Stripe, 100.00, "4234567890123456")]
    [InlineData(GatewayTypes.PagSeguro, 200.00, "5234567890123456")]
    [InlineData(GatewayTypes.MercadoPago, 300.00, "5234567890123456")]
    public void ProcessPayment_ShouldProcessSuccessfully_ForAllGateways(GatewayTypes gatewayType, decimal amount, string cardNumber)
    {
        // Arrange
        var service = new PaymentService(gatewayType);

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ProcessPayment_WithStripe_ShouldSucceed()
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.Stripe);
        var amount = 150.00m;
        var cardNumber = "4234567890123456";

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ProcessPayment_WithPagSeguro_ShouldSucceed()
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.PagSeguro);
        var amount = 250.00m;
        var cardNumber = "5234567890123456";

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ProcessPayment_WithMercadoPago_ShouldSucceed()
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.MercadoPago);
        var amount = 350.00m;
        var cardNumber = "5234567890123456";

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(0.99)]
    [InlineData(1.00)]
    public void ProcessPayment_WithSmallAmounts_ShouldSucceed(decimal amount)
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.Stripe);
        var cardNumber = "4234567890123456";

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(10000.00)]
    [InlineData(50000.00)]
    [InlineData(99999.99)]
    public void ProcessPayment_WithLargeAmounts_ShouldSucceed(decimal amount)
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.MercadoPago);
        var cardNumber = "5234567890123456";

        // Act
        var result = service.ProcessPayment(amount, cardNumber);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ProcessPayment_WithInvalidCardNumber_ShouldThrowException()
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.Stripe);
        var amount = 100.00m;
        var invalidCardNumber = "123"; // Menos de 16 dígitos

        // Act
        var act = () => service.ProcessPayment(amount, invalidCardNumber);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ProcessPayment_WithNullCardNumber_ShouldThrowException()
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.Stripe);
        var amount = 100.00m;

        // Act
        var act = () => service.ProcessPayment(amount, null!);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100.50)]
    public void ProcessPayment_WithInvalidAmount_ShouldThrowException(decimal amount)
    {
        // Arrange
        var service = new PaymentService(GatewayTypes.Stripe);
        var cardNumber = "4234567890123456";

        // Act
        var act = () => service.ProcessPayment(amount, cardNumber);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
