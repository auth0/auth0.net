using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateOrganizationRequestContent
{
    /// <summary>
    /// The name of this organization.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Friendly name of this organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("branding")]
    public OrganizationBranding? Branding { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    /// <summary>
    /// Connections that will be enabled for this organization. See POST enabled_connections endpoint for the object format. (Max of 10 connections allowed)
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_connections")]
    public IEnumerable<ConnectionForOrganization>? EnabledConnections { get; set; }

    [Optional]
    [JsonPropertyName("token_quota")]
    public CreateTokenQuota? TokenQuota { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
