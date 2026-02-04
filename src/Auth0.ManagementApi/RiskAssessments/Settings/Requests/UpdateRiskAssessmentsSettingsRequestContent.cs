using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.RiskAssessments;

[Serializable]
public record UpdateRiskAssessmentsSettingsRequestContent
{
    /// <summary>
    /// Whether or not risk assessment is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
