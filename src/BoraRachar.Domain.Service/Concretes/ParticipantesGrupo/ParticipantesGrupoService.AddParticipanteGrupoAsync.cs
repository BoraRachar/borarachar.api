namespace BoraRachar.Domain.Service.Concretes.ParticipantesGrupo;

public partial class ParticipantesGrupoService
{
    public async Task AddParticipanteGrupoAsync(List<string> participantes, string adminId, string grupoId, CancellationToken cancellation)
    {
        List<Entity.Grupos.ParticipantesGrupo> participantesGrupos = new List<Entity.Grupos.ParticipantesGrupo>();
        foreach (var participante in participantes)
        {
            var amizade = await _repositoryAmizade.GetByIdAsync(participante, cancellation);
           
            if(amizade == null)  continue;
            
            var amigoId = amizade.AmigoId == adminId ? amizade.UserId : amizade.AmigoId;
            
            var user = await _userManager.FindByIdAsync(amigoId); 
            
            var participanteGrupo = new Entity.Grupos.ParticipantesGrupo
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                GrupoId = grupoId,
                UserId = user.Id,
                IsAdm = false,
                DataCadastro = DateTime.UtcNow.AddHours(-3),
            };
            
            participantesGrupos.Add(participanteGrupo);
            
        }

        await _repositoryParticipantesGrupo.BulkInsertAsync(participantesGrupos, cancellation);
        await _repositoryParticipantesGrupo.SaveChangeAsync(cancellation);
    }
}