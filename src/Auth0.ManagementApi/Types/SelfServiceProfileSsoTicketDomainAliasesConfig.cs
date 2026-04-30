using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for the setup of the connection’s domain_aliases in the Self-Service Enterprise Configuration flow.
/// </summary>
[Serializable]
public record SelfServiceProfileSsoTicketDomainAliasesConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("domain_verification")]
    public required SelfServiceProfileSsoTicketDomainVerificationEnum DomainVerification { get; set; }

    /// <summary>
    /// List of domains that will be submitted for verification during the Self-Service Enterprise Configuration flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("pending_domains")]
    public IEnumerable<string>? PendingDomains { get; set; }

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
