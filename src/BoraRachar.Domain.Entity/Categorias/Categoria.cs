using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Categorias;

public class Categoria : BaseEntity
{
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}