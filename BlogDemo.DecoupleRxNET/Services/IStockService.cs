namespace BlogDemo.DecoupleRxNET.Services
{
    public interface IStockService
    {
        void Ship(Guid productId, int quantity);
    }
}
