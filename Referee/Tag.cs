using Referee.Converters;
using System;
using System.Text.Json.Serialization;

namespace Referee
{
    [JsonConverter(typeof(TagConverter))]
    public struct Tag
    {
        public string ID { get; internal set; }

        public string Name { get; internal set; }

        public override bool Equals(object? obj) => obj is Tag tag && ID == tag.ID && Name == tag.Name;

        public override int GetHashCode() => HashCode.Combine(ID, Name);

        public override string ToString() => Name;
    }
}
