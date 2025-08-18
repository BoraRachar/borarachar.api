using BoraRachar.Domain.Entity.Bases;

namespace BoraRachar.Domain.Entity.Despesas;

public class ParticipanteDepesa: BaseEntity
{
    public ParticipanteDepesa()
    {
        
    }

    public ParticipanteDepesa(string idDespesa, string idGrupo, string idParticipante, bool isPagador = false, bool isRecebedor = false)
    {
        Id = Guid.NewGuid().ToString().ToLower();
        IdDespesa = idDespesa;
        IdGrupo = idGrupo;
        IdParticipantesGrupo = idParticipante;
        IsPagador = isPagador;
        IsRecebedor = isRecebedor;
    }


    public string IdDespesa { get; set; }
    public string IdGrupo { get; set; }
    public string IdParticipantesGrupo { get; set; }
    public bool IsPagador { get; set; }
    public bool IsRecebedor { get; set; }
}