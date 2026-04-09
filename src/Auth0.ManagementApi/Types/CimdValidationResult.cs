using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Validation result for the Client ID Metadata Document
/// </summary>
[Serializable]
public record CimdValidationResult : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Whether the metadata document passed validation
    /// </summary>
    [JsonPropertyName("valid")]
    public required bool Valid { get; set; }

    /// <summary>
    /// Array of validation violation messages (if any)
    /// </summary>
    [JsonPropertyName("violations")]
    public IEnumerable<string> Violations { get; set; } = new List<string>();

    /// <summary>
    /// Array of warning messages (if any)
    /// </summary>
    [JsonPropertyName("warnings")]
    public IEnumerable<string> Warnings { get; set; } = new List<string>();

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
