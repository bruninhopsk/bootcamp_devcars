namespace DevCars.Domain.ViewModels
{
    public class CarItemViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public CarItemViewModel(int carId, string brand, string model, decimal price)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            Price = price;
        }
    }
}