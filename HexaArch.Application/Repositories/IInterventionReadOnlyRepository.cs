using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application.Repositories
{
    public interface IInterventionReadOnlyRepository
    {
        Task<Intervention?> Get(Guid id);
    }
}
