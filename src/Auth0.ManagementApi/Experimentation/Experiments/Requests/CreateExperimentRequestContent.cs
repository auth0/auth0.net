using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record CreateExperimentRequestContent
{
    /// <summary>
    /// A human-readable name for the experiment
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description of the experiment
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The ID of the feature flag this experiment is based on
    /// </summary>
    [JsonPropertyName("feature_flag_id")]
    public required string FeatureFlagId { get; set; }

    [JsonPropertyName("authentication_flow")]
    public required AuthenticationFlowEnum AuthenticationFlow { get; set; }

    /// <summary>
    /// Applies only to Auth0-managed flags. Controls where non-overridden config keys resolve from: 'tenant' inherits the tenant's live config so the experiment overlays only its changes, 'flag' uses the flag's frozen defaults for a complete config. Optional; defaults to 'tenant' when omitted. Rejected for customer-defined flags.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_config")]
    public DefaultConfigEnum? DefaultConfig { get; set; }

    /// <summary>
    /// The traffic allocation strategy for this experiment
    /// </summary>
    [Optional]
    [JsonPropertyName("allocation_strategy")]
    public AllocationStrategyEnum? AllocationStrategy { get; set; }

    /// <summary>
    /// Traffic allocations mapping variations to weights or segments
    /// </summary>
    [Optional]
    [JsonPropertyName("allocations")]
    public IEnumerable<AllocationRequestItem>? Allocations { get; set; }

    /// <summary>
    /// Ramp experiment levels configuration. A strictly-increasing sequence of exposure percentages, each an integer in [0, 100].
    /// </summary>
    [Optional]
    [JsonPropertyName("levels")]
    public IEnumerable<int>? Levels { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
