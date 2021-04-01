using System;

namespace DevCars.Domain.InputModels
{
    public class AddCustomerInputModel
    {
        public string FullName { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Age { get; set; }
    }
}