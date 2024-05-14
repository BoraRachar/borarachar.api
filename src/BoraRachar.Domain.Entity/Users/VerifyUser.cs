using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Users;

public class VerifyUser : BaseEntity
{
    public string UserId { get; set; }
    public long Code { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}