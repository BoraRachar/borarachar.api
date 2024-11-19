using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Domain.Service.Abstract.Interfaces.Convites;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListConvites;

public class ListConvitesHandler: IRequestHandler<ListConvitesRequest, ResponseDto<IEnumerable<ListConvitesResponseDto>>>
{
    private readonly IConviteService _conviteService;

    public ListConvitesHandler(IConviteService conviteService) => _conviteService = conviteService;
    public async Task<ResponseDto<IEnumerable<ListConvitesResponseDto>>> Handle(ListConvitesRequest request, CancellationToken cancellationToken)
    {
        return await _conviteService.ListConvitesAsync(request, cancellationToken);
    }
}