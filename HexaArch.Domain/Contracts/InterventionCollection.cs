using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Domain.Contracts
{
    public class InterventionCollection
    {
        private readonly IList<Guid> _interventionsIds;

        public InterventionCollection()
        {
            _interventionsIds = new List<Guid>();
        }

        public IReadOnlyCollection<Guid> GetInterventionsIds()
        {
            IReadOnlyCollection<Guid> accountIds = new ReadOnlyCollection<Guid>(_interventionsIds);
            return accountIds;
        }

        public void Add(Guid accountId)
        {
            _interventionsIds.Add(accountId);
        }

        public int Count => _interventionsIds.Count;
    }
}
