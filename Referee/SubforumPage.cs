using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public sealed class SubforumPage : Subforum
    {
        [DataMember(Name = "currentPage")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "threads")]
        public List<Thread>? Threads { get; private set; }
    }
}
