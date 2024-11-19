using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.ListConvites;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.ListConvites;

public class ListConvitesRequest: ListConvitesRequestDto, IRequest<ResponseDto<IEnumerable<ListConvitesResponseDto>>>
{
    
}