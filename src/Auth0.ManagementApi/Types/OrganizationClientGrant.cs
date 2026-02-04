using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record OrganizationClientGrant : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// ID of the client.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The audience (API identifier) of this client grant
    /// </summary>
    [Optional]
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    /// <summary>
    /// Scopes allowed for this client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("organization_usage")]
    public OrganizationUsageEnum? OrganizationUsage { get; set; }

    /// <summary>
    /// If enabled, any organization can be used with this grant. If disabled (default), the grant must be explicitly assigned to the desired organizations.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_any_organization")]
    public bool? AllowAnyOrganization { get; set; }

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
