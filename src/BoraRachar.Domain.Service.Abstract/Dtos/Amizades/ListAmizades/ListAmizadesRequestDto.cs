using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;

public class ListAmizadesRequestDto: RequestPaginatedDto
{
    public string UserCod { get; set; }
}