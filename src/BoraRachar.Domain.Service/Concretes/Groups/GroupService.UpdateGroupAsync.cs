using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.UpdateGrupo;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService
{
    public async  Task<ResponseDto<None>> UpdateGroupAsync(UpdateGrupoRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateGroupAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return ResponseDto.Fail("Usuario invalido.", HttpStatusCode.BadRequest);
            }

            var grupo = await _repository.GetByIdAsync(request.GrupoId, cancellation);

            grupo.Descricao = request.Descricao;
            grupo.Nome = request.Nome;
            grupo.IdCategoria = request.IdCategoria;
            grupo.TipoDivisao = request.TipoDivisao;
            grupo.OutrasCategorias = request.OutrasCategorias;
            grupo.ImgGrupo = request.ImgGrupo;

            await _repository.UpdateAsync(grupo, cancellation,
                g => g.Descricao,
                g => g.Nome,
                g => g.IdCategoria,
                g => g.TipoDivisao,
                g => g.OutrasCategorias,
                g => g.ImgGrupo);
            await _repository.SaveChangeAsync(cancellation);

            return ResponseDto.Sucess("Atualizado com sucesso.", HttpStatusCode.Created);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateGroupAsync));
        }
    }
}