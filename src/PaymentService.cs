using DesignPatternChallenge.Factories;
using DesignPatternChallenge.Factories.Enums;
using DesignPatternChallenge.Factories.Interfaces;

namespace DesignPatternChallenge;

public class PaymentService
{
    private readonly IPaymentGatewayFactory _factory;

    public PaymentService(GatewayTypes gateway) => _factory = PaymentGatewayFactoryProvider.GetFactory(gateway) ?? throw new ArgumentException($"Gateway '{gateway}' não é suportado", nameof(gateway));

    public bool ProcessPayment(decimal amount, string cardNumber)
    {
        ArgumentException.ThrowIfNullOrEmpty(cardNumber, nameof(cardNumber));
        ArgumentOutOfRangeException.ThrowIfLessThan(cardNumber.Length, 16, nameof(cardNumber));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(amount, 0, nameof(amount));

        try
        {
            var validator = _factory.CreateValidator();
            var processor = _factory.CreateProcessor();
            var logger = _factory.CreateLogger();

            if (!validator.ValidateCard(cardNumber))
            {
                throw new ArgumentException($"Validação falhou para o cartão terminado em {cardNumber.Substring(cardNumber.Length - 4)}");
            }

            string transactionId = processor.ProcessTransaction(amount, cardNumber);

            logger.Log($"Transação {transactionId} processada com sucesso - Valor: R$ {amount:N2}");

            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] [PaymentService] Erro ao processar pagamento com gateway {_factory.GetType().Name}: {ex.Message}");
            return false;
        }


    }
}
