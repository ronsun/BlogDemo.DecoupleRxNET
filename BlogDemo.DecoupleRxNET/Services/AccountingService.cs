using BlogDemo.DecoupleRxNET.Enums;

namespace BlogDemo.DecoupleRxNET.Services
{
    public class AccountingService(ILogger<AccountingService> logger)
        : IAccountingService
    {
        public void Credit(decimal amount, PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.CashOnDelivery:
                    logger.LogInformation("No accouting required.");
                    break;
                case PaymentMethod.CreditCard:
                    logger.LogInformation($"Credit {amount}");
                    break;
                default:
                    logger.LogWarning("Unknown payment method.");
                    break;
            }
        }
    }
}
