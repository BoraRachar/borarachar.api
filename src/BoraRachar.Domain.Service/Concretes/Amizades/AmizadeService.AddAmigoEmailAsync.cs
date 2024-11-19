using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Amizades;

public partial class AmizadeService
{
    public async Task<ResponseDto<None>> AddAmigoEmailAsync(AddAmigoEmailRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddAmigoEmailAsync));
        try
        {
            var existUser = await _userManager.FindByEmailAsync(request.Email);

            if (existUser != null)
            {
                return ResponseDto.Fail("Email ja cadastrado.", HttpStatusCode.BadRequest);
            }
            
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            
            var user = await _userManager.FindByIdAsync(userId);
           
            string link = "https://drive.google.com/file/d/1On-upFKC1YLl8iSOBys9lFWY19BFahCi/view?usp=sharing";

            var corpoEmail = string.IsNullOrEmpty(request.CorpoEmail) ? BaseCorpoEmail(request.NomeConvidado, user?.Nome, link) : request.CorpoEmail;

            var titulo = "Convite Amizade";
            
            var reqEmail = new EmailRequestDto(request.Email, titulo, corpoEmail);
            
            _emailService.EnvioEmailAsync(reqEmail);

            var convite = new Convite(request.NomeConvidado, request.Email,userId, corpoEmail);

            await _repositoryConvite.InsertAsync(convite, cancellationToken);
            await _repositoryConvite.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Enviado com sucesso.", HttpStatusCode.Created);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddAmigoEmailAsync));
        }
    }

    private string BaseCorpoEmail(string nomeAmigo, string nomeConvidante, string link)
    {
        string email = $"<span>Oi, {nomeAmigo},</span>" +
            $"<p>Estou te convidando para usar o Bora Rachar comigo, um app que ajuda a gente a dividir as contas de forma fácil e divertida!</p>" +
            $" <p>Com o app, a gente pode:" +
            $"Registrar todas as nossas despesas em conjunto, como restaurantes, viagens, compras e muito mais;<br>" +
            $"Dividir as contas de forma justa, levando em consideração o que cada um consumiu;<br>" +
            $"Receber notificações quando alguém registrar uma nova despesa;<br>" +
            $"Ver o histórico de todas as nossas divisões;<br>" +
            $"E muito mais!<br>" +
            $"Eu achei o app muito legal e acho que você também vai gostar!<br>" +
            $"Para se juntar a gente, basta baixar o app e usar o meu <a href='{link}'>link</a> de convite<br>" +
            $"Depois de se cadastrar, você pode criar um novo grupo e me convidar para participar. Assim, a gente já pode começar a dividir as contas das nossas próximas aventuras!<br>" +
            $"Se tiver qualquer dúvida, é só me chamar!<br>" +
            $"Abraço,<br>" +
        $"<span><strong>{nomeConvidante}</strong></span></p>";
        
        return email;
    }
}