using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Infrastructure.InMemory
{
    public class Context
    {
        public Collection<Contract> Contracts { get; set; }
        public Collection<Intervention> Interventions { get; set; }

        public Context()
        {
            Contracts = new Collection<Contract>();
            Interventions = new Collection<Intervention>();
        }
    }
}
