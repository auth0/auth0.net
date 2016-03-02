using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.Core.Serialization
{
    public class ApiErrorConverter : JsonConverter
    {
        private readonly Dictionary<string, string> propertyMappings = new Dictionary<string, string>
        {
            {"code", "errorCode"},
            {"name", "error"},
            {"description", "message"},
            {"error_description", "message"}
        };

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = Activator.CreateInstance(objectType);
            var props = objectType.GetTypeInfo().DeclaredProperties.ToList();

            JObject jo = JObject.Load(reader);
            foreach (JProperty jp in jo.Properties())
            {
                string name;
                if (!propertyMappings.TryGetValue(jp.Name, out name))
                    name = jp.Name;

                PropertyInfo prop = props.FirstOrDefault(pi =>
                    pi.CanWrite && string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));

                prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
            }

            return instance;
        }
    }
}