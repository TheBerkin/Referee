using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Referee.Internals
{
    [DataContract]
    internal class SubforumCollection : KnockoutObject
    {
        [DataMember(Name = "list", IsRequired = true)]
        public List<Subforum> Subforums { get; private set; }
    }
}
