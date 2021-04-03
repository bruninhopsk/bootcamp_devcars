using DevCars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevCars.Infrastructure.EntityFramework.Mappings
{
    public class ExtraOrderItemMapping : IEntityTypeConfiguration<ExtraOrderItem>
    {
        public void Configure(EntityTypeBuilder<ExtraOrderItem> builder)
        {
            builder.ToTable("ExtraOrderItems");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).HasMaxLength(100);

            builder.Property(e => e.Price);
        }
    }
}