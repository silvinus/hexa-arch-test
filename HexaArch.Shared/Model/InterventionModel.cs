namespace HexaArch.Shared.Model
{
    public class InterventionModel
    {
        public Guid Id { get; set; }
        public DateOnly InterventionDate { get; set; }
        public float Price { get; set; }
        public int NbIntervention { get; set; }
        public float Tva { get; set; }
        public float TvaAmount { get; set; }
        public string Contract { get; set; } = string.Empty;
        public Guid ContractId { get; set; }
        public string Supplier { get; set; } = string.Empty;
    }
}
