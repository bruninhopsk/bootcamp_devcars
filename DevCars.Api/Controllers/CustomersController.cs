using System.Linq;
using DevCars.Domain.Entities;
using DevCars.Domain.InputModels;
using DevCars.Domain.ViewModels;
using DevCars.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DevCars.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        public DevCarsDbContext Context { get; }

        public CustomersController(DevCarsDbContext context)
        {
            Context = context;
        }

        //POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] AddCustomerInputModel customerInputModel)
        {
            var customer = new Customer(
                1,
                customerInputModel.FullName,
                customerInputModel.Document,
                customerInputModel.BirthDate
            );

            Context.Customers.Add(customer);

            return Ok();
        }

        //POST api/customers/id/order
        [HttpPost("{id}/orders")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel orderInputModel)
        {
            var extraItems = orderInputModel.ExtraItems
                            .Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();

            var car = Context.Cars.SingleOrDefault(x => x.Id.Equals(orderInputModel.CarId));

            var order = new Order(1, orderInputModel.CarId, orderInputModel.CustomerId, car.Price, extraItems);

            var customer = Context.Customers.SingleOrDefault(x => x.Id.Equals(orderInputModel.CustomerId));

            customer.Purhase(order);

            return CreatedAtAction(nameof(GetOrder), new { id = customer.Id, orderId = order.Id }, orderInputModel);
        }

        //GET api/customers/id/orders
        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            var customer = Context.Customers.SingleOrDefault(x => x.Id.Equals(id));

            if (customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.SingleOrDefault(x => x.Id.Equals(orderId));

            var extraItems = order
                .ExtraItems
                .Select(x => x.Description)
                 .ToList();

            var orderViewModel = new OrderDetailsViewModel(order.CustomerId, order.CarId, extraItems, order.TotalCost);

            return Ok(orderViewModel);
        }
    }
}