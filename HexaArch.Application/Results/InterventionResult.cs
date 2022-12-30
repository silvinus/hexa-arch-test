using HexaArch.Domain.Interventions;
using HexaArch.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application.Results
{
    public record InterventionResult(Guid InterventionId, ContractResult Contract, DateOnly InterventionDate, 
        int NbInterventions,
        float Price, float Tva, Supplier Supplier);

    public static class InterventionExtensions
    {
        public static InterventionResult ToInterventionResult(this Intervention intervention, int nbIntervention, ContractResult contract)
                => new InterventionResult(intervention.Id, contract, intervention.InterventionDate, nbIntervention, intervention.Price, intervention.Tva, intervention.Supplier);
    }
}
