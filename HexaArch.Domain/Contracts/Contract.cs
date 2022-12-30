using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;
using HexaArch.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Domain.Contracts
{
    public class Contract : IEntity, IAggregateRoot
    {
        private InterventionCollection _interventions;
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Guid> Interventions
        {
            get
            {
                IReadOnlyCollection<Guid> readOnly = _interventions.GetInterventionsIds();
                return readOnly;
            }
        }

        public int InterventionCount => this._interventions.Count;

        public Contract(Supplier? supplier, string name, InterventionCollection interventions)
            :this(Guid.NewGuid(), supplier, name, interventions) { }
        

        private Contract(Guid Id, Supplier? supplier, string name, InterventionCollection interventions)
        {
            this.Id = Id;
            this._interventions = interventions;
            Name = name;
        }

        public Intervention AddIntervention(DateOnly interventionDate, Supplier supplier, float price, float tva)
        {
            Intervention intervention = new Intervention(
                this.Id,
                supplier,
                interventionDate,
                price,
                tva
                );
            _interventions.Add(intervention.Id);

            return intervention;
        }

        public static Contract Load(Guid id, string name, Supplier supplier, InterventionCollection intervention) 
            => new Contract(supplier, name, intervention);
    }
}
