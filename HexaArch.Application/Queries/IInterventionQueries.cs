using HexaArch.Application.Results;

namespace HexaArch.Application.Queries
{
    public interface IInterventionQueries
    {
        Task<List<InterventionResult>> GetInterventions();
        Task<List<InterventionResult>> GetInterventions(Guid contractId);
        Task<InterventionResult> GetIntervention(Guid InterventionId);
    }
}
