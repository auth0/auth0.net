using System;
using System.Collections.Generic;
using System.Reflection;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.ManagementApi
{
    internal class ListConverter<T> : JsonConverter
    {
        private readonly string _collectionFieldName;

        public ListConverter(string collectionFieldName)
        {
            _collectionFieldName = collectionFieldName;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IList<T>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                if (item[_collectionFieldName] != null)
                {
                    return item[_collectionFieldName].ToObject<IList<T>>(serializer);
                }
            }
            else
            {
                JArray array = JArray.Load(reader);

                var collection = array.ToObject<IList<T>>();

                return new PagedList<T>(collection);
            }

            return null;
        }
    }
}