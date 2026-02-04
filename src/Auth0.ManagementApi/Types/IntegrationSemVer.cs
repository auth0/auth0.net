using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Semver denotes the major.minor version of an integration release
/// </summary>
[Serializable]
public record IntegrationSemVer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Major is the major number of a semver
    /// </summary>
    [Optional]
    [JsonPropertyName("major")]
    public int? Major { get; set; }

    /// <summary>
    /// Minior is the minior number of a semver
    /// </summary>
    [Optional]
    [JsonPropertyName("minor")]
    public int? Minor { get; set; }

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
