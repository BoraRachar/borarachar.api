using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse
{
    public class UserLoginRequestDto : RequestDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
