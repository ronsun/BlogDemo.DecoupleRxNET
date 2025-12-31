namespace BlogDemo.DecoupleRxNET.Services
{
    public class StockService(ILogger<StockService> logger)
        : IStockService
    {
        public void Ship(Guid productId, int quantity)
        {
            logger.LogInformation($"Ship {quantity} of product {productId}");
        }
    }
}
