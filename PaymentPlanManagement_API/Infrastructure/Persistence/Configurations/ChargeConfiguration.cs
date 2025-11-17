using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Infrastructure.Persistence.Configurations;

public class ChargeConfiguration : IEntityTypeConfiguration<Charge>
{
    public void Configure(EntityTypeBuilder<Charge> builder)
    {
        builder.ToTable("Charges");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PaymentPlans_Id)
            .HasColumnName("PaymentPlans_Id");

        builder.HasOne(c => c.PaymentPlan)
            .WithMany(p => p.Charges)
            .HasForeignKey(c => c.PaymentPlans_Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(c => c.Value)
            .HasColumnName("Value");

        builder.Property(c => c.DueDate)
            .HasColumnName("DueDate");

        builder.Property(c => c.PaymentMethod)
            .HasColumnName("PaymentMethod");

        builder.Property(c => c.Status)
            .HasColumnName("Status");

        builder.Property(c => c.PaymentCode)
            .HasColumnName("PaymentCode");

        builder.Property(c => c.created_at)
            .HasColumnName("created_at");
    }
}
