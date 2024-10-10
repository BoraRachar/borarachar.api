using System.ComponentModel.DataAnnotations.Schema;
using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Grupos;

public class ParticipantesGrupo: BaseEntity
{
    public ParticipantesGrupo()
    {
        
    }
    public ParticipantesGrupo(string grupoId, string userId)
    {
        Id = Guid.NewGuid().ToString().ToLower();
        GrupoId = grupoId;
        UserId = userId;
        IsAdm = false;
        DataCadastro = DateTime.Now.AddHours(-3);
    }
    
    
    [ForeignKey("Grupos")]  
    public string GrupoId { get; set; }
    [ForeignKey("User")]
    public string UserId { get; set; }
    public bool IsAdm { get; set; }
    public DateTime DataCadastro { get; set; }
}