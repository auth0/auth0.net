using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record PatchRateLimitPolicyRequestContent
{
    [JsonPropertyName("configuration")]
    public required PatchRateLimitPolicyConfigurationRequestContent Configuration { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
