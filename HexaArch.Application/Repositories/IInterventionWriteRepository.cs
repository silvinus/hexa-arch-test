using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application.Repositories
{
    public interface IInterventionWriteRepository
    {
        Task Add(Intervention intervention);
        Task Update(Intervention intervention);
        Task Delete(Intervention intervention);
    }
}
