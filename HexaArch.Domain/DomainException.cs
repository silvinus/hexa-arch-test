using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Domain
{
    public class DomainException : Exception
    {
        internal DomainException(string businessMessage, Exception? innerException)
            : base(businessMessage, innerException)
        {
        }
    }
}
