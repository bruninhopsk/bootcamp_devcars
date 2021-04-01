using System;

namespace DevCars.Domain.ViewModels
{
    public class CarDetailsViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VinCode { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public DateTime ProductionDate { get; set; }

        public CarDetailsViewModel(int carId, string brand, string model, string vinCode, int year, decimal price, string color, DateTime productionDate)
        {
            CarId = carId;
            Brand = brand;
            Model = model;
            VinCode = vinCode;
            Year = year;
            Price = price;
            Color = color;
            ProductionDate = productionDate;
        }
    }
}