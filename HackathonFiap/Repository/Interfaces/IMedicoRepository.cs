using HackathonFiap.Entities;

namespace HackathonFiap.Repository.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico?> Autenticar(string crm, string senha);
        IEnumerable<Medico>? Get(int? especialidadeId, string? nome, string? cidade);
    }
}
