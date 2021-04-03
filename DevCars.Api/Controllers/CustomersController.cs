using System.Linq;
using DevCars.Domain.Entities;
using DevCars.Domain.InputModels;
using DevCars.Domain.ViewModels;
using DevCars.Infrastructure.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                customerInputModel.FullName,
                customerInputModel.Document,
                customerInputModel.BirthDate
            );

            Context.Customers.Add(customer);
            Context.SaveChanges();

            return Ok(customer);
        }

        //POST api/customers/id/order
        [HttpPost("{id}/orders")]
        public IActionResult PostOrder(int id, [FromBody] AddOrderInputModel orderInputModel)
        {
            var extraItems = orderInputModel.ExtraItems
                            .Select(e => new ExtraOrderItem(e.Description, e.Price)).ToList();

            var car = Context.Cars.SingleOrDefault(x => x.Id.Equals(orderInputModel.CarId));

            var order = new Order(orderInputModel.CarId, orderInputModel.CustomerId, car.Price, extraItems);

            Context.Orders.Add(order);
            Context.SaveChanges();

            return CreatedAtAction(nameof(GetOrder), new { id = order.CustomerId, orderId = order.Id }, orderInputModel);
        }

        //GET api/customers/id/orders/orderId
        [HttpGet("{id}/orders/{orderId}")]
        public IActionResult GetOrder(int id, int orderId)
        {
            var order = Context.Orders.Include(o => o.ExtraItems).SingleOrDefault(x => x.Id.Equals(orderId) && x.CustomerId.Equals(id));

            if (order == null)
            {
                return NotFound();
            }

            var orderViewModel = new OrderDetailsViewModel(order.CustomerId, order.CarId, order.ExtraItems, order.TotalCost);

            return Ok(orderViewModel);
        }
    }
}