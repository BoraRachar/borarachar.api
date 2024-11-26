
using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.Aceite;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Amizades;

public partial class AmizadeService
{
    public async Task<ResponseDto<None>> RecusarAmizadeAsync(AceiteRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AceiteAmizadeAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            
            var amizade = await _repository.GetByOneAsync(a => a.AmigoId == userId && a.UserId == request.AmigoId && a.Approved.Equals(false), cancellationToken);

            if (amizade != null)
            {
                await _repository.DeleteAsync(amizade, cancellationToken);
                await _repository.SaveChangeAsync(cancellationToken);
                return ResponseDto.Sucess("Sucesso.", HttpStatusCode.OK);
            }
            else
            {
                return ResponseDto.Fail(HttpStatusCode.BadRequest);
            }
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AceiteAmizadeAsync));
        }
    }
}