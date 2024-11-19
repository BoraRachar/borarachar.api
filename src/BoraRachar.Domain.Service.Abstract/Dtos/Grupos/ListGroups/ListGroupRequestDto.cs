using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;

public class ListGroupRequestDto: RequestPaginatedDto
{
    public string UserCod { get; set; }
}