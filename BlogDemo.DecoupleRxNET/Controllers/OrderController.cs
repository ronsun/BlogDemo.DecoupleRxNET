using BlogDemo.DecoupleRxNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecoupleRxNET.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrderController(IOrderService orderService)
        : ControllerBase
    {
        [HttpGet]
        public IActionResult Confirm()
        {
            orderService.Confirm(Guid.NewGuid());
            return Ok();
        }
    }
}
