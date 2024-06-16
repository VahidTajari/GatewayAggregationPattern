using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly Order[] Orders = new[]
        {
           new Order { Id = 1,Amount =1000,CustomerId = 1},
           new Order { Id = 2,Amount =2000,CustomerId = 1},
           new Order { Id = 3,Amount =3000,CustomerId = 2},
           new Order { Id = 4,Amount =4000,CustomerId = 3},
        };

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{customerId}")]
        public ActionResult<List<Order>> Get(int customerId)
        {
            var orders = Orders.Where(x => x.CustomerId == customerId).ToList();
            return Ok(orders);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
    }
}
