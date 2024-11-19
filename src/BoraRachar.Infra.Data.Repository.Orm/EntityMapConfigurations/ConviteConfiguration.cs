using BoraRachar.Domain.Entity.Amizades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class ConviteConfiguration: IEntityTypeConfiguration<Convite>
{
    public void Configure(EntityTypeBuilder<Convite> builder)
    {
        builder.ToTable("Convites");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ConviteId")
            .IsRequired();
        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();
        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .IsRequired();
        builder.Property(x => x.CorpoEmail)
            .HasColumnName("CorpoEmail")
            .IsRequired();
        builder.Property(x => x.AmigoId)
            .HasColumnName("AmigoId")
            .IsRequired();
        builder.Property(x => x.DataEnvio)
            .HasColumnName("DataEnvio")
            .IsRequired();
        builder.Property(x => x.DataReenvio)
            .HasColumnName("DataReenvio");
        builder.Property(x => x.Reenvio)
            .HasColumnName("Reenvio");
        builder.Property(x => x.Aceite)
            .HasColumnName("Aceite")
            .IsRequired();
    }
}