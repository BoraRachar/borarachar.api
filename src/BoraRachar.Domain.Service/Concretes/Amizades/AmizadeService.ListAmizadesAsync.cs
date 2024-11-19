
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
    public async Task<ResponseDto<IEnumerable<ListAmizadesResponseDto>>> ListAmizadesAsync(ListAmizadesRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListAmizadesAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);
            var metaData = new MetaDataResponse();

            var amizades = await _repository.GetByAsync(a => (a.AmigoId == userId || a.UserId == userId) && a.Approved.Equals(true), cancellationToken);

            var itens = new List<ListAmizadesResponseDto>();

            foreach (var amizade in amizades)
            {
                var id = amizade.AmigoId == userId ? amizade.UserId : amizade.AmigoId;
                var user = await _userManager.FindByIdAsync(id);
                itens.Add(new ListAmizadesResponseDto
                {
                    AmigoId = amizade.Id,
                    Nome = user.Nome,
                    GruposEmComun = 0
                });
            }

            metaData.PageNumber = request.MetaData.PageNumber;
            metaData.PageSize = request.MetaData.PageSize;
            metaData.TotalRecords = itens.Count;
            // metaData.TotalPages = (request.MetaData.PageSize / itens.Count);
            
            if (!itens.Any())
            {
                return ResponseDto<IEnumerable<ListAmizadesResponseDto>>.Sucess(itens.ToList(), metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListAmizadesResponseDto>>.Sucess(itens.ToList(), metaData, HttpStatusCode.OK);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListAmizadesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListAmizadesAsync));
        }
    }
}