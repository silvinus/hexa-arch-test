namespace HexaArch.Server.Controllers.Register
{
    public record RegisterModel(Guid InterventionId, DateOnly IntevrentionDate, float Price, float Tva, int InterventionCount, string ContractName);
}
