using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record UpdateExperimentRequestParameters
{
    /// <summary>
    /// A human-readable name for the experiment
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of the experiment
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    /// <summary>
    /// Specifies the target authentication flow for this experiment. This field can only be modified on draft experiments. Must be one of: authentication, mfa_enrollment, mfa_challenge, password_reset, passkey_enrollment, or all. Note that the all value targets every flow at once, but requires that this is the only active experiment.
    /// </summary>
    [Optional]
    [JsonPropertyName("authentication_flow")]
    public AuthenticationFlowEnum? AuthenticationFlow { get; set; }

    /// <summary>
    /// Replaces all traffic allocations. Cannot be modified while the experiment is active.
    /// </summary>
    [Optional]
    [JsonPropertyName("allocations")]
    public IEnumerable<AllocationRequestItem>? Allocations { get; set; }

    /// <summary>
    /// Applies only to Auth0-managed flags. Controls where non-overridden config keys resolve from: 'tenant' inherits the tenant's live config, 'flag' uses the flag's frozen defaults. Can only be modified on draft experiments. Rejected for customer-defined flags.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_config")]
    public DefaultConfigEnum? DefaultConfig { get; set; }

    /// <summary>
    /// Ramp experiment levels configuration. A strictly-increasing sequence of exposure percentages, each an integer in [0, 100]. Can only be modified on draft experiments.
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
