using HexaArch.Application.Repositories;
using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Infrastructure.InMemory.Repositories
{
    public class InterventionRepository : IInterventionReadOnlyRepository, IInterventionWriteRepository
    {

        private readonly Context _context;

        public Task Add(Intervention intervention)
        {
            _context.Interventions.Add(intervention);
            return Task.CompletedTask;
        }

        public InterventionRepository(Context context)
        {
            _context = context;
        }

        public Task Delete(Intervention intervention)
        {
            Intervention? interventionOld = _context.Interventions.SingleOrDefault(e => e.Id == intervention.Id);

            if (interventionOld is not null)
                _context.Interventions.Remove(interventionOld);

            return Task.CompletedTask;
        }

        public async Task<Intervention?> Get(Guid id)
            => await Task.FromResult(_context.Interventions.SingleOrDefault(e => e.Id == id));

        public Task Update(Intervention intervention)
        {
            Intervention? interventionOld = _context.Interventions.SingleOrDefault(e => e.Id == intervention.Id);

            if (interventionOld is not null)
                interventionOld = intervention;

            return Task.CompletedTask;
        }
    }
}
