using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Domain.Service.Abstract.Interfaces.Email;
using BoraRachar.Domain.Service.Abstract.Templates;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace BoraRachar.Domain.Service.Concretes.NovoEmail;

public sealed class NovoEmailService : INovoEmailService
{
    private readonly IConfiguration _configuration;

    public NovoEmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(EmailRequestDto request)
    {
        var message = CreateEmail(request.Email, request.Titulo, request.Mensagem);
        using var client = new SmtpClient();
        await client.ConnectAsync(
            _configuration["SmtpSettings:Server"],
            int.Parse(_configuration["SmtpSettings:Port"] ?? string.Empty),
            MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    private MimeMessage? CreateEmail(string toEmail, string subjetc, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subjetc;
        message.Body = new TextPart("plain") { Text = EmailTemplate.CorpoEmail(body) };
        return message;
    }
}
