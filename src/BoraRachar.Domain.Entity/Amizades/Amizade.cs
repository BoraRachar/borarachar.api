using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Amizades;

public class Amizade: BaseEntity
{
    public Amizade(string userId, string amigoId)
    {
        Id = Guid.NewGuid().ToString().ToLower();
        UserId = userId;
        AmigoId = amigoId;
        Approved = false;
        DataSolicitacao = DateTime.Now;
    }
    
    public string UserId { get; set; }
    public string AmigoId { get; set; }
    public bool? Approved { get; set; }
    public string? Convidado { get; set; }
    public string? ConvidadoEmail { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public DateTime? DataAprovacao { get; set; }
}