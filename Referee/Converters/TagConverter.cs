using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referee.Converters
{
    public sealed class TagConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(Tag);

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            if (obj.Count != 1) return null;
            var prop = obj.Properties().First();
            return new Tag
            {
                ID = prop.Name,
                Name = prop.Value<string>(),
            };
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
