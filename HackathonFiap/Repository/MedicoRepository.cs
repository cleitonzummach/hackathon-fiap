using HackathonFiap.Context;
using HackathonFiap.Entities;
using HackathonFiap.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackathonFiap.Repository.Interfaces
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ContextDB _context;

        public MedicoRepository(ContextDB context) => _context = context;

        public async Task<Medico?> Autenticar(string crm, string senha)
        {
            var medico = await _context.Medico.FirstOrDefaultAsync(m => m.CRM == crm && m.Senha == senha);

            return medico ?? null;
        }

        public IEnumerable<Medico>? Get(int? especialidadeId, string? nome, string? cidade)
        {
            IQueryable<Medico> query = _context.Medico.Include(m => m.Especialidade);

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
