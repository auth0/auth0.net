using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record IntegrationRelease : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The id of the associated IntegrationRelease
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Optional]
    [JsonPropertyName("trigger")]
    public ActionTrigger? Trigger { get; set; }

    [Optional]
    [JsonPropertyName("semver")]
    public IntegrationSemVer? Semver { get; set; }

    /// <summary>
    /// required_secrets declares all the necessary secrets for an integration to
    /// work.
    /// </summary>
    [Optional]
    [JsonPropertyName("required_secrets")]
    public IEnumerable<IntegrationRequiredParam>? RequiredSecrets { get; set; }

    /// <summary>
    /// required_configuration declares all the necessary configuration fields for an integration to work.
    /// </summary>
    [Optional]
    [JsonPropertyName("required_configuration")]
    public IEnumerable<IntegrationRequiredParam>? RequiredConfiguration { get; set; }

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
