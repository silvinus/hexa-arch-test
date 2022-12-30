using HexaArch.Application.Queries;
using HexaArch.Application.Results;
using System.Collections.ObjectModel;

namespace HexaArch.Infrastructure.InMemory.Queries
{
    public class ContractQueries : IContractQueries
    {
        private readonly Context _context;

        public ContractQueries(Context context)
        {
            this._context = context;
        }

        public async Task<ReadOnlyDictionary<Guid, int>> CountInterventionsPerContract()
        {
            return new ReadOnlyDictionary<Guid, int>(
                (await Task.WhenAll(this._context.Interventions
                        .GroupBy(x => x.ContractId, x => x.Id)
                        .Select(async w => new { Contract = (await GetContract(w.Key)).ContractId, InterventionCount = w.Count() })))
                        .ToDictionary(w => w.Contract, w => w.InterventionCount)
                        );
        }

        public Task<ContractResult> GetContract(Guid contractId)
        {
            return Task.FromResult(this._context.Contracts
                        .Where(w => w.Id == contractId)
                        .Select(w => w.ToContractResult())
                        .First());
        }

        public async Task<List<ContractResult>> GetContracts()
        {
            IEnumerable<Task<ContractResult>> contracts =
                this._context.Contracts
                    .Select(async w => await this.GetContract(w.Id));

            return (await Task.WhenAll(contracts)).ToList();
        }
    }
}
