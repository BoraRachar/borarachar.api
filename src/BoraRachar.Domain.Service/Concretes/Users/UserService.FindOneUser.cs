using System.Net;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;
using Microsoft.Extensions.Logging;

namespace BoraRachar.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<FindOneUserResponseDto>> FindOneUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneUserAsync));

        var result = await _userManager.FindByIdAsync(requestDto.Id);

        if (result == null)
            return ResponseDto<FindOneUserResponseDto>.Fail(HttpStatusCode.NotFound);

        var data = _mapper.Map<FindOneUserResponseDto>(result);
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneUserAsync));
        return ResponseDto<FindOneUserResponseDto>.Sucess(data);
    }
}
