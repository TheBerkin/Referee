using System;
using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public sealed class BannedPost : KnockoutObject
    {
        [DataMember(Name = "thread")]
        public uint ThreadId { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "threadPostNumber")]
        public int ThreadPostNumber { get; private set; }

        [DataMember(Name = "content")]
        public string Content { get; private set; } = string.Empty;

        [DataMember(Name = "createdAt")]
        public DateTime CreationTime { get; private set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedTime { get; private set; }

        [DataMember(Name = "user")]
        public uint AuthorUserId { get; private set; }
    }
}
