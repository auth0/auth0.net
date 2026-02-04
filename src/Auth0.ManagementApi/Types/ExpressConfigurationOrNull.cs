using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Application specific configuration for use with the OIN Express Configuration feature.
/// </summary>
[Serializable]
public record ExpressConfigurationOrNull : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The URI users should bookmark to log in to this application. Variable substitution is permitted for the following properties: organization_name, organization_id, and connection_name.
    /// </summary>
    [JsonPropertyName("initiate_login_uri_template")]
    public required string InitiateLoginUriTemplate { get; set; }

    /// <summary>
    /// The ID of the user attribute profile to use for this application.
    /// </summary>
    [JsonPropertyName("user_attribute_profile_id")]
    public required string UserAttributeProfileId { get; set; }

    /// <summary>
    /// The ID of the connection profile to use for this application.
    /// </summary>
    [JsonPropertyName("connection_profile_id")]
    public required string ConnectionProfileId { get; set; }

    /// <summary>
    /// When true, all connections made via express configuration will be enabled for this application.
    /// </summary>
    [JsonPropertyName("enable_client")]
    public required bool EnableClient { get; set; }

    /// <summary>
    /// When true, all connections made via express configuration will have the associated organization enabled.
    /// </summary>
    [JsonPropertyName("enable_organization")]
    public required bool EnableOrganization { get; set; }

    /// <summary>
    /// List of client IDs that are linked to this express configuration (e.g. web or mobile clients).
    /// </summary>
    [Optional]
    [JsonPropertyName("linked_clients")]
    public IEnumerable<LinkedClientConfiguration>? LinkedClients { get; set; }

    /// <summary>
    /// This is the unique identifier for the Okta OIN Express Configuration Client, which Okta will use for this application.
    /// </summary>
    [JsonPropertyName("okta_oin_client_id")]
    public required string OktaOinClientId { get; set; }

    /// <summary>
    /// This is the domain that admins are expected to log in via for authenticating for express configuration. It can be either the canonical domain or a registered custom domain.
    /// </summary>
    [JsonPropertyName("admin_login_domain")]
    public required string AdminLoginDomain { get; set; }

    /// <summary>
    /// The identifier of the published application in the OKTA OIN.
    /// </summary>
    [Optional]
    [JsonPropertyName("oin_submission_id")]
    public string? OinSubmissionId { get; set; }

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
