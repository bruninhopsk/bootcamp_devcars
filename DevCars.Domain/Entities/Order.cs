using System.Collections.Generic;
using System.Linq;

namespace DevCars.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<ExtraOrderItem> ExtraItems { get; private set; }
        public int CarId { get; private set; }
        public Car Car { get; private set; }
        public int CustomerId { get; private set; }
        public Customer Customer { get; private set; }

        protected Order() { }

        public Order(int carId, int customerId, decimal price, List<ExtraOrderItem> items)
        {
            CarId = carId;
            CustomerId = customerId;
            TotalCost = items.Sum(i => i.Price) + price;
            ExtraItems = items;
        }
    }
}