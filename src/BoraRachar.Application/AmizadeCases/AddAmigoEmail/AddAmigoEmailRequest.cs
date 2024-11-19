using BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Infra.CrossCuting;
using MediatR;

namespace BoraRachar.Application.AmizadeCases.AddAmigoEmail;

public class AddAmigoEmailRequest: AddAmigoEmailRequestDto, IRequest<ResponseDto<None>>
{
    
}