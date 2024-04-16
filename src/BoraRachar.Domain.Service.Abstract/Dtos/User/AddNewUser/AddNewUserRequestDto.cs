using BoraRachar.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace BoraRachar.Domain.Service.Abstract.Dtos.User.AddNewUser;

public class AddNewUserRequestDto : RequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool TermosUso { get; set; }
    public bool PoliticasPrivacidade { get; set; }
}