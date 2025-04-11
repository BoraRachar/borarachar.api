using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.AddGrupo;
using BoraRachar.Domain.Service.Concretes.Helpers;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService
{
    public async Task<ResponseDto<None>> CreateNewGroup(AddGrupoRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(CreateNewGroup));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return ResponseDto.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
            }
           

            var novoGrupo = new Grupos(
                userAdm: user.Id,
                nome: request.Nome,
                idCategoria: request.IdCategoria,
                descricao: request.Descricao,
                tipoDivisao: request.TipoDivisao,
                outrasCategorias: request.OutrasCategorias,
                imgGrupo: request.ImgGrupo!
            );

            await _repository.InsertAsync(novoGrupo, cancellation);
            await _repository.SaveChangeAsync(cancellation);

            await _participantesGrupoService.AddParticipanteGrupoAdmAsync(user.Id, novoGrupo.Id, cancellation);


            if (request.Participantes != null && request.Participantes.Count > 0)
            {
                await _participantesGrupoService.AddParticipanteGrupoAsync(request.Participantes, novoGrupo.Id, user.Id, cancellation);
            }

            return ResponseDto.Sucess("Cadastrado com sucesso.", HttpStatusCode.Created);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(CreateNewGroup));
        }
    }
}
