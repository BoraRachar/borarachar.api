using BoraRachar.Domain.Entity.Grupos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class ParticipantesGrupoConfiguration: IEntityTypeConfiguration<ParticipantesGrupo>
{
    public void Configure(EntityTypeBuilder<ParticipantesGrupo> builder)
    {
        builder.ToTable("ParticipantesGrupo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ParticipanteGrupoId")
            .IsRequired();
        
        builder.Property(x => x.GrupoId)
            .HasColumnName("GrupoId")
            .IsRequired();
        
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();
        
        builder.Property(x => x.IsAdm)
            .HasColumnName("IsAdm");
        
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
    }
}