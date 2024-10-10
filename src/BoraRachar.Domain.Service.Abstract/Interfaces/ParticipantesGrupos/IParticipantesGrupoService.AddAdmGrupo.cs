namespace BoraRachar.Domain.Service.Abstract.Interfaces.ParticipantesGrupos;

public partial interface IParticipantesGrupoService
{
    public Task<bool> AddParticipanteGrupoAdmAsync(string userId, string grupoId, CancellationToken cancellation);
}