using BlogDemo.DecoupleRxNET.RxNET.Order;
using BlogDemo.DecoupleRxNET.Services;

namespace DecoupleRxNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<IAccountingService, AccountingService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
