using System.Collections.Generic;
using System.Linq;

namespace DevCars.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int CarId { get; private set; }
        public int CustomerId { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<ExtraOrderItem> ExtraItems { get; private set; }

        public Order(int id, int carId, int customerId, decimal price, List<ExtraOrderItem> items)
        {
            Id = id;
            CarId = carId;
            CustomerId = customerId;
            TotalCost = items.Sum(i => i.Price) + price;
            ExtraItems = items;
        }
    }
}