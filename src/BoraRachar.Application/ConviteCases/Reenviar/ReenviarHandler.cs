using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Convites;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ConviteCases.Reenviar;

public class ReenviarHandler: IRequestHandler<ReenviarRequest, ResponseDto<None>>
{
    private readonly IConviteService _conviteService;

    public ReenviarHandler(IConviteService conviteService) => _conviteService = conviteService;
    public async Task<ResponseDto<None>> Handle(ReenviarRequest request, CancellationToken cancellationToken)
    {
        return await _conviteService.ReenvioConviteAsync(request, cancellationToken);
    }
}