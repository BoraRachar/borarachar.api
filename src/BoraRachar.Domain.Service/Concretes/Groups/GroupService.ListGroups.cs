using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListGroups;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService
{
    public async Task<ResponseDto<IEnumerable<ListGroupResponseDto>>> ListGroupsAsync(ListGroupRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListGroupsAsync));

        var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

        var adm = await _userManager.FindByIdAsync(userId);

        if (adm == null)
        {
            return ResponseDto<IEnumerable<ListGroupResponseDto>>.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
        }

        var metaData = new MetaDataResponse();

        var listGrupos = await _repository.GetByAsync(g => g.UserAdm == adm.Id, cancellation);

        var itens = new List<ListGroupResponseDto>();

        foreach (var grupo in listGrupos.Where(g => g.Ativo == true && g.Deleted != true))
        {
            var participantes = await _participantesGrupoService.CountParticipantesGrupoAsync(grupo.Id, cancellation);
            var itn = new ListGroupResponseDto
            {
                GrupoId = grupo.Id,
                Descricao = grupo.Descricao,
                Participantes = participantes.Count
            };
            itens.Add(itn);
        }

        logger.LogInformation("Metodo finalizado:{0}", nameof(ListGroupsAsync));

        if (itens.Count > 0)
        {
            return ResponseDto<IEnumerable<ListGroupResponseDto>>.Sucess(itens, metaData);
        }
        else
        {
            return ResponseDto<IEnumerable<ListGroupResponseDto>>.Sucess(itens, metaData, HttpStatusCode.NoContent);
        }
    }
}