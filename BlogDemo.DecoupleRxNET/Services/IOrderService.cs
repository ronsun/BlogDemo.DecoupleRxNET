namespace BlogDemo.DecoupleRxNET.Services
{
    public interface IOrderService
    {
        void Confirm(Guid orderId);
    }
}
