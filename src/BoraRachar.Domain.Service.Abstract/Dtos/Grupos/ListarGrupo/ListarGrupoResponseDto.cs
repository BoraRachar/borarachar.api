using System;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListarGrupo;

public class ListarGrupoResponseDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string IdCategoria { get; set; }
    public int TipoDivisao { get; set; }
    public string? OutrasCategorias { get; set; }
    public string? ImgGrupo { get; set; }
    public List<string>? Participantes { get; set; }
}
