using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public struct ViewerInfo
    {
        [DataMember(Name = "memberCount")]
        public int MemberCount { get; private set; }

        [DataMember(Name = "guestCount")]
        public int GuestCount { get; private set; }
    }
}
