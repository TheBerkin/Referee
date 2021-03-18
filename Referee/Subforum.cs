using System;
using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public sealed class Subforum : KnockoutObject
    {
        [DataMember(Name = "id", IsRequired = true)]
        public uint Id { get; private set; }

        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; private set; } = "Untitled Subforum";

        [DataMember(Name = "description")]
        public string Description { get; private set; } = "No Description Available";

        [DataMember(Name = "createdAt")]
        public DateTime CreatedTime { get; private set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedTime { get; private set; }

        [DataMember(Name = "totalThreads")]
        public int ThreadCount { get; private set; }

        [DataMember(Name = "totalPosts")]
        public int PostCount { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Subforum subforum && Id == subforum.Id && Name == subforum.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }
}
