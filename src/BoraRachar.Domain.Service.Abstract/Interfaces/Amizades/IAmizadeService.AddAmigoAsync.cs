using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;

namespace BoraRachar.Domain.Service.Abstract.Interfaces.Amizades;

public partial interface IAmizadeService
{
    Task<ResponseDto<None>> AddAmigoAsync(AddAmigoRequestDto request, CancellationToken cancellationToken);
}