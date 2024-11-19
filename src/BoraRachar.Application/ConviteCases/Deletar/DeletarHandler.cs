using BoraRachar.Application.ConviteCases.Reenviar;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Convites;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.ConviteCases.Deletar;

public class DeletarHandler: IRequestHandler<DeletarRequest, ResponseDto<None>>
{
    private readonly IConviteService _conviteService;

    public DeletarHandler(IConviteService conviteService) => _conviteService = conviteService;
    public async Task<ResponseDto<None>> Handle(DeletarRequest request, CancellationToken cancellationToken)
    {
        return await _conviteService.DeleteConviteAsync(request, cancellationToken);
    }
}