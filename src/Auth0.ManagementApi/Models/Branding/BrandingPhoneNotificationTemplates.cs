using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class BrandingPhoneNotificationTemplate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("customizable")]
        public bool? Customizable { get; set; }

        [JsonProperty("tenant")]
        public string Tenant { get; set; }

        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BrandingPhoneNotificationTemplateType Type { get; set; }

        /// <summary>
        /// Whether the template is enabled (false) or disabled (true).
        /// </summary>
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }
    }

    public class Content
    {
        [JsonProperty("syntax")]
        public string Syntax { get; set; }
        
        /// <summary>
        /// Default phone number to be used as 'from' when sending a phone notification
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }
        
        [JsonProperty("body")]
        public ContentBody Body { get; set; }
    }

    public class ContentBody
    {
        /// <summary>
        /// Content of the phone template for text notifications
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        
        /// <summary>
        /// Content of the phone template for voice notifications
        /// </summary>
        [JsonProperty("voice")]
        public string Voice { get; set; }
    }

    public enum BrandingPhoneNotificationTemplateType
    {
        [EnumMember(Value = "otp_verify")]
        OtpVerify,
        
        [EnumMember(Value = "otp_enroll")]
        OtpEnroll,
        
        [EnumMember(Value = "change_password")]
        ChangePassword,
        
        [EnumMember(Value = "blocked_account")]
        BlockedAccount,
        
        [EnumMember(Value = "password_breach")]
        PasswordBreach,
    }
}