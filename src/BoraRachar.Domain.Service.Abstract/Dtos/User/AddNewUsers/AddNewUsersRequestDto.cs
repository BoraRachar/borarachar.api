using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUsers;

public class AddNewUsersRequestDto : RequestDto
{
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Celular { get; set; }
	public bool AtivoUsuario { get; set; }
	public bool TermosUso { get; set; }
	public bool PoliticasPrivacidade { get; set; }
}
