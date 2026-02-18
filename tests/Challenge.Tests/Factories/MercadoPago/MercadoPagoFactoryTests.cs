using DesignPatternChallenge.Factories;
using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;
using FluentAssertions;
using Xunit;

namespace Challenge.Tests.Factories.MercadoPago;

public class MercadoPagoFactoryTests
{
    private readonly IPaymentGatewayFactory _factory;

    public MercadoPagoFactoryTests()
    {
        _factory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.MercadoPago);
    }

    [Fact]
    public void CreateProcessor_ShouldReturnMercadoPagoProcessor()
    {
        // Act
        var processor = _factory.CreateProcessor();

        // Assert
        processor.Should().NotBeNull();
        processor.Should().BeAssignableTo<IPaymentProcessor>();
    }

    [Fact]
    public void CreateValidator_ShouldReturnMercadoPagoValidator()
    {
        // Act
        var validator = _factory.CreateValidator();

        // Assert
        validator.Should().NotBeNull();
        validator.Should().BeAssignableTo<IPaymentValidator>();
    }

    [Fact]
    public void CreateLogger_ShouldReturnMercadoPagoLogger()
    {
        // Act
        var logger = _factory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
        logger.Should().BeAssignableTo<IPaymentLogger>();
    }

    [Theory]
    [InlineData(75.50, "5234567890123456")]
    [InlineData(10.00, "5876543210987654")]
    [InlineData(1500.00, "5111222233334444")]
    public void ProcessTransaction_ShouldProcessPaymentSuccessfully(decimal amount, string cardNumber)
    {
        // Arrange
        var processor = _factory.CreateProcessor();

        // Act
        var result = processor.ProcessTransaction(amount, cardNumber);

        // Assert
        result.Should().StartWith("MP-");
        result.Should().HaveLength(11);
    }

    [Fact]
    public void Log_ShouldLogMessageSuccessfully()
    {
        // Arrange
        var logger = _factory.CreateLogger();
        var message = "Transaction completed";

        // Act & Assert (Log retorna void)
        var act = () => logger.Log(message);
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("5234567890123456")]
    [InlineData("5876543210987654")]
    [InlineData("5444555566667777")]
    public void ValidateCard_ShouldValidateCardSuccessfully(string cardNumber)
    {
        // Arrange
        var validator = _factory.CreateValidator();

        // Act
        var result = validator.ValidateCard(cardNumber);

        // Assert
        result.Should().BeTrue();
    }
}
