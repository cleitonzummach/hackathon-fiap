using HackathonFiap.Context;
using HackathonFiap.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackathonFiap.Repository.Interfaces
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ContextDB _context;

        public MedicoRepository(ContextDB context) => _context = context;

        public IEnumerable<Medico>? Get(int? especialidadeId, string? nome, string? cidade)
        {
            IQueryable<Medico> query = _context.Medico;

            if (especialidadeId.HasValue)
                query = query.Where(x => x.EspecialidadeId == especialidadeId.Value).AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.ToUpper().Contains(nome.ToUpper())).AsQueryable();

            if (!string.IsNullOrEmpty(cidade))
                query = query.Where(x => x.Cidade.ToUpper().Contains(cidade.ToUpper())).AsQueryable();

            return query.AsEnumerable();
        }
    }
}
