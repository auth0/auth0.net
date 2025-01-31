using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class PhoneProviderConfiguration
    {
        [JsonProperty("provider")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PhoneProvider PhoneProvider { get; set; }
    }

    public enum PhoneProvider
    {
        [EnumMember(Value = "auth0")]
        Auth0,
        
        [EnumMember(Value = "twilio")]
        Twilio,
        
        [EnumMember(Value = "phone-message-hook")]
        PhoneMessageHook,
    }
}