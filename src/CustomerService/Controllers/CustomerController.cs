using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly Customer[] Customers = new[]
        {
            new Customer { Id = 1,Name = "Customer1"},
            new Customer { Id = 2,Name = "Customer2"},
            new Customer { Id = 3,Name = "Customer3"},
            new Customer { Id = 4,Name = "Customer4"},
        };

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{customerId}")]
        public ActionResult<Customer> Get(int customerId)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == customerId);
            return Ok(customer);
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
