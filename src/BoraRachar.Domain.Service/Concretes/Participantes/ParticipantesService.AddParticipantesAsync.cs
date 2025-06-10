using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Participantes;

public partial class ParticipantesService
{
    public async Task<ResponseDto<None>> AddParticipantesAsync(AddParticipantesRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddParticipantesAsync));
        try
        {
            List<Entity.Grupos.ParticipantesGrupo> participantesGrupos = new List<Entity.Grupos.ParticipantesGrupo>();
            foreach (var participante in request.IdParticipantes)
            {
                var amizade = await _repositoryAmizade.GetByIdAsync(participante, cancellation);
           
                if(amizade == null)  continue;
            
                var amigoId = amizade.AmigoId == request.UserCod ? amizade.UserId : amizade.AmigoId;
            
                var user = await _userManager.FindByIdAsync(amigoId); 
            
                var participanteGrupo = new Entity.Grupos.ParticipantesGrupo
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    GrupoId = request.GrupoId,
                    UserId = user.Id,
                    IsAdm = false,
                    DataCadastro = DateTime.Now.AddHours(-3),
                };
            
                participantesGrupos.Add(participanteGrupo);
            }

            if (participantesGrupos.Count > 0)
            {
                await _repositoryParticipantesGrupo.BulkInsertAsync(participantesGrupos, cancellation);
                await _repositoryParticipantesGrupo.SaveChangeAsync(cancellation);
                
                return ResponseDto.Sucess("Sucesso.", HttpStatusCode.NoContent);
            }
            else
            {
                return ResponseDto.Sucess("Erro ao adicionar participante.", HttpStatusCode.BadRequest);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddParticipantesAsync));
        }
    }
}