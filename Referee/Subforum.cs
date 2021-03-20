using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    public class Subforum : KnockoutObject
    {
        public const int PageSize = 40;

        [DataMember(Name = "name", IsRequired = true)]
        public string Name { get; private set; } = "Untitled Subforum";

        [DataMember(Name = "description")]
        public string Description { get; private set; } = "(No Description Available)";

        [DataMember(Name = "createdAt")]
        public DateTime CreatedTime { get; private set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedTime { get; private set; }

        [DataMember(Name = "totalThreads")]
        public int ThreadCount { get; private set; }

        public int PageCount => (int)Math.Ceiling((float)ThreadCount / PageSize);

        [DataMember(Name = "totalPosts")]
        public int PostCount { get; private set; }

        [DataMember(Name = "lastPost")]
        public Post? LastPost { get; private set; }

        public async Task<SubforumPage?> GetPageAsync(int page = 1, CancellationToken cancellationToken = default)
        {
            return await Context.GetObjectAsync<SubforumPage>($"{Knockout.URL_SUBFORUM}{Id}/{page}", cancellationToken);
        }

        public override bool Equals(object? obj)
        {
            return obj is Subforum subforum && Id == subforum.Id && Name == subforum.Name;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Name);
    }
}
