namespace BoraRachar.Domain.Service.Abstract.Dtos.User.ListUsers;

public class ListUsersResponseDto
{
	public string IdUsuario { get; set; }
	public string Email { get; set; }
	public string Nome { get; set; }
	public string Celular { get; set; }
	public bool AtivoUsuario { get; set; }
	public DateTime? AtivoDesde { get; set; }
	public DateTime? InativoDesde { get; set; }
}