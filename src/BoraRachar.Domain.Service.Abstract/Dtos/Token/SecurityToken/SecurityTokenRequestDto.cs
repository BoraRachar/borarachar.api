using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Token.SecurityToken;

public class SecurityTokenRequestDto : RequestDto
{
    public string RefreshToken { get; set; }
}
