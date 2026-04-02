using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The connection's options (depend on the connection strategy)
/// </summary>
[Serializable]
public record SelfServiceProfileSsoTicketConnectionOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URL for the icon. Must use HTTPS.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("icon_url")]
    public Optional<string?> IconUrl { get; set; }

    /// <summary>
    /// List of domain_aliases that can be authenticated in the Identity Provider
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("domain_aliases")]
    public Optional<IEnumerable<string>?> DomainAliases { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("idpinitiated")]
    public Optional<SelfServiceProfileSsoTicketIdpInitiatedOptions?> Idpinitiated { get; set; }

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
