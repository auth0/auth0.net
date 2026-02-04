using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian.Factors;

[Serializable]
public record SetGuardianFactorsProviderPushNotificationSnsRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("aws_access_key_id")]
    public Optional<string?> AwsAccessKeyId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("aws_secret_access_key")]
    public Optional<string?> AwsSecretAccessKey { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("aws_region")]
    public Optional<string?> AwsRegion { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("sns_apns_platform_application_arn")]
    public Optional<string?> SnsApnsPlatformApplicationArn { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("sns_gcm_platform_application_arn")]
    public Optional<string?> SnsGcmPlatformApplicationArn { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
