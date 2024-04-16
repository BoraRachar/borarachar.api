using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.UpdateUser;

public class UpdateUserRequestDto : RequestDto
{
	public string Email { get; set; }
	public string Nome { get; set; }
	public string Celular { get; set; }
}
