using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record ListFeatureFlagsRequestParameters
{
    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of feature flags to return per page. Defaults to 25, maximum 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Filter by type. Exact match.
    /// </summary>
    [JsonIgnore]
    public Optional<FeatureFlagTypeEnum?> Type { get; set; }

    /// <summary>
    /// Filter by status. Exact match.
    /// </summary>
    [JsonIgnore]
    public Optional<FeatureFlagStatusEnum?> Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
