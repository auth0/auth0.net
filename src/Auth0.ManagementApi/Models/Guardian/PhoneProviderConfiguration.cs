using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class PhoneProviderConfiguration
    {
        [JsonProperty("provider")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Provider Provider { get; set; }
    }

    public enum Provider
    {
        [EnumMember(Value = "auth0")]
        Auth0,
        
        [EnumMember(Value = "twilio")]
        Twilio,
        
        [EnumMember(Value = "phone-message-hook")]
        PhoneMessageHook,
    }
}