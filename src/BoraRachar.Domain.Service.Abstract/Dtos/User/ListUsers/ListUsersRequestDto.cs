using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;
public class ListUsersRequestDto : RequestPaginatedDto
{
    public string Infuencer { get; set; }
    public string Email { get; set; }
    public string CodigoInfluencer { get; set; }
}