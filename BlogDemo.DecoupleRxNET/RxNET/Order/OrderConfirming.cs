using BlogDemo.DecoupleRxNET.Enums;

namespace BlogDemo.DecoupleRxNET.RxNET.Order
{
    public class OrderConfirming
    {
        public IList<Product> Products { get; set; }

        public class Product
        {
            public Guid Id { get; set; }

            public int Quantity { get; set; }

            public decimal UnitPrice { get; set; }

            public PaymentMethod PaymentMethod { get; set; }
        }
    }
}
