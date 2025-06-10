using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Participantes;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Participantes;

public partial class ParticipantesService
{
    public async Task<ResponseDto<IEnumerable<ListParticipantesResponseDto>>> ListParticipantesAsync(ListParticipantesRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListParticipantesAsync));
        try
        {
            var grupo = await _repositoryGrupos.GetByIdAsync(request.GrupoId, cancellation);

            var participantes = await _repositoryParticipantesGrupo.GetByAsync(p => p.GrupoId == request.GrupoId,cancellation);

            if (participantes == null)
            {
                return ResponseDto<IEnumerable<ListParticipantesResponseDto>>.Fail("Participantes nao encontrado.", HttpStatusCode.BadRequest);
            }

            var list = new List<ListParticipantesResponseDto>();

            foreach (var participante in participantes)
            {
                var user = await _userManager.Users.Where(u => u.Id == participante.UserId).FirstOrDefaultAsync();
                
                list.Add(new ListParticipantesResponseDto
                {
                    ParticipanteId = participante.Id,
                    Nome = user.Nome,
                    Apelido = user.Apelido,
                    Email = user.Email,
                    IsAdm = participante.IsAdm,
                    HasPendent = participante.HasPendent ?? false
                });
            }
            
            return ResponseDto<IEnumerable<ListParticipantesResponseDto>>.Sucess(list);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListParticipantesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListParticipantesAsync));
        }
    }
}