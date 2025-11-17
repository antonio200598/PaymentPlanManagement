using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Infrastructure.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(c => c.PaymentPlans)
            .WithOne(pp => pp.Client)
            .HasForeignKey(pp => pp.Client_Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
