using DesignPatternChallenge.Factories;
using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;
using FluentAssertions;
using Xunit;

namespace Challenge.Tests.Factories.Stripe;

public class StripeFactoryTests
{
    private readonly IPaymentGatewayFactory _factory;

    public StripeFactoryTests()
    {
        _factory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.Stripe);
    }

    [Fact]
    public void CreateProcessor_ShouldReturnStripeProcessor()
    {
        // Act
        var processor = _factory.CreateProcessor();

        // Assert
        processor.Should().NotBeNull();
        processor.Should().BeAssignableTo<IPaymentProcessor>();
    }

    [Fact]
    public void CreateValidator_ShouldReturnStripeValidator()
    {
        // Act
        var validator = _factory.CreateValidator();

        // Assert
        validator.Should().NotBeNull();
        validator.Should().BeAssignableTo<IPaymentValidator>();
    }

    [Fact]
    public void CreateLogger_ShouldReturnStripeLogger()
    {
        // Act
        var logger = _factory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
        logger.Should().BeAssignableTo<IPaymentLogger>();
    }

    [Theory]
    [InlineData(100.50, "1234567890123456")]
    [InlineData(0.01, "9876543210987654")]
    [InlineData(9999.99, "1111222233334444")]
    public void ProcessTransaction_ShouldProcessPaymentSuccessfully(decimal amount, string cardNumber)
    {
        // Arrange
        var processor = _factory.CreateProcessor();

        // Act
        var result = processor.ProcessTransaction(amount, cardNumber);

        // Assert
        result.Should().StartWith("STRIPE-");
        result.Should().HaveLength(15);
    }

    [Fact]
    public void Log_ShouldLogMessageSuccessfully()
    {
        // Arrange
        var logger = _factory.CreateLogger();
        var message = "Test payment processed";

        // Act & Assert (Log retorna void)
        var act = () => logger.Log(message);
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("1234567890123456", false)]
    [InlineData("4876543210987654", true)]
    [InlineData("5111222233334444", false)]
    public void ValidateCard_ShouldValidateCardSuccessfully(string cardNumber, bool expectedResult)
    {
        // Arrange
        var validator = _factory.CreateValidator();

        // Act
        var result = validator.ValidateCard(cardNumber);

        // Assert
        result.Should().Be(expectedResult);
    }
}
