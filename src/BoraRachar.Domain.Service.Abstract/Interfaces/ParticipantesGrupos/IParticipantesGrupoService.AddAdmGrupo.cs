namespace BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;

public partial interface IParticipantesGrupoService
{
    public Task AddParticipanteGrupoAdmAsync(string userId, string grupoId, CancellationToken cancellation);
}