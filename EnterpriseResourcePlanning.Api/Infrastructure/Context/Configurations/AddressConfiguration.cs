using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Infrastructure.ConvertTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseResourcePlanning.Api.Infrastructure.Context.Settings;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        // Definindo a tabela
        builder.ToTable("Addresses");

        // Definindo a chave primária
        builder.HasKey(a => a.AddressId);
        
        builder.Property(a => a.AddressId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());

        // Definindo as propriedades
        builder.Property(a => a.Cep)
            .IsRequired() // Campo obrigatório
            .HasMaxLength(20); // Tamanho máximo

        builder.Property(a => a.PublicPlace)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.Complement)
            .HasMaxLength(255); // Opcional, pode ser nulo

        builder.Property(a => a.Neighborhood)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.NumberAddress)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Telephone)
            .HasMaxLength(15); // Opcional, pode ser nulo
    }
}