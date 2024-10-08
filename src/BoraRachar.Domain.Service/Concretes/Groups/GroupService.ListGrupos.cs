using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Grupos.ListarGrupo;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Groups;

public partial class GroupService
{
    public async Task<ResponseDto<IEnumerable<ListarGrupoResponseDto>>> ListarGruposAsync(
        ListarGrupoRequestDto request, 
        CancellationToken cancellationToken
    )
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListarGruposAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repository.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken
            );

            var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);
            var itens = new List<ListarGrupoResponseDto>();

            foreach (var itm in result.Items)
            {
                itens.Add(new ListarGrupoResponseDto
                {
                    Nome = itm.Nome,
                    Descricao = itm.Descricao,
                    IdCategoria = itm.Id,
                    ImgGrupo = itm.ImgGrupo,
                    TipoDivisao = itm.TipoDivisao,
                    OutrasCategorias = itm.OutrasCategorias
                });
            }

            metaData.TotalRecords = itens.Count;

            if (!itens.Any()) return ResponseDto<IEnumerable<ListarGrupoResponseDto>>
                        .Sucess(
                            itens.ToList(), 
                            metaData
                        );

            return ResponseDto<IEnumerable<ListarGrupoResponseDto>>
                    .Sucess(
                        itens.ToList(), 
                        metaData, 
                        System.Net.HttpStatusCode.OK
                    );

        }        
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListarGrupoResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListarGruposAsync));
        }
    }
}
