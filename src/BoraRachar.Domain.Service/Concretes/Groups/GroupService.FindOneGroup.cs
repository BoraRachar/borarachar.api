using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.FindOneGrupo;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService
{
    public async Task<ResponseDto<FindOneGrupoResponseDto>> FindOneGroupAsync(FindOneGrupoRequestDto request, CancellationToken cancellation)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneGroupAsync));

        var result = await _repository.GetByIdAsync(request.GrupoId, cancellation);

        if (result == null)
            return ResponseDto<FindOneGrupoResponseDto>.Fail(HttpStatusCode.NotFound);
        
        var categoria = await _repositoryCategoria.GetByIdAsync(result.IdCategoria, cancellation);
        
        var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

        var data = new FindOneGrupoResponseDto
        {
            GrupoId = result.Id,
            Nome = result.Nome,
            Descricao = result.Descricao,
            Categoria = categoria != null ? categoria.Descricao : string.Empty,
            IsAdm = result.UserAdm == userId
        };
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneGroupAsync));
        return ResponseDto<FindOneGrupoResponseDto>.Sucess(data);
    }
}