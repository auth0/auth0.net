using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for B2B Integration clients.
/// </summary>
[Serializable]
public record B2BIntegrationConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of SSO profile IDs linked to this B2B integration client. Maximum 1 entry.
    /// </summary>
    [Optional]
    [JsonPropertyName("sso_profiles")]
    public IEnumerable<string>? SsoProfiles { get; set; }

    [Optional]
    [JsonPropertyName("integration_type")]
    public B2BIntegrationConfigurationIntegrationTypeEnum? IntegrationType { get; set; }

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
