using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string businessMessage)
            : base(businessMessage)
        {
        }
        public ApplicationException(string businessMessage, Exception? innerException)
            : base(businessMessage, innerException)
        {
        }
    }
}
