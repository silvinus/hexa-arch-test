using HexaArch.Application.Results;
using System.Collections.ObjectModel;

namespace HexaArch.Application.Queries
{
    public interface IContractQueries
    {
        Task<List<ContractResult>> GetContracts();
        Task<ContractResult> GetContract(Guid ContractId);
        Task<ReadOnlyDictionary<Guid, int>> CountInterventionsPerContract();
    }
}
