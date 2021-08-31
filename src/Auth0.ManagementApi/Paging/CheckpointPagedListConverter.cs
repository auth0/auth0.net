using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.ManagementApi.Paging
{
    internal class CheckpointPagedListConverter<T> : JsonConverter
    {
        private readonly string _collectionFieldName;
        private readonly bool _collectionInDictionary;

        public CheckpointPagedListConverter(string collectionFieldName, bool collectionInDictionary = false)
        {
            _collectionFieldName = collectionFieldName;
            _collectionInDictionary = collectionInDictionary;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ICheckpointPagedList<T>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                if (item[_collectionFieldName] != null)
                {
                    var collection = item[_collectionFieldName].ToObject<IList<T>>(serializer);

                    return new CheckpointPagedList<T>(collection, new CheckpointPagingInformation(item["next"]?.Value<string>()));
                }
                else if (_collectionInDictionary) // Special case to handle User Logs which is returned as a dictionary and not an array
                {
                    List<T> collection = new List<T>();
                    foreach (var kvp in item)
                    {
                        if (kvp.Key != "length")
                        {
                            try
                            {
                                collection.Add(kvp.Value.ToObject<T>());
                            }
                            catch
                            {
                                // Fail silently (for now)
                            }
                        }
                    }

                    return new CheckpointPagedList<T>(collection);
                }
            }
            else
            {
                JArray array = JArray.Load(reader);

                var collection = array.ToObject<IList<T>>();

                return new CheckpointPagedList<T>(collection);
            }

            // This should not happen. Perhaps better to throw exception at this point?
            return null;
        }
    }
}