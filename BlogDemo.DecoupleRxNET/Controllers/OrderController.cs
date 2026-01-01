using BlogDemo.DecoupleRxNET.RxNET.Order;
using BlogDemo.DecoupleRxNET.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reactive.Subjects;

namespace DecoupleRxNET.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrderController(
        IOrderService orderService,
        IStockService stockService,
        IAccountingService accountingService)
        : ControllerBase
    {
        [HttpGet]
        public IActionResult Confirm()
        {
            var subject = new Subject<OrderConfirming>();

            // Stock
            subject.Subscribe(topic =>
            {
                foreach (var product in topic.Products)
                {
                    stockService.Ship(product.Id, product.Quantity);
                }
            });

            // Accounting
            subject.Subscribe(topic =>
            {
                foreach (var product in topic.Products)
                {
                    var amount = product.UnitPrice * product.Quantity;
                    accountingService.Credit(amount, product.PaymentMethod);
                }
            });

            orderService.Confirm(Guid.NewGuid(), subject);
            return Ok();
        }
    }
}
