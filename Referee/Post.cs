using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    public sealed class Post : KnockoutObject
    {
        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "thread")]
        public uint OwningThreadId { get; private set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreatedTime { get; private set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedTime { get; private set; }

        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        [DataMember(Name = "threadPostNumber")]
        public int ThreadPostNumber { get; private set; }

        [DataMember(Name = "content")]
        public string Content { get; private set; }

        [DataMember(Name = "user")]
        public User Author { get; private set; }

        [DataMember(Name = "countryCode")]
        public string? CountryCode { get; private set; }

        [DataMember(Name = "countryName")]
        public string? CountryName { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Post post && EqualityComparer<Knockout>.Default.Equals(Owner, post.Owner) && Id == post.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Owner, Id);
    }
}
