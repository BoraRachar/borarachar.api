using BoraRachar.Domain.Entity.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class ParticipanteDepesaConfiguration: IEntityTypeConfiguration<ParticipanteDepesa>
{
    public void Configure(EntityTypeBuilder<ParticipanteDepesa> builder)
    {
        builder.ToTable("ParticipantesDepesa");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdParticipantesDepesa")
            .IsRequired();

        builder.Property(x => x.IdDespesa)
            .HasColumnName("IdDespesa")
            .IsRequired();
        builder.Property(x => x.IdGrupo)
            .HasColumnName("IdGrupo")
            .IsRequired();
        builder.Property(x => x.IdParticipantesGrupo)
            .HasColumnName("IdParticipantesGrupo")
            .IsRequired();
        builder.Property(x => x.IsPagador)
            .HasColumnName("IsPagador")
            .IsRequired();
        builder.Property(x => x.IsRecebedor)
            .HasColumnName("IsRecebedor")
            .IsRequired();
    }
}