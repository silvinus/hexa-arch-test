using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application
{
    public class ContractNotFoundException: ApplicationException
    {
        public ContractNotFoundException(string message)
            : base(message)
        { }
    }

    public class ContractAlreadyExistsException : ApplicationException
    {
        public ContractAlreadyExistsException(string message)
            : base(message)
        { }
    }
}
