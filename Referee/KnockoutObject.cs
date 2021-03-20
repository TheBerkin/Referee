using System.Runtime.Serialization;

namespace Referee
{
    [DataContract]
    public abstract class KnockoutObject
    {
        internal readonly object LockObject = new();

        [DataMember(Name = "id", IsRequired = true)]
        public uint Id { get; private set; }

        public Knockout Context { get; internal set; }
    }
}
