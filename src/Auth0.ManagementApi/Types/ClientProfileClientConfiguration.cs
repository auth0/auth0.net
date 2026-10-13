using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Runtime policy applied to matched clients. Omitted fields fall back to each client's own setting.
/// </summary>
[Serializable]
public record ClientProfileClientConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("refresh_token")]
    public ClientProfileClientConfigurationRefreshToken? RefreshToken { get; set; }

    [Optional]
    [JsonPropertyName("organization_usage")]
    public ClientProfileClientConfigurationOrganizationUsage? OrganizationUsage { get; set; }

    [Optional]
    [JsonPropertyName("organization_require_behavior")]
    public ClientProfileClientConfigurationOrganizationRequireBehavior? OrganizationRequireBehavior { get; set; }

    [Optional]
    [JsonPropertyName("organization_discovery_methods")]
    public ClientProfileClientConfigurationOrganizationDiscoveryMethods? OrganizationDiscoveryMethods { get; set; }

    [Optional]
    [JsonPropertyName("require_proof_of_possession")]
    public ClientProfileClientConfigurationRequireProofOfPossession? RequireProofOfPossession { get; set; }

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
