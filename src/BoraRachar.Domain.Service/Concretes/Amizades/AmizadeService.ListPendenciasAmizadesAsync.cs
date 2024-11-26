
using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Amizades;
using BoraRachar.Domain.Entity.Grupos;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.Aceite;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListAmizades;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Amizades;

public partial class AmizadeService
{
    public async Task<ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>> ListPendenciasAmizadesAsync(ListAmizadesRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListPendenciasAmizadesAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            var metaData = new MetaDataResponse();

            var amizades = await _repository.GetByAsync(a => (a.AmigoId == userId) && a.Approved.Equals(false), cancellationToken);

            var itens = new List<ListPendenciasAmizadesResponseDto>();

            foreach (var amizade in amizades)
            {
                var user = await _userManager.FindByIdAsync(amizade.UserId);
                itens.Add(new ListPendenciasAmizadesResponseDto
                {
                    AmigoId = amizade.UserId,
                    Nome = user.Nome,
                    Aceite = (bool)amizade.Approved
                });
            }

            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.PageSize = request.MetaData.PageSize;
            metaData.TotalRecords = itens.Count;
            // metaData.TotalPages = (request.MetaData.PageSize / itens.Count);
            
            if (!itens.Any())
            {
                return ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>.Sucess(itens.ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>.Sucess(itens.ToList(), metaData, HttpStatusCode.OK);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListPendenciasAmizadesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListPendenciasAmizadesAsync));
        }
    }
}