using System.Net;
using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Entity.Categorias;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.AddCategoria;
using BoraRachar.Domain.Service.Abstract.Dtos.Categorias.ListCategorias;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Categorias;

public partial class CategoriaService
{
    public async Task<ResponseDto<IEnumerable<ListCategoriasResponseDto>>> ListCategoriasAsync(ListCategoriasRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListCategoriasAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repository.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken);

            var metaData = _mapper.Map<MetaDataResponse>(result.MetaData);
            var itens = new List<ListCategoriasResponseDto>();
            
            foreach (var itm in result.Items)
            {
                itens.Add(new ListCategoriasResponseDto
                {
                    IdCategoria = itm.Id,
                    Descricao = itm.Descricao,
                    DataCadastro = itm.DataCadastro,
                    Ativo = itm.Ativo
                });
            }

            metaData.TotalRecords = itens.Count;
            
            if (!itens.Any())
            {
                return ResponseDto<IEnumerable<ListCategoriasResponseDto>>.Sucess(itens.ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListCategoriasResponseDto>>.Sucess(itens.ToList(), metaData, HttpStatusCode.OK);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListCategoriasResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListCategoriasAsync));
        }
    }
}