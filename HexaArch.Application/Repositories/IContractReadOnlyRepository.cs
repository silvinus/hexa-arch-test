using HexaArch.Domain.Contracts;

namespace HexaArch.Application.Repositories
{
    public interface IContractReadOnlyRepository
    {
        Task<Contract?> Get(Guid id);
        Task<Contract?> GetByName(string name);
    }
}
