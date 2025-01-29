using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class PushNotificationProviderConfiguration
    {
        [JsonProperty("provider")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PushNotificationProvider PushNotificationProvider { get; set; }
    }

    public enum PushNotificationProvider
    {
        [EnumMember(Value = "guardian")]
        Guardian,
        
        [EnumMember(Value = "sns")]
        Sns,
        
        [EnumMember(Value = "direct")]
        Direct,
    }
}