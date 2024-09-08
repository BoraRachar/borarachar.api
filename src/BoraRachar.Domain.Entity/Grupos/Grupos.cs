using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Entity.Enum;

namespace BoraRachar.Domain.Entity.Grupos;

public class Grupos : BaseEntity
{
    public Grupos(
        string idCategoria, 
        string descricao, 
        TipoDivisao tipoDivisao,
        string? outrasCategorias
    )
    {
        Id = Guid.NewGuid().ToString().ToLower();
        IdCategoria = idCategoria;
        Descricao = descricao;
        Deleted = false;
        Ativo = true;
        TipoDivisao = tipoDivisao;
        OutrasCategorias = outrasCategorias;
        DataCadastro = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    public string IdCategoria { get; private set; }
    public string Descricao { get; private set; }
    public TipoDivisao TipoDivisao { get; set; }
    public bool Deleted { get; private set; }
    public bool Ativo { get; private set; }
    public string? LinkConvite { get; private set; }
    public string UserAdm { get; private set; }
    public string? OutrasCategorias { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }
}