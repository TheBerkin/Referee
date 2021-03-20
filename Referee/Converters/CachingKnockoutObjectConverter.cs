using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Referee.Converters
{
    internal class CachingKnockoutObjectConverter<T> : JsonConverter where T : KnockoutObject
    {
        private static readonly ConditionalWeakTable<Knockout, Dictionary<uint, T>> _knockoutObjectCache = new();

        public override bool CanConvert(Type objectType) => objectType == typeof(T);

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (serializer.Context.Context is Knockout ko)
            {
                var userObj = JObject.Load(reader);
                var userId = userObj.Property("id")?.Value?.Value<uint>() ?? throw new KeyNotFoundException($"Missing ID in Knockout object (path: {reader.Path})");

                var koCache = _knockoutObjectCache.GetOrCreateValue(ko);

                if (!koCache.TryGetValue(userId, out var cachedObject))
                {
                    var kobj = userObj.ToObject<T>()!;
                    koCache[userId] = kobj;
                    return kobj;
                }

                lock (cachedObject.LockObject)
                {
                    serializer.Populate(userObj.CreateReader(), cachedObject);
                    return cachedObject;
                }
            }
            else
            {
                return serializer.Deserialize<User>(reader);
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var json = JObject.FromObject(value, serializer);
            json.WriteTo(writer);
        }
    }
}
