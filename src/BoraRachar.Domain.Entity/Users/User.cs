using Microsoft.AspNetCore.Identity;

namespace BoraRachar.Domain.Entity.Users;
public class User : IdentityUser
{
	public User(string email)
	{
		Id = Guid.NewGuid().ToString();
		Email = email;
		UserName = email;
		AtivoUsuario = true;
		DataCadastro = DateTime.Now;
	}

	public User(string nome, string email,bool ativo, bool politica, bool termos)
	{
		Id = Guid.NewGuid().ToString();
		Nome = nome;
		Email = email;
		UserName = email;
		AtivoUsuario = ativo;
		DataCadastro = DateTime.Now;
		TermosUso = termos;
		PoliticasPrivacidade = politica;
	}

	public User() { }
	public string? Nome { get; set; }
	public bool? AtivoUsuario { get; set; }
	public bool? TermosUso { get; set; }
	public bool? PoliticasPrivacidade { get; set; }
	public DateTime? DataCadastro { get; set; }
	public DateTime? DataAtualizacao { get; set; }
	public DateTime? DataInativacao { get; set; }
	public ICollection<UserRoles> UserRoles { get; set; }
}
