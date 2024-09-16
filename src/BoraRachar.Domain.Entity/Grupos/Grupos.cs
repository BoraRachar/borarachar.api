using System.ComponentModel.DataAnnotations.Schema;
using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Entity.Enum;

namespace BoraRachar.Domain.Entity.Grupos;

public class Grupos : BaseEntity
{
    public Grupos(
        string nome, 
        string idCategoria, 
        string descricao, 
        int tipoDivisao,
        string? outrasCategorias,
        string imgGrupo
    )
    {
        Id = Guid.NewGuid().ToString().ToLower();
    Nome = nome;
        IdCategoria = idCategoria;
        Descricao = descricao;
        Deleted = false;
        Ativo = true;
        TipoDivisao = tipoDivisao;
        OutrasCategorias = outrasCategorias;
        ImgGrupo = imgGrupo;
        DataCadastro = DateTime.UtcNow;
        DataAtualizacao = DateTime.UtcNow;
    }

    public string Nome { get; private set; }
    [ForeignKey("Categorias")]
    public string IdCategoria { get; private set; }
    public string Descricao { get; private set; }
    public string ImgGrupo { get; private set; }
    public int TipoDivisao { get; set; }
    public bool Deleted { get; private set; }
    public bool Ativo { get; private set; }
    public string? LinkConvite { get; private set; }
    public string UserAdm { get; private set; }
    public string? OutrasCategorias { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }
}