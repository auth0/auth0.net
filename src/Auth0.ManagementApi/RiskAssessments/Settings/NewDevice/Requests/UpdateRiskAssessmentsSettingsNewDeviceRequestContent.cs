using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.RiskAssessments.Settings;

[Serializable]
public record UpdateRiskAssessmentsSettingsNewDeviceRequestContent
{
    /// <summary>
    /// Length of time to remember devices for, in days.
    /// </summary>
    [JsonPropertyName("remember_for")]
    public required int RememberFor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
