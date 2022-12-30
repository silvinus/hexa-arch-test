using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application.Repositories
{
    public interface IContractWriteRepository
    {
        Task Add(Contract contract);
        Task Update(Contract contract, Intervention intervention);
        Task Delete(Contract contract);
    }
}
