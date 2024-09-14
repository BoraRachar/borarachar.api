using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;

public class AddCategoriaRequestDto: RequestDto
{
    public string Nome { get; set; }                
    public string Descricao { get; set; }
    public string IdCategoria { get; set; }
    public int TipoDivisao { get; set; }
    public string? OutrasCategorias { get; set; }
    public string? ImgGrupo { get; set; }   
    public List<string>? Participantes { get; set; } 
}