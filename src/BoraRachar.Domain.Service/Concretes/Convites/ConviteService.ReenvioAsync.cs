using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Convites.Reenviar;
using BoraRachar.Domain.Service.Abstract.Dtos.Email;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Convites;

public partial class ConviteService
{
    public async Task<ResponseDto<None>> ReenvioConviteAsync(ReenviarRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ReenvioConviteAsync));
        try
        {

            var convite = await _repository.GetByIdAsync(request.IdConvite, cancellation);

            var titulo = "Convite de Amizade";

            var reqEmail = new EmailRequestDto(convite.Email, titulo, convite.CorpoEmail);
            
            _emailService.EnvioEmailAsync(reqEmail);

            convite.Reenvio = convite.Reenvio + 1;
            convite.DataReenvio = DateTime.Now;

            await _repository.UpdateAsync(convite, cancellation,
                c => c.Reenvio,
                c => c.DataReenvio);
            await _repository.SaveChangeAsync(cancellation);
            
            return ResponseDto.Sucess("Reenviado com sucesso.", HttpStatusCode.NoContent);

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
            logger.LogInformation("Metodo finalizado:{0}", nameof(ReenvioConviteAsync));
        }
        
    }
}