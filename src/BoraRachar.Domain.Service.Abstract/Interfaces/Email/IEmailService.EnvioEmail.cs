using BoraRachar.Domain.Service.Abstract.Dtos.Email;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Email;

public partial interface IEmailService
{
    void EnvioEmailAsync(EmailRequestDto request);
}
