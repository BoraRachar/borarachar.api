namespace BoraRachar.Domain.Service.Abstract.Dtos.Email;

public class EmailRequestDto
{
    public EmailRequestDto() { }
    public EmailRequestDto(string email, string titulo, string mensagem)
    {
        Email = email;
        Titulo = titulo;
        Mensagem = mensagem;
    }

    public string Email { get; set; }
    public string Titulo { get; set; }
    public string Mensagem { get; set; }
}
