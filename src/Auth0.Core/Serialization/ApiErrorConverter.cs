using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.Core.Serialization
{
    internal class ApiErrorConverter : JsonConverter
    {
        private readonly Dictionary<string, string> _propertyMappings = new Dictionary<string, string>
        {
            {"code", "errorCode"},
            {"name", "error"},
            {"description", "message"},
            {"error_description", "message"}
        };

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var instance = Activator.CreateInstance(objectType);
            var props = objectType.GetTypeInfo().DeclaredProperties.Where(p => p.CanWrite).ToList();
            var extraDataProp = props.FirstOrDefault(p => p.PropertyType == typeof(Dictionary<string, string>));

            foreach (var jp in JObject.Load(reader).Properties())
            {
                if (!_propertyMappings.TryGetValue(jp.Name, out var name))
                    name = jp.Name;

                var prop = props.FirstOrDefault(pi => string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));

                if (prop != null)
                {
                    prop.SetValue(instance, jp.Value.ToObject<string>(serializer));
                }
                else if (extraDataProp != null)
                {
                    ((IDictionary<string, string>)extraDataProp.GetValue(instance))[name] = jp.Value.ToObject<string>(serializer);
                }
            }

            return instance;
        }
    }
}