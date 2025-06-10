namespace BoraRachar.Domain.Service.Abstract.Dtos.Participantes;

public class ListParticipantesResponseDto
{
    public string ParticipanteId { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public string Email { get; set; }
    public bool IsAdm { get; set; }
    public bool HasPendent { get; set; }
}