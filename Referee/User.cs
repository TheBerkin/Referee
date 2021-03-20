using System;
using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public sealed class User : KnockoutObject
    {
        [DataMember(Name = "username", IsRequired = true)]
        public string Username { get; private set; } = "<Unknown User>";

        [DataMember(Name = "usergroup")]
        public uint UserGroup { get; private set; }

        [DataMember(Name = "posts")]
        public int PostCount { get; private set; }

        [DataMember(Name = "threads")]
        public int ThreadCount { get; private set; }

        [DataMember(Name = "createdAt", IsRequired = true)]
        public DateTime CreationDate { get; private set; }

        [DataMember(Name = "isBanned")]
        public bool IsBanned { get; private set; }

        public override bool Equals(object? obj) => obj is User user && Id == user.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"[#{Id}] {Username}";
    }
}
