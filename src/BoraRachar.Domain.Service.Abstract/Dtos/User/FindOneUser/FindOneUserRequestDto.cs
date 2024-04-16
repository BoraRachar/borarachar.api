using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;

public class FindOneUserRequestDto : RequestDto
{
	public string Id { get; set; }
}