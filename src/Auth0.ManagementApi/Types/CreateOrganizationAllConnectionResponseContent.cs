using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateOrganizationAllConnectionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the connection in the scope of this organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("organization_connection_name")]
    public string? OrganizationConnectionName { get; set; }

    /// <summary>
    /// When true, all users that log in with this connection will be automatically granted membership in the organization. When false, users must be granted membership in the organization before logging in with this connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }

    /// <summary>
    /// Determines whether a connection should be displayed on this organization’s login prompt. Only applicable for enterprise connections. Default: true.
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <summary>
    /// Determines whether organization signup should be enabled for this organization connection. Only applicable for database connections. Default: false.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_signup_enabled")]
    public bool? IsSignupEnabled { get; set; }

    [Optional]
    [JsonPropertyName("organization_access_level")]
    public OrganizationAccessLevelEnum? OrganizationAccessLevel { get; set; }

    /// <summary>
    /// Whether the connection is enabled for the organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_enabled")]
    public bool? IsEnabled { get; set; }

    /// <summary>
    /// Connection identifier.
    /// </summary>
    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("connection")]
    public OrganizationConnectionInformation? Connection { get; set; }

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
