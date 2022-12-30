using HexaArch.Domain.Contracts;

namespace HexaArch.Application.Results
{
    public record ContractResult(Guid ContractId, string Name);

    public static class ContractExtension
    {
        public static ContractResult ToContractResult(this Contract contract)
                => new ContractResult(contract.Id, contract.Name);
    }
}
