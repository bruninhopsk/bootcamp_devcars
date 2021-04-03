using DevCars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCars.Infrastructure.EntityFramework.Mappings
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.VinCode).HasMaxLength(100);

            builder.Property(c => c.Brand).HasMaxLength(100);

            builder.Property(c => c.Model).HasMaxLength(100);

            builder.Property(c => c.Year);

            builder.Property(c => c.Price);

            builder.Property(c => c.Color);

            builder.Property(c => c.ProductionDate);

            builder.Property(c => c.RegisteredAt);

            builder.Property(c => c.Status);
        }
    }
}