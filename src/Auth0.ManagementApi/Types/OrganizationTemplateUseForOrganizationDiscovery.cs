using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Controls whether connections from this template are used for organization discovery.
/// </summary>
[Serializable]
public record OrganizationTemplateUseForOrganizationDiscovery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The default value for organization discovery.
    /// </summary>
    [JsonPropertyName("default_value")]
    public required bool DefaultValue { get; set; }

    /// <summary>
    /// The allowed values for organization discovery.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_values")]
    public IEnumerable<bool>? AllowedValues { get; set; }

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
