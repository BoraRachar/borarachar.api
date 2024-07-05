using BoraRachar.Domain.Entity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class VerifyUserConfiguration : IEntityTypeConfiguration<VerifyUser>
{
    public void Configure(EntityTypeBuilder<VerifyUser> builder)
    {
        builder.ToTable("VerifyUsers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdVerifyUser")
            .IsRequired();
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("Code")
            .IsRequired();

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
    }
}