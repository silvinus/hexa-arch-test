using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;

namespace HexaArch.Application.Commands.RegisterContract
{
    public record RegisterResults(Contract Contract, Intervention LastIntervention);
}
