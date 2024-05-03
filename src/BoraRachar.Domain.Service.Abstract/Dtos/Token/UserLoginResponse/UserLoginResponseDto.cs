namespace BoraRachar.Domain.Service.Abstract.Dtos.Token.UserLoginResponse
{
	public class UserLoginResponseDto
	{
		public UserLoginResponseDto(string at, string rf, string nome, string email, string cod, string apelido, string usuario)
		{
			AccessToken = at;
			RefreshToken = rf;
			ExpiresIn = 3600;
			Nome = nome;
			Email = email;
			Cod = cod;
			Apelido = apelido;
			Usuario = usuario;
		}

		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
		public int ExpiresIn { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Cod { get; set; }
		public string  Apelido { get; set; }
		public string Usuario { get; set; }
	}
}
