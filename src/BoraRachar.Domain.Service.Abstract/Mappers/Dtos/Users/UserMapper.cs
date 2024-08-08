using BoraRachar.Domain.Entity.Users;
using BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;
using BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace BoraRachar.Domain.Service.Abstract.Mappers.Dtos.Users;

public class UserMapper : BaseAutoMapper
{
	public UserMapper()
	{
		CreateMap<User, AddNewUserRequestDto>()
			.ForMember(x => x.PoliticasPrivacidade, opt => opt.MapFrom(x => x.PoliticasPrivacidade))
			.ForMember(x => x.TermosUso, opt => opt.MapFrom(x => x.TermosUso))
			.ReverseMap();

		CreateMap<User, UserEntity>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			.ReverseMap();

		CreateMap<UserEntity, User>()
			 .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Nome))
			 .ReverseMap();

		CreateMap<User, FindOneUserResponseDto>()
			.ForMember(x => x.Celular, opt => opt.MapFrom(x => x.PhoneNumber))
			.ForMember(x => x.IdUsuario, opt => opt.MapFrom(x => x.Id))
			.ReverseMap();
	}
}