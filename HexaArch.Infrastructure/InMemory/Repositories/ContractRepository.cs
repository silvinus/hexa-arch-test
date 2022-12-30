using HexaArch.Application.Repositories;
using HexaArch.Domain.Contracts;
using HexaArch.Domain.Interventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Infrastructure.InMemory.Repositories
{
    internal class ContractRepository : IContractReadOnlyRepository, IContractWriteRepository
    {

        private readonly Context _context;

        public ContractRepository(Context context)
        {
            _context = context;
        }

        public Task Add(Contract contract)
        {
            _context.Contracts.Add(contract);
            return Task.CompletedTask;
        }

        public Task Delete(Contract contract)
        {
            Contract? contractOld = _context.Contracts.SingleOrDefault(e => e.Id == contract.Id);

            if(contractOld is not null)
                _context.Contracts.Remove(contractOld);

            return Task.CompletedTask;
        }

        public async Task<Contract?> Get(Guid id)
        {
            Contract? contract = _context.Contracts.SingleOrDefault(e => e.Id == id);
            return await Task.FromResult(contract);
        }

        public async Task<Contract?> GetByName(string name)
        {
            Contract? contract = _context.Contracts.SingleOrDefault(e => e.Name == name);
            return await Task.FromResult(contract);
        }

        public Task Update(Contract contract, Intervention intervention)
        {
            Contract? contractOld = _context.Contracts.SingleOrDefault(e => e.Id == contract.Id);

            if (contractOld is not null)
                contractOld = contract;

            return Task.CompletedTask;
        }
    }
}
