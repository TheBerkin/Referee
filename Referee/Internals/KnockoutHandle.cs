using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee.Internals
{
    [DataContract]
    internal struct KnockoutHandle
    {
        [DataMember(Name = "id", IsRequired = true)]
        public uint Id { get; private set; }
    }
}
