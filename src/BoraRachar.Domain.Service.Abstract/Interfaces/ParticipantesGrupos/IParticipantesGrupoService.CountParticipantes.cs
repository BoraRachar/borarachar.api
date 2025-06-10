namespace BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;

public partial interface IParticipantesGrupoService
{
    public Task<int> CountParticipantesGrupoAsync(string grupoId, CancellationToken cancellation);
}
