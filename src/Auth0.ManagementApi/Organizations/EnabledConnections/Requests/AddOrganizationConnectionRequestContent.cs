using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record AddOrganizationConnectionRequestContent
{
    /// <summary>
    /// Single connection ID to add to the organization.
    /// </summary>
    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    /// <summary>
    /// When true, all users that log in with this connection will be automatically granted membership in the organization. When false, users must be granted membership in the organization before logging in with this connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }

    /// <summary>
    /// Determines whether organization signup should be enabled for this organization connection. Only applicable for database connections. Default: false.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_signup_enabled")]
    public bool? IsSignupEnabled { get; set; }

    /// <summary>
    /// Determines whether a connection should be displayed on this organization’s login prompt. Only applicable for enterprise connections. Default: true.
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
