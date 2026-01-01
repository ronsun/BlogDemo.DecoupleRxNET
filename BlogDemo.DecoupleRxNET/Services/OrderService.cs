using BlogDemo.DecoupleRxNET.Enums;
using BlogDemo.DecoupleRxNET.RxNET.Order;

namespace BlogDemo.DecoupleRxNET.Services
{
    public class OrderService(
        ILogger<OrderService> logger)
        : IOrderService
    {
        public void Confirm(Guid orderId, IObserver<OrderConfirming> observer)
        {
            logger.LogInformation($"Order confirming: {orderId}");

            var message = new OrderConfirming
            {
                Products = new List<OrderConfirming.Product>
                {
                    new OrderConfirming.Product
                    {
                        Id = Guid.NewGuid(),
                        Quantity = 10,
                        PaymentMethod = PaymentMethod.CreditCard,
                        UnitPrice = 9.99m,
                    },
                    new OrderConfirming.Product
                    {
                        Id = Guid.NewGuid(),
                        Quantity = 5,
                        PaymentMethod = PaymentMethod.CashOnDelivery,
                        UnitPrice = 19.99m,
                    }
                }
            };

            observer.OnNext(message);

            logger.LogInformation($"Order confirming: {orderId}, doing something else.");

            logger.LogInformation($"Order confirmed: {orderId}");
        }
    }
}
