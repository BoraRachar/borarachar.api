using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Convites.Reenviar;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Convites;

public partial interface IConviteService
{
    public Task<ResponseDto<None>> ReenvioConviteAsync(ReenviarRequestDto request, CancellationToken cancellation);
}