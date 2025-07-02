using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles;

/// <summary>
/// List of organizations that the connection will be enabled for.
/// </summary>
public class EnabledOrganization
{
    /// <summary>
    /// Organization identifier
    /// </summary>
    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }
        
    /// <summary>
    /// When true, all users that log in with this connection will be automatically granted membership in
    /// the organization. When false, users must be granted membership in the organization before logging
    /// in with this connection.
    /// </summary>
    [JsonProperty("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }
        
    /// <summary>
    /// Determines whether a connection should be displayed on this organization’s login prompt.
    /// Only applicable for enterprise connections.
    /// </summary>
    [JsonProperty("show_as_button")]
    public bool? ShowAsButton { get; set; }
}