using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Participantes;

public partial class ParticipantesService
{
    public async Task<ResponseDto<None>> IsAdmAsync(IsAdmRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(IsAdmAsync));
        try
        {
            var participante = await _repositoryParticipantesGrupo.GetByOneAsync(p => p.GrupoId == request.GrupoId 
                                                                                   && p.Id == request.ParticipanteId, cancellation);

            if (participante == null)
            {
                return ResponseDto.Fail("Participante nao encontrado.", HttpStatusCode.BadRequest);
            }

            participante.IsAdm = !participante.IsAdm;

            await _repositoryParticipantesGrupo.UpdateAsync(participante, cancellation,
                p => p.IsAdm);
            await _repositoryParticipantesGrupo.SaveChangeAsync(cancellation);
            
            return ResponseDto.Sucess("Sucesso.", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(IsAdmAsync));
        }
    }
}