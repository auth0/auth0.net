using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for the setup of Provisioning in the self-service flow.
/// </summary>
[Serializable]
public record SelfServiceProfileSsoTicketProvisioningConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The scopes of the SCIM tokens generated during the self-service flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<SelfServiceProfileSsoTicketProvisioningScopeEnum>? Scopes { get; set; }

    [Optional]
    [JsonPropertyName("google_workspace")]
    public SelfServiceProfileSsoTicketGoogleWorkspaceConfig? GoogleWorkspace { get; set; }

    /// <summary>
    /// Lifetime of the tokens in seconds. Must be greater than 900. If not provided, the tokens don't expire.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("token_lifetime")]
    public Optional<int?> TokenLifetime { get; set; }

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
