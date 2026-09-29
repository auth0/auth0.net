using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record UpdateFeatureFlagStatusRequestContent
{
    /// <summary>
    /// The target status to transition the feature flag to.
    /// </summary>
    [JsonPropertyName("status")]
    public required FeatureFlagStatusEnum Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
