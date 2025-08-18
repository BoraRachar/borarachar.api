using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Participantes;

public partial class ParticipantesService
{
    public async Task<ResponseDto<None>> DeleteParticipantesAsync(AddParticipantesRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteParticipantesAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            List<Entity.Grupos.ParticipantesGrupo> participantesGrupos = new List<Entity.Grupos.ParticipantesGrupo>();
            foreach (var participante in request.IdParticipantes)
            {
                var participanteGrupo = await _repositoryParticipantesGrupo.GetByIdAsync(participante, cancellation);
            
                participantesGrupos.Add(participanteGrupo);
            }

            if (participantesGrupos.Count > 0)
            {
                await _repositoryParticipantesGrupo.BulkDeleteAsync(participantesGrupos, cancellation);
                await _repositoryParticipantesGrupo.SaveChangeAsync(cancellation);
                
                return ResponseDto.Sucess("Sucesso.", HttpStatusCode.NoContent);
            }
            else
            {
                return ResponseDto.Sucess("Erro ao deletar participante.", HttpStatusCode.BadRequest);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteParticipantesAsync));
        }
    }
}