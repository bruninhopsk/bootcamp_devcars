using System;
using System.Collections.Generic;
using DevCars.Domain.Entities;

namespace DevCars.Infrastructure
{
    public class DevCarsDbContext
    {
        public List<Car> Cars { get; set; }
        public List<Customer> Customers { get; set; }

        public DevCarsDbContext()
        {
            Cars = new List<Car>()
            {
                new Car(1, "123abc", "Ford", "FordFiesta", 2021, 42000, "Gray", new DateTime(2021, 1, 1)),
                new Car(2, "456abc", "GM", "Onix", 2015, 32000, "Red", new DateTime(2015, 1, 1)),
                new Car(3, "789abc", "Honda", "Fit", 2019, 38122, "Yellow", new DateTime(2019, 1, 1)),
            };
            Customers = new List<Customer>()
            {
                new Customer(4, "Marcos Bruno", "123abd74897", new DateTime(1996,1,1)),
                new Customer(5, "Jade Machado", "54d65s4", new DateTime(1996,10,2)),
                new Customer(6, "Elis Oliveira", "7r8e7r56edf4e", new DateTime(1973,1,1)),
            };
        }
    }
}