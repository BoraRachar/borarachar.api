using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.UpdateGrupo;

public class UpdateGrupoRequestDto: RequestDto
{
    public string GrupoId { get; set; }
    public string UserCod { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string IdCategoria { get; set; }
    public int TipoDivisao { get; set; }
    public string? OutrasCategorias { get; set; }
    public string? ImgGrupo { get; set; }
}