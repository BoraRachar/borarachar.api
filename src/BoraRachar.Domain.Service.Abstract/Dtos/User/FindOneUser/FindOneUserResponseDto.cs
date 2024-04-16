namespace BoraRachar.Domain.Service.Abstract.Dtos.User.FindOneUser;

public class FindOneUserResponseDto
{
	public string IdUsuario { get; set; }
	public string Email { get; set; }
	public string Nome { get; set; }
	public string Celular { get; set; }
	public bool? AtivoUsuario { get; set; }
}