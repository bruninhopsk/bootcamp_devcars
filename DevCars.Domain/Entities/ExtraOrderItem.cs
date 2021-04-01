namespace DevCars.Domain.Entities
{
    public class ExtraOrderItem
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal OrderId { get; private set; }

        public ExtraOrderItem(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}