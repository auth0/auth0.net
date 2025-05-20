using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.Core.Serialization
{
    internal class StringOrStringArrayJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object? ReadJson(
            JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Deserialize as string array and return;
                var array = JArray.Load(reader);
                return array.ToObject<string[]>();
            }

            if (reader.TokenType == JsonToken.String)
            {
                // Deserialize as a single string
                return reader.Value?.ToString();
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
