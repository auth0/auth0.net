using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogStreamFilterType
    {
        [EnumMember(Value ="category")]
        Category
    }
}
