using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AddAmigo;

public class AddAmigoHandler: IRequestHandler<AddAmigoRequest, ResponseDto<None>>
{
    private readonly IAmizadeService _amizadeService;

    public AddAmigoHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
    public async Task<ResponseDto<None>> Handle(AddAmigoRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.AddAmigoAsync(request, cancellationToken);
    }
}