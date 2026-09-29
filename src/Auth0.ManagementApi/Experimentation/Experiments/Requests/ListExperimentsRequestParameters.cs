using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record ListExperimentsRequestParameters
{
    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of experiments to return per page. Defaults to 25, maximum 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Filter by status. Exact match.
    /// </summary>
    [JsonIgnore]
    public Optional<ExperimentStatusEnum?> Status { get; set; }

    /// <summary>
    /// Filter by authentication flow. Exact match.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> AuthenticationFlow { get; set; }

    /// <summary>
    /// Filter by feature flag ID. Exact match.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> FeatureFlagId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
