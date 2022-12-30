using HexaArch.Application.Queries;
using HexaArch.Application.Results;
using System.Collections.ObjectModel;

namespace HexaArch.Infrastructure.InMemory.Queries
{
    public class InterventionQueries : IInterventionQueries
    {
        private readonly Context _context;
        private readonly IContractQueries _contractQueries;

        public InterventionQueries(IContractQueries contractQueries, Context context)
        {
            _contractQueries = contractQueries;
            _context = context;
        }

        public async Task<InterventionResult> GetIntervention(Guid InterventionId)
        {
            ReadOnlyDictionary<Guid, int> interventionsPerContract = 
                await _contractQueries.CountInterventionsPerContract();

            return await this._context.Interventions
                        .Where(w => w.Id == InterventionId)
                        .Select(async w => w.ToInterventionResult(interventionsPerContract[w.ContractId], await _contractQueries.GetContract(w.ContractId)))
                        .First();
        }

        public async Task<List<InterventionResult>> GetInterventions()
        {
            IEnumerable<Task<InterventionResult>> interventions = 
                this._context.Interventions
                    .Select(async (w) => await this.GetIntervention(w.Id));
            return (await Task.WhenAll(interventions)).ToList();
        }

        public async Task<List<InterventionResult>> GetInterventions(Guid contractId)
        {
            ReadOnlyDictionary<Guid, int> interventionsPerContract =
                await _contractQueries.CountInterventionsPerContract();

            IEnumerable<Task<InterventionResult>> interventions = 
                this._context.Interventions
                    .Where(w => w.ContractId == contractId)
                    .Select(async w => w.ToInterventionResult(interventionsPerContract[w.ContractId], await _contractQueries.GetContract(w.ContractId)));

            return (await Task.WhenAll(interventions)).ToList();
        }
    }
}
