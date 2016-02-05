using System;
using System.Collections.Generic;
using System.Reflection;
using Auth0.Core;
using Auth0.Core.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.ManagementApi.Serialization
{
    internal class UserPagedListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof (IPagedList<User>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                if (item["users"] != null)
                {
                    var users = item["users"].ToObject<IList<User>>(serializer);

                    int length = item["length"].Value<int>();
                    int limit = item["limit"].Value<int>();
                    int start = item["start"].Value<int>();
                    int total = item["total"].Value<int>();

                    return new PagedList<User>(users, new PagingInformation(start, limit, length, total));
                }
            }
            else
            {
                JArray array = JArray.Load(reader);

                var users = array.ToObject<IList<User>>();

                return new PagedList<User>(users);
            }

            // This should not happen. Perhaps better to throw exception at this point?
            return null;
        }
    }
}