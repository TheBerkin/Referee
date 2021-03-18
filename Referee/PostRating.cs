using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Referee
{
    [DataContract]
    public sealed class PostRating
    {
        [DataMember(Name = "users")]
        private readonly List<string> _issuers = new();

        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "ratingId")]
        public RatingType Type { get; private set; }

        public IEnumerable<string> GetIssuerNames() => _issuers.AsEnumerable();
    }
}
