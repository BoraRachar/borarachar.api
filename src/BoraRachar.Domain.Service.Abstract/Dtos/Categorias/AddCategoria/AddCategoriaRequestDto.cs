using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;

public class AddCategoriaRequestDto: RequestDto
{
    public string Descricao { get; set; }
}