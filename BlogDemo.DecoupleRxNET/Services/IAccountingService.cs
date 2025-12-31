using BlogDemo.DecoupleRxNET.Enums;

namespace BlogDemo.DecoupleRxNET.Services
{
    public interface IAccountingService
    {
        void Credit(decimal amount, PaymentMethod paymentMethod);
    }
}
