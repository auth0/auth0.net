using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class GuardianSnsConfigurationBase
    {
        [JsonProperty("aws_access_key_id")]
        public string AwsAccessKeyId { get; set; }

        [JsonProperty("aws_secret_access_key")]
        public string AwsSecretAccessKey { get; set; }

        [JsonProperty("aws_region")]
        public string AwsRegion { get; set; }

        [JsonProperty("sns_apns_platform_application_arn")]
        public string SnsApnsPlatformApplicationArn { get; set; }

        [JsonProperty("sns_gcm_platform_application_arn")]
        public string SnsGcmPlatformApplicationArn { get; set; }
    }
}