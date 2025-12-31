using BlogDemo.DecoupleRxNET.Enums;

namespace BlogDemo.DecoupleRxNET.Services
{
    public class OrderService(
        ILogger<OrderService> logger,
        IStockService stockService,
        IAccountingService accountingService)
        : IOrderService
    {
        public void Confirm(Guid orderId)
        {
            logger.LogInformation($"Order confirming: {orderId}");

            stockService.Ship(Guid.NewGuid(), 10);

            accountingService.Credit(100m, PaymentMethod.CreditCard);

            logger.LogInformation($"Order confirming: {orderId}, doing something else.");

            logger.LogInformation($"Order confirmed: {orderId}");
        }
    }
}
