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
    public async Task<ResponseDto<None>> DeleteConviteAsync(ReenviarRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ReenvioConviteAsync));
        try
        {
            var convite = await _repository.GetByIdAsync(request.IdConvite, cancellation);

            await _repository.DeleteAsync(convite, cancellation);
            await _repository.SaveChangeAsync(cancellation);
            
            return ResponseDto.Sucess("Deletado com sucesso.", HttpStatusCode.NoContent);
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