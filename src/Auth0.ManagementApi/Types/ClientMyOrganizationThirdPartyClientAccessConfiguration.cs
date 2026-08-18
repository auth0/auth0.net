using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The third-party client access configuration for the My Organization Configuration.
/// </summary>
[Serializable]
public record ClientMyOrganizationThirdPartyClientAccessConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("default_value")]
    public required ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum DefaultValue { get; set; }

    /// <summary>
    /// The allowed third-party client access values for the My Organization Configuration.
    /// </summary>
    [JsonPropertyName("allowed_values")]
    public IEnumerable<ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum> AllowedValues { get; set; } =
        new List<ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum>();

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
