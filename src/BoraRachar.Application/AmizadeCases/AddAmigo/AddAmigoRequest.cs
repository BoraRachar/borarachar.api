using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AddAmigo;

public class AddAmigoRequest: AddAmigoRequestDto, IRequest<ResponseDto<None>>
{
    
}