using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.DesativarUser;

public class DesativarUserRequestDto : RequestDto
{
    public string IdUsuario { get; set; }
}
