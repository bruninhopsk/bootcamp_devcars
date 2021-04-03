using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevCars.Infrastructure.EntityFramework.Context
{
    public class DevCarsDbContextFactory : IDesignTimeDbContextFactory<DevCarsDbContext>
    {
        public DevCarsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DevCarsDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=DevCars;Trusted_Connection=True");

            return new DevCarsDbContext(optionsBuilder.Options);
        }
    }
}