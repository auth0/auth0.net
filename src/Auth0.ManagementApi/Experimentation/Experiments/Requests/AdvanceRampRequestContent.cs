using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record AdvanceRampRequestContent
{
    /// <summary>
    /// The target percentage level from the experiment schedule. Must be the immediate next level.
    /// </summary>
    [JsonPropertyName("target_level")]
    public required int TargetLevel { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
