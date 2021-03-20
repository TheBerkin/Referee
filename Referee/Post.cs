using Newtonsoft.Json;
using Referee.Converters;
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
        [DataMember(Name = "thread")]
        public uint ThreadId { get; private set; }

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
        [JsonConverter(typeof(CachingKnockoutObjectConverter<User>))]
        public User Author { get; private set; }

        [DataMember(Name = "countryCode")]
        public string? CountryCode { get; private set; }

        [DataMember(Name = "countryName")]
        public string? CountryName { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Post post && EqualityComparer<Knockout>.Default.Equals(Context, post.Context) && Id == post.Id;
        }

        public override int GetHashCode() => HashCode.Combine(Context, Id);
    }
}
