namespace BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;

public partial interface IParticipantesGrupoService
{
    public Task<List<string>> CountParticipantesGrupoAsync(string grupoId, CancellationToken cancellation);
}
