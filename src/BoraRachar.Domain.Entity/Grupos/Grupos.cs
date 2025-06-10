using System.ComponentModel.DataAnnotations.Schema;
using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Entity.Enum;

namespace BoraRachar.Domain.Entity.Grupos;

public class Grupos : BaseEntity
{

    public Grupos()
    {
        
    }
    public Grupos(
        string userAdm,
        string nome, 
        string idCategoria, 
        string descricao, 
        int tipoDivisao,
        string? outrasCategorias,
        string imgGrupo
    )
    {
        Id = Guid.NewGuid().ToString().ToLower();
        UserAdm = userAdm;
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

    public string Nome { get; set; }
    [ForeignKey("Categorias")]
    public string IdCategoria { get; set; }
    public string? Descricao { get; set; }
    public string? ImgGrupo { get; set; }
    public int TipoDivisao { get; set; }
    public bool Deleted { get; set; }
    public bool Ativo { get; set; }
    public string? LinkConvite { get; set; }
    public string UserAdm { get; set; }
    public string? OutrasCategorias { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public string[]? Participantes { get; set; }
}