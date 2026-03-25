using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Password history policy configuration to prevent password reuse
/// </summary>
[Serializable]
public record ConnectionPasswordOptionsHistory : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Enables password history checking to prevent users from reusing recent passwords
    /// </summary>
    [Optional]
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Number of previous passwords to remember and prevent reuse (1-24)
    /// </summary>
    [Optional]
    [JsonPropertyName("size")]
    public int? Size { get; set; }

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
