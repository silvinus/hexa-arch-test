using HexaArch.Domain.ValueObject;
namespace HexaArch.Domain.Interventions
{
    public class Intervention : IEntity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid ContractId { get; private set; }
        public DateOnly InterventionDate { get; private set; }
        public float Price { get; private set; }
        public float Tva { get; private set; }
        public Supplier Supplier { get; private set; }
        public Intervention(Guid contractId, Supplier supplier, DateOnly interventionDate, float price, float tva)
        {
            Id = Guid.NewGuid();
            ContractId = contractId;
            InterventionDate = interventionDate;
            Price = price;
            Supplier = supplier;
            Tva = tva;
        }
    }
}
