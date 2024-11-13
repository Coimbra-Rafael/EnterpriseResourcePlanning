using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Infrastructure.ConvertTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseResourcePlanning.Api.Infrastructure.Context.Settings;

public class UserSetting : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
         
        builder.Property(u => u.UserId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());
        
        builder.Property(u => u.CustomerId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());
        
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100); // Ajuste conforme necessário

        builder.HasMany(u => u.UsersEnterprises)
            .WithOne(ue => ue.User)
            .HasForeignKey(ue => ue.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}