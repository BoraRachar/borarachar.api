
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
    public async Task<ResponseDto<None>> AceiteAmizadeAsync(AceiteRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AceiteAmizadeAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

            var amizade = await _repository.Query.Where(a => a.Id == request.AmigoId && a.UserId == userId).FirstOrDefaultAsync();

            amizade.Approved = true;
            amizade.DataAprovacao = DateTime.Now;
            
            await _repository.UpdateAsync(amizade, cancellationToken,
                a => a.Approved,
                a => a.DataAprovacao);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Sucesso.", HttpStatusCode.Created);
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