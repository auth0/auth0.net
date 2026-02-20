using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateOrganizationDiscoveryDomainResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Organization discovery domain identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The domain name to associate with the organization e.g. acme.com.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    [JsonPropertyName("status")]
    public required OrganizationDiscoveryDomainStatus Status { get; set; }

    /// <summary>
    /// Indicates whether this domain should be used for organization discovery.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_for_organization_discovery")]
    public bool? UseForOrganizationDiscovery { get; set; }

    /// <summary>
    /// A unique token generated for the discovery domain. This must be placed in a DNS TXT record at the location specified by the verification_host field to prove domain ownership.
    /// </summary>
    [JsonPropertyName("verification_txt")]
    public required string VerificationTxt { get; set; }

    /// <summary>
    /// The full domain where the TXT record should be added.
    /// </summary>
    [JsonPropertyName("verification_host")]
    public required string VerificationHost { get; set; }

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
