using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Auth0.ManagementApi.Serialization
{
    internal class PagedListConverter<T> : JsonConverter
    {
        private readonly string _collectionFieldName;
        private readonly bool _collectionInDictionary;

        public PagedListConverter(string collectionFieldName, bool collectionInDictionary = false)
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
            return typeof (IPagedList<T>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                if (item[_collectionFieldName] != null)
                {
                    var collection = item[_collectionFieldName].ToObject<IList<T>>(serializer);

                    int length = 0;
                    int limit = 0;
                    int start = 0;
                    int total = 0;
                    if (item["length"] != null)
                        length = item["length"].Value<int>();
                    if (item["limit"] != null)
                        limit = item["limit"].Value<int>();
                    if (item["start"] != null)
                        start = item["start"].Value<int>();
                    if (item["total"] != null)
                        total = item["total"].Value<int>();

                    return new PagedList<T>(collection, new PagingInformation(start, limit, length, total));
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
                    
                    return new PagedList<T>(collection);
                }
            }
            else
            {
                JArray array = JArray.Load(reader);

                var collection = array.ToObject<IList<T>>();

                return new PagedList<T>(collection);
            }

            // This should not happen. Perhaps better to throw exception at this point?
            return null;
        }
    }
}