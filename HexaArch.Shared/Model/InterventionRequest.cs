namespace HexaArch.Shared.Model
{
    public class InterventionRequest
    {
        public string Supplier { get; set; } = string.Empty;
        public string ContractName { get; set; } = string.Empty;
        public DateOnly InterventionDate { get; set; }
        public float Price { get; set; }
        public float Tva { get; set; }
    }
}