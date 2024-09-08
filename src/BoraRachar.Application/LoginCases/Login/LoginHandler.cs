using System.Net;
using MediatR;
using BoraRachar.Application.RefreshTokenCases.Token;
using BoraRachar.Application.Util;
using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Responses;
using BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;
using BoraRachar.Domain.Service.Abstract.Interfaces.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Interfaces;

namespace BoraRachar.Application.LoginCases.Login;

public class LoginHandler : IRequestHandler<LoginRequest, ResponseDto<UserLoginResponseDto>>
{
	private readonly UserManager<User> _userManager;
	private readonly IAcessManager _acessManager;
	private readonly IJwtService _jwtService;

	public LoginHandler(IJwtService jwtService, IAcessManager acessManager, UserManager<User> userManager)
	{
		_jwtService = jwtService;
		_acessManager = acessManager;
		_userManager = userManager;
	}

	public async Task<ResponseDto<UserLoginResponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
	{

		bool isEmail = CriptografiaHelper.VerifyEmail(request.Email);
		
		var user = isEmail 
			? await _userManager.Users.Where(u => u.Email == request.Email).FirstOrDefaultAsync() 
			: await _userManager.Users.Where(u => u.UserName == request.Email).FirstOrDefaultAsync() ;
	
		if (user is null)
		{
			return ResponseDto<UserLoginResponseDto>.Fail("Usuário ou senha inválidos.", HttpStatusCode.BadRequest);
		}

		var result = await _acessManager.ValidateCredentials(user, request.Password);

		if (result.IsLockedOut)
			return ResponseDto<UserLoginResponseDto>.Fail("Usuário bloqueado.", HttpStatusCode.BadRequest);

		if (!result.Succeeded)
			return ResponseDto<UserLoginResponseDto>.Fail("Usuário ou senha inválidos.", HttpStatusCode.BadRequest);

		AccessToken accessToken = new AccessToken();
		RefreshToken refreshToken = new RefreshToken();

		var at = await accessToken.GenerateAccessToken(_userManager, _jwtService, user.Email);
		var rt = await refreshToken.GenerateRefreshToken(_userManager, _jwtService, user.Email);

		return ResponseDto<UserLoginResponseDto>.Sucess(new UserLoginResponseDto(at, rt, user.Nome, user.Email, CriptografiaHelper.EncryptQueryString(user.Id), user.UserName));
	}
}
