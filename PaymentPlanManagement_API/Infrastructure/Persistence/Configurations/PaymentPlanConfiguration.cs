using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Infrastructure.Persistence.Configurations;

public class PaymentPlanConfiguration : IEntityTypeConfiguration<PaymentPlan>
{
    public void Configure(EntityTypeBuilder<PaymentPlan> builder)
    {
        builder.ToTable("PaymentPlans");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Client_Id)
            .HasColumnName("Client_Id");

        builder.HasOne(p => p.Client)
            .WithMany()
            .HasForeignKey(p => p.Client_Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CostsCentral_Id)
            .HasColumnName("CostsCentral_Id");

        builder.HasOne(p => p.CostsCentral)
            .WithMany()
            .HasForeignKey(p => p.CostsCentral_Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.CostsCentral_enum)
            .HasColumnName("CostsCentral_enum");

        builder.Property(p => p.created_at)
            .HasColumnName("created_at");

        builder.HasMany(p => p.Charges)
            .WithOne(c => c.PaymentPlan)
            .HasForeignKey(c => c.PaymentPlans_Id);
    }
}
