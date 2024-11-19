using System.Net;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Convites;

public partial class ConviteService
{
    public async Task<ResponseDto<IEnumerable<ListConvitesResponseDto>>> ListConvitesAsync(ListConvitesRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListConvitesAsync));
        try
        {
            var userId = CriptografiaHelper.DecryptQueryString(request.UserCod);

            var convites = await _repository.GetByAsync(c => c.AmigoId == userId, cancellationToken);

            var list = new List<ListConvitesResponseDto>();
            foreach (var convite in convites)
            {
                list.Add(new ListConvitesResponseDto
                {
                    IdConvite = convite.Id,
                    Nome = convite.Nome
                });
            }
            
            if (list.Count == 0)
            {
                return ResponseDto<IEnumerable<ListConvitesResponseDto>>.Fail("Nenhum convite encontrado.", HttpStatusCode.Found);
            }
            else
            {
                return ResponseDto<IEnumerable<ListConvitesResponseDto>>.Sucess(list);
            }

        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListConvitesResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListConvitesAsync));
        }
    }
}