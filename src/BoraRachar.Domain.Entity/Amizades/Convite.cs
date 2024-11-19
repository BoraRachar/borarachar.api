using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Amizades;

public class Convite: BaseEntity
{
    public Convite(string nome, string email, string amigoId, string corpoEmail)
    {
        Id = Guid.NewGuid().ToString().ToLower();
        Nome = nome;
        Email = email;
        AmigoId = amigoId;
        CorpoEmail = corpoEmail;
        DataEnvio = DateTime.Now.AddHours(-3);
        DataReenvio = DateTime.Now.AddHours(-3);
        Aceite = false;
        Reenvio = 0;
    }
    
    public string Nome { get; set; }
    public string Email { get; set; }
    public string CorpoEmail { get; set; }
    public string AmigoId { get; set; }
    public DateTime? DataEnvio { get; set; }
    public DateTime? DataReenvio { get; set; }
    public int? Reenvio { get; set; }
    public bool Aceite { get; set; }
}