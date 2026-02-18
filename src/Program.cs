using DesignPatternChallenge.Factories.Enums;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            var pagSeguroService = new PaymentService(GatewayTypes.PagSeguro);
            pagSeguroService.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var mercadoPagoService = new PaymentService(GatewayTypes.MercadoPago); 
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();

        }
    }
}
