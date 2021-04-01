using System.Collections.Generic;

namespace DevCars.Domain.InputModels
{
    public class AddOrderInputModel
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public List<ExtraItemInputModel> ExtraItems { get; set; }
    }
}