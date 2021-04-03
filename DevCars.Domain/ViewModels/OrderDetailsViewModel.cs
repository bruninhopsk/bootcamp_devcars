using System.Collections.Generic;
using DevCars.Domain.Entities;

namespace DevCars.Domain.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public List<ExtraOrderItem> ExtraItems { get; set; }
        public decimal TotalCost { get; set; }

        public OrderDetailsViewModel(int customerId, int carId, List<ExtraOrderItem> extraItems, decimal totalCost)
        {
            CustomerId = customerId;
            CarId = carId;
            ExtraItems = extraItems;
            TotalCost = totalCost;
        }
    }
}