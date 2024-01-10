using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.Core.Serialization
{
    internal class StringOrObjectAsStringConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var instance = "";
            
            if (reader.TokenType == JsonToken.String)
            {
                instance =  reader.Value?.ToString();
            } 
            else if (reader.TokenType == JsonToken.StartObject)
            {
                instance = JObject.Load(reader).ToString();
            }

            return instance;
        }
    }
}