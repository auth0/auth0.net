using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Multi-factor authentication configuration
/// </summary>
[Serializable]
public record ConnectionMfa : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether MFA is active for this connection
    /// </summary>
    [Optional]
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Indicates whether to return MFA enrollment settings
    /// </summary>
    [Optional]
    [JsonPropertyName("return_enroll_settings")]
    public bool? ReturnEnrollSettings { get; set; }

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
