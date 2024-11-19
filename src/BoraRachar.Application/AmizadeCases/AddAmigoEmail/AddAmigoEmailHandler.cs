using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AddAmigoEmail;

public class AddAmigoEmailHandler: IRequestHandler<AddAmigoEmailRequest, ResponseDto<None>>
{
    private readonly IAmizadeService _amizadeService;

    public AddAmigoEmailHandler(IAmizadeService amizadeService) => _amizadeService = amizadeService;
    public async Task<ResponseDto<None>> Handle(AddAmigoEmailRequest request, CancellationToken cancellationToken)
    {
        return await _amizadeService.AddAmigoEmailAsync(request, cancellationToken);
    }
}