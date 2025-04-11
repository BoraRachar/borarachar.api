namespace BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;

public partial interface IParticipantesGrupoService
{
    public Task AddParticipanteGrupoAsync(List<string> participantes, string grupoId, string adminId, CancellationToken cancellation);
}