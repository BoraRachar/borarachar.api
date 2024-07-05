namespace BoraRachar.Domain.Service.Abstract.Dtos.User.ResetPassword;

public class ResetPasswordRequestDto
{
    public string Email { get; set; }
    public long Code { get; set; }
    public string NovaSenha { get; set; }
    public string ConfirmacaoSenha { get; set; }
}
