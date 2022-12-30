using HexaArch.Application.Results;
using HexaArch.Shared.Model;

namespace HexaArch.Server.Extensions
{
    public static class InterventionResultExtensions
    {
        public static InterventionModel ToInterventionModel(this InterventionResult result)
        {
            return new InterventionModel()
            {
                Id = result.InterventionId,
                InterventionDate = result.InterventionDate,
                Price = result.Price,
                Tva = result.Tva,
                NbIntervention = result.NbInterventions,
                TvaAmount = (result.Price * result.Tva) / 100,
                Supplier = result.Supplier.Name,
                ContractId = result.Contract.ContractId,
                Contract = result.Contract.Name
            };
        }
    }
}
