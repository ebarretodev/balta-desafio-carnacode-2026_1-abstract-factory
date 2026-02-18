![CR-1](https://github.com/user-attachments/assets/5b3f4530-df7d-4f27-abe2-4a9259ddf62a)

## 🥁 CarnaCode 2026 - Desafio 01 - Abstract Factory

## Problema
Uma plataforma de e-commerce precisa integrar com múltiplos gateways de pagamento (PagSeguro, MercadoPago, Stripe) e cada gateway tem componentes específicos (Processador, Validador, Logger).
O código atual está muito acoplado e dificulta a adição de novos gateways.

## Perguntas para reflexão:
 - Como adicionar um novo gateway sem modificar PaymentService?  
Criado GatewayProvider para fornecer o Gateway necessário.

 - Como garantir que todos os componentes de um gateway sejam compatíveis entre si?
 Uso de Abstract Factory e interfaces implementando.

 - Como evitar criar componentes de gateways diferentes acidentalmente? 
 Uso de Enum para identificar o gateway

### Veja meu progresso no desafio
[Incluir link para o repositório central]
