namespace BoraRachar.Domain.Service.Abstract.Dtos.Participantes;

public class AddParticipantesRequestDto
{
    public List<string> IdParticipantes { get; set; }
    public string GrupoId { get; set; }
    public string UserCod { get; set; }
}