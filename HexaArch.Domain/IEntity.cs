using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Domain
{
    internal interface IEntity
    {
        Guid Id { get; }
    }
}
