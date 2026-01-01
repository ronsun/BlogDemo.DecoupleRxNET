using BlogDemo.DecoupleRxNET.RxNET.Order;

namespace BlogDemo.DecoupleRxNET.Services
{
    public interface IOrderService
    {
        void Confirm(Guid orderId, IObserver<OrderConfirming> observer);
    }
}
