namespace BoraRachar.Domain.Service.Abstract.Dtos.Amizades.AddAmigo;

public class AddAmigoEmailRequestDto
{
    public string UserCod { get; set; }
    public string Email { get; set; }
    public string NomeConvidado { get; set; }
    public string? CorpoEmail { get; set; }
}