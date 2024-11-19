using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Convites;

public partial interface IConviteService
{
    Task<ResponseDto<IEnumerable<ListConvitesResponseDto>>> ListConvitesAsync(ListConvitesRequestDto request, CancellationToken cancellationToken);
}