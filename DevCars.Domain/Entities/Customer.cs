using System;
using System.Collections.Generic;

namespace DevCars.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<Order> Orders { get; private set; }

        protected Customer() { }

        public Customer(string fullName, string document, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;
            Orders = new List<Order>();
        }
    }
}