using BoraRachar.Domain.Entity.Amizades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class AmizadeConfiguration: IEntityTypeConfiguration<Amizade>
{
    public void Configure(EntityTypeBuilder<Amizade> builder)
    {
        builder.ToTable("Amizades");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdAmizade")
            .IsRequired();
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();
        
        builder.Property(x => x.AmigoId)
            .HasColumnName("AmigoId")
            .IsRequired();

        builder.Property(x => x.Approved)
            .HasColumnName("Approved");
        
        builder.Property(x => x.Convidado)
            .HasColumnName("Convidado");
           
        builder.Property(x => x.ConvidadoEmail)
            .HasColumnName("ConvidadoEmail");
           
        builder.Property(x => x.DataSolicitacao)
            .HasColumnName("DataSolicitacao")
            .IsRequired();
        
        builder.Property(x => x.DataAprovacao)
            .HasColumnName("DataAprovacao");
    }
}