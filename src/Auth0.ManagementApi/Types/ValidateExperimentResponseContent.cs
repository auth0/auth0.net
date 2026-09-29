using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ValidateExperimentResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the experiment is ready to be activated.
    /// </summary>
    [JsonPropertyName("is_valid")]
    public required bool IsValid { get; set; }

    /// <summary>
    /// List of validation errors preventing activation. Empty when is_valid is true.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<ExperimentValidationError> Errors { get; set; } =
        new List<ExperimentValidationError>();

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
