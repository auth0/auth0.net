using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Guardian;

[Serializable]
public record SetGuardianFactorRequestContent
{
    /// <summary>
    /// Whether this factor is enabled (true) or disabled (false).
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
