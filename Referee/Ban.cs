using Newtonsoft.Json;
using Referee.Converters;
using Referee.Internals;
using System;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    public sealed class Ban : KnockoutObject
    {
        [DataMember(Name = "banReason")]
        public string Reason { get; private set; } = "(No Reason Provided)";

        [DataMember(Name = "expiresAt")]
        public DateTime ExpirationTime { get; private set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreationTime { get; private set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedTime { get; private set; }

        [DataMember(Name = "post")]
        [JsonConverter(typeof(CachingKnockoutObjectConverter<BannedPost>))]
        public BannedPost? Post { get; private set; }

        [DataMember(Name = "user")]
        [JsonConverter(typeof(CachingKnockoutObjectConverter<User>))]
        public User Target { get; private set; }

        [DataMember(Name = "bannedBy")]
        [JsonConverter(typeof(CachingKnockoutObjectConverter<User>))]
        public User Issuer { get; private set; }

        public async Task<Thread?> GetSourceThreadAsync(CancellationToken cancellationToken = default)
        {
            if (Post == null) return null;
            return await Context.GetThreadAsync(Post.ThreadId, cancellationToken);
        }

        public override bool Equals(object? obj) => obj is Ban ban && Id == ban.Id;

        public TimeSpan GetDuration() => ExpirationTime >= CreationTime ? ExpirationTime.Subtract(CreationTime) : TimeSpan.Zero;

        public override int GetHashCode() => HashCode.Combine(Id);

        public override string ToString() => $"Ban #{Id} -> {Target.Username}: \"{Reason}\" - {Issuer.Username}";
    }
}
