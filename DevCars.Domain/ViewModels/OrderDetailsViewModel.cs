using System.Collections.Generic;

namespace DevCars.Domain.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public List<string> ExtraItems { get; set; }
        public decimal TotalCost { get; set; }

        public OrderDetailsViewModel(int customerId, int carId, List<string> extraItems, decimal totalCost)
        {
            CustomerId = customerId;
            CarId = carId;
            ExtraItems = extraItems;
            TotalCost = totalCost;
        }
    }
}