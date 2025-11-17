using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Infrastructure.Persistence.Configurations;

public class CostsCentralConfiguration : IEntityTypeConfiguration<CostsCentral>
{
    public void Configure(EntityTypeBuilder<CostsCentral> builder)
    {
        builder.ToTable("CostsCentral");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(200);
        builder.Property(c => c.Code)
        .HasMaxLength(100);
        builder.HasIndex(c => c.Code);
    }
}
