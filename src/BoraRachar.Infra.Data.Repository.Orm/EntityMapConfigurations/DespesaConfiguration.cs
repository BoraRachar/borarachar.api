using BoraRachar.Domain.Entity.Despesas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class DespesaConfiguration: IEntityTypeConfiguration<Despesa>
{

    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.ToTable("Despesas");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdDespesa")
            .IsRequired();
        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();
        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        builder.Property(x => x.DataRealizacao)
            .HasColumnName("DataRealizacao")
            .IsRequired();
        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();
        builder.Property(x => x.ValorDespesa)
            .HasColumnName("ValorDespesa")
            .IsRequired();
        builder.Property(x => x.GrupoId)
            .HasColumnName("GrupoId")
            .IsRequired();
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}