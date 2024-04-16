using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;

namespace BoraRachar.Domain.Service.Concretes.Email;

public partial class EmailService
{
    public void EnvioEmailAsync(EmailRequestDto request)
    {
        var smtpKey = _config["SMTP_KEY"];
        Configuration.Default.ApiKey.Clear();
        Configuration.Default.ApiKey.Add("api-key", smtpKey);

        var apiInstance = new TransactionalEmailsApi();
        string SenderName = "Segredos de Ouro";
        string SenderEmail = "naoresponda@segredosdoouro.com.br";
        SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);

        string ToEmail = request.Email;
        SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToEmail);
        List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
        To.Add(smtpEmailTo);

        string HtmlContent = CorpoEmail(request.Mensagem);
        string Subject = request.Titulo;

        try
        {
            var sendSmtpEmail = new SendSmtpEmail(Email, To, null, null, HtmlContent, null, Subject, null, null, null, null, null, null, null);
            CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private string CorpoEmail(string htmlMessage)
    {
        string html = @"<html>
                            <head>
                                <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
                                <title>Bora Rachar!</title>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                            </head>

                            <body style='margin: 0; padding: 0;'>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                    <tr>
                                        <td>
                                            <table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse;'>
                                                 <tr>
                                                     <td align='center'>
                                                        <a href='https://www.borarachar.online/' target='_blanck'><img src='https://casegredosdeouro.blob.core.windows.net/imagens-sistema/logo_escrita_preto.png' alt='bora rachar' height='120' style='display: block;' /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>                                
                                                            <tr>
                                                                <td style='padding: 10px 0 30px 0; color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 20px;'>";

        html += htmlMessage;
        html += @"  </td>
                                                    </tr>
                                
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                    <tr>
                                                        <td width='75%' style='color: #000; font-family: Arial, sans-serif; font-size: 14px;'>
                                                            Bora Rachar!
                                                        </td>         									
                                                    </tr>
								                    <tr>								
									                    <td width='75%' style='color: #000; font-family: Arial, sans-serif; font-size: 10px;'>
                                                            Observação: Este é um e-mail de notificação e foi gerado automaticamente. Por favor, não responda esta mensagem.
                                                        </td>         									
								                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </body>
                    </html>";

        return html;
    }




}
