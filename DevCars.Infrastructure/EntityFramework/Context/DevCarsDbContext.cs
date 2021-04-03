using System.Reflection;
using DevCars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevCars.Infrastructure.EntityFramework.Context
{
    public class DevCarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DevCarsDbContext() { }

        public DevCarsDbContext(DbContextOptions<DevCarsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}