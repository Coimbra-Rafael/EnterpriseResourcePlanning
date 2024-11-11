using EnterpriseResourcePlanning.Api.Domain.Entities;
using EnterpriseResourcePlanning.Api.Infrastructure.ConvertTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseResourcePlanning.Api.Infrastructure.Context.Settings;

public class UserEnterpriseConfiguration : IEntityTypeConfiguration<UserEnterprise>
{

    public void Configure(EntityTypeBuilder<UserEnterprise> builder)
    {
        builder.ToTable("user_enterprises");
        
        builder.HasKey(ue => new { ue.UsuarioId, ue.EnterpriseId });

        builder.Property(ue => ue.UsuarioId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());

        builder.Property(ue => ue.EnterpriseId)
            .IsRequired()
            .HasConversion(new CustomizedGuidConvert());;
        
        builder.HasOne(ue => ue.User)
            .WithMany(u => u.UsersEnterprises)
            .HasForeignKey(ue => ue.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(ue => ue.Enterprise)
            .WithMany()
            .HasForeignKey(ue => ue.EnterpriseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}