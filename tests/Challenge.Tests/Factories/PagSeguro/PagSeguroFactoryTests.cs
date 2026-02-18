using DesignPatternChallenge.Factories;
using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;
using FluentAssertions;
using Xunit;

namespace Challenge.Tests.Factories.PagSeguro;

public class PagSeguroFactoryTests
{
    private readonly IPaymentGatewayFactory _factory;

    public PagSeguroFactoryTests()
    {
        _factory = PaymentGatewayFactoryProvider.GetFactory(GatewayTypes.PagSeguro);
    }

    [Fact]
    public void CreateProcessor_ShouldReturnPagSeguroProcessor()
    {
        // Act
        var processor = _factory.CreateProcessor();

        // Assert
        processor.Should().NotBeNull();
        processor.Should().BeAssignableTo<IPaymentProcessor>();
    }

    [Fact]
    public void CreateValidator_ShouldReturnPagSeguroValidator()
    {
        // Act
        var validator = _factory.CreateValidator();

        // Assert
        validator.Should().NotBeNull();
        validator.Should().BeAssignableTo<IPaymentValidator>();
    }

    [Fact]
    public void CreateLogger_ShouldReturnPagSeguroLogger()
    {
        // Act
        var logger = _factory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
        logger.Should().BeAssignableTo<IPaymentLogger>();
    }

    [Theory]
    [InlineData(50.00, "1234567890123456")]
    [InlineData(1.99, "9876543210987654")]
    [InlineData(5000.00, "1111222233334444")]
    public void ProcessTransaction_ShouldProcessPaymentSuccessfully(decimal amount, string cardNumber)
    {
        // Arrange
        var processor = _factory.CreateProcessor();

        // Act
        var result = processor.ProcessTransaction(amount, cardNumber);

        // Assert
        result.Should().StartWith("PAGSEG-");
        result.Should().HaveLength(15);
    }

    [Fact]
    public void Log_ShouldLogMessageSuccessfully()
    {
        // Arrange
        var logger = _factory.CreateLogger();
        var message = "Payment confirmation received";

        // Act & Assert (Log retorna void)
        var act = () => logger.Log(message);
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData("1234567890123456")]
    [InlineData("9876543210987654")]
    [InlineData("5555666677778888")]
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
