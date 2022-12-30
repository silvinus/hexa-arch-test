using HexaArch.Application.Repositories;
using HexaArch.Domain.Contracts;
using HexaArch.Domain.ValueObject;

namespace HexaArch.Application.Commands.RegisterContract
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IContractReadOnlyRepository contracts;
        private readonly IContractWriteRepository contractsWrite;
        private readonly IInterventionWriteRepository interventionWrite;

        public RegisterUseCase(IContractReadOnlyRepository contracts, 
            IContractWriteRepository contractsWrite, IInterventionWriteRepository interventionWrite)
        {
            this.contracts = contracts;
            this.contractsWrite = contractsWrite;
            this.interventionWrite = interventionWrite;
        }

        public async Task<RegisterResults> Execute(Supplier supplier, string name, DateOnly interventionDate, float price, float tva)
        {
            Contract? contract = await this.contracts.GetByName(name);
            if (contract is null)
            {
                contract = new Contract(supplier, name, new InterventionCollection());
                await contractsWrite.Add(contract);
            }

            Domain.Interventions.Intervention intervention = contract.AddIntervention(interventionDate, supplier, price, tva);
            await interventionWrite.Add(intervention);

            return new RegisterResults(contract, intervention);
        }
    }
}
