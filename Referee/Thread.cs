using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    public sealed class Thread : KnockoutObject
    {
        [DataMember(Name = "tags")]
        private readonly List<Tag> _tags = new();

        [DataMember(Name = "viewers")]
        private readonly ViewerInfo _viewerInfo = new();

        [DataMember(Name = "id", IsRequired = true)]
        public uint Id { get; private set; }

        [DataMember(Name = "title")]
        public string Title { get; private set; } = string.Empty;

        [DataMember(Name = "deleted")]
        public bool IsDeleted { get; private set; }

        [DataMember(Name = "locked")]
        public bool IsLocked { get; private set; }

        [DataMember(Name = "pinned")]
        public bool IsPinned { get; private set; }

        [DataMember(Name = "subscribed")]
        public bool IsSubscribed { get; private set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreatedTime { get; private set; }

        [DataMember(Name = "deletedAt")]
        public DateTime? DeletedTime { get; private set; }

        [DataMember(Name = "backgroundUrl")]
        public Uri? BackgroundUrl { get; private set; }

        [DataMember(Name = "postCount")]
        public int PostCount { get; private set; }

        [DataMember(Name = "subforumId")]
        public uint SubforumId { get; private set; }

        [DataMember(Name = "posts")]
        public List<Post> Posts { get; private set; }

        public int MemberViewerCount => _viewerInfo.MemberCount;

        public int GuestViewerCount => _viewerInfo.GuestCount;

        public IEnumerable<Tag> Tags => _tags.AsEnumerable();

        public override string ToString() => $"[Thread #{Id}] {Title}";
    }
}
