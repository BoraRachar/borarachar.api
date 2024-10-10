using BoraRachar.Domain.Entity.Grupos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoraRachar.Infra.Data.Repository.Orm.EntityMapConfigurations;

public class GruposConfiguration : IEntityTypeConfiguration<Grupos>
{
    public void Configure(EntityTypeBuilder<Grupos> builder)
    {
        builder.ToTable("Grupos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdGrupo")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();
        
        builder.Property(x => x.IdCategoria)
            .HasColumnName("IdCategoria")
            .IsRequired();

        builder.Property(x => x.ImgGrupo)
            .HasColumnName("ImgGrupo");
       
        builder.Property(x => x.TipoDivisao)
            .HasColumnName("TipoDivisao")
            .IsRequired();

        builder.Property(x => x.Deleted)
            .HasColumnName("Deleted")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
        
        builder.Ignore(x => x.Participantes);

        builder.Property(x => x.LinkConvite)
            .HasColumnName("LinKConvite");

        builder.Property(x => x.UserAdm)
            .HasColumnName("UserAdm");

        builder.Property(x => x.OutrasCategorias)
            .HasColumnName("OutrasCategorias");

        builder.Property(x => x.DataCadastro)
            .HasColumnName("DataCadastro")
            .IsRequired();

        builder.Property(x => x.DataAtualizacao)
            .HasColumnName("DataAtualizacao");
    }
}