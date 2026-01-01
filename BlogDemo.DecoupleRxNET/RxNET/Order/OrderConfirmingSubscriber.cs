using BlogDemo.DecoupleRxNET.Services;

namespace BlogDemo.DecoupleRxNET.RxNET.Order
{
    public class OrderConfirmingSubscriber : ObserverBase<OrderConfirming>, IObserver<OrderConfirming>
    {
        public OrderConfirmingSubscriber(
            IStockService stockService,
            IAccountingService accountingService)
        {
            // Stock
            base.ObservableSubject.Subscribe(topic =>
            {
                foreach (var product in topic.Products)
                {
                    stockService.Ship(product.Id, product.Quantity);
                }
            });

            // Accounting
            base.ObservableSubject.Subscribe(topic =>
            {
                foreach (var product in topic.Products)
                {
                    var amount = product.UnitPrice * product.Quantity;
                    accountingService.Credit(amount, product.PaymentMethod);
                }
            });
        }
    }
}
