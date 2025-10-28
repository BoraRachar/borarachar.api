using BoraRachar.Domain.Service.Abstract.Dtos.Email;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Email;

public interface INovoEmailService
{
    Task SendAsync(EmailRequestDto request);
}
