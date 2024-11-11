using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Infrastructure.ConvertTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseResourcePlanning.Api.Infrastructure.Context.Settings;

public class EnterpriseConfiguration : IEntityTypeConfiguration<Enterprise>
{
    public void Configure(EntityTypeBuilder<Enterprise> builder)
    {
        builder.HasKey(e => e.EnterpriseId);
        
        builder.Property(e => e.EnterpriseId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());
        
        builder.Property(e => e.CustomerId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());
        
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CnpjCpf)
            .IsRequired()
            .HasMaxLength(14); // Ajuste conforme necessário

        builder.Property(e => e.StateRegistration)
            .IsRequired()
            .HasMaxLength(20); // Ajuste conforme necessário

        builder.HasOne(e => e.Customer)
            .WithMany() // Ajuste se necessário
            .HasForeignKey(e => e.CustomerId);
        
        builder.Property(e => e.AddressId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());
    }
}