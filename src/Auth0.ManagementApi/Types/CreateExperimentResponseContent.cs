using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateExperimentResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("feature_flag_id")]
    public required string FeatureFlagId { get; set; }

    [Optional]
    [JsonPropertyName("feature_flag_name")]
    public string? FeatureFlagName { get; set; }

    [JsonPropertyName("authentication_flow")]
    public required string AuthenticationFlow { get; set; }

    [JsonPropertyName("allocation_strategy")]
    public required AllocationStrategyEnum AllocationStrategy { get; set; }

    [JsonPropertyName("status")]
    public required ExperimentStatusEnum Status { get; set; }

    [JsonPropertyName("is_valid")]
    public required bool IsValid { get; set; }

    [Optional]
    [JsonPropertyName("default_config")]
    public DefaultConfigEnum? DefaultConfig { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("feature_flag_snapshot")]
    public Optional<Dictionary<string, object?>?> FeatureFlagSnapshot { get; set; }

    [JsonPropertyName("allocations")]
    public IEnumerable<AllocationItem> Allocations { get; set; } = new List<AllocationItem>();

    /// <summary>
    /// Fields that may be mutated given the experiment's current status. Computed at response time; always current with the API's enforcement logic.
    /// </summary>
    [JsonPropertyName("editable_fields")]
    public IEnumerable<string> EditableFields { get; set; } = new List<string>();

    /// <summary>
    /// Ramp experiment levels configuration.
    /// </summary>
    [Optional]
    [JsonPropertyName("levels")]
    public IEnumerable<int>? Levels { get; set; }

    /// <summary>
    /// Read-only. The active exposure percentage for the current ramp step. Null when no ramp schedule is active.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("current_level")]
    public Optional<int?> CurrentLevel { get; set; }

    [Optional]
    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    [Optional]
    [JsonPropertyName("ended_at")]
    public DateTime? EndedAt { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
