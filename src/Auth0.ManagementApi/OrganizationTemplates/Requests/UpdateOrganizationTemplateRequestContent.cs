using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateOrganizationTemplateRequestContent
{
    /// <summary>
    /// The name of the organization template.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Whether this is the default template applied to new organizations.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [Optional]
    [JsonPropertyName("organization_deletion_behavior")]
    public OrganizationDeletionBehaviorEnum? OrganizationDeletionBehavior { get; set; }

    [Optional]
    [JsonPropertyName("connection_deletion_behavior")]
    public ConnectionDeletionBehaviorEnum? ConnectionDeletionBehavior { get; set; }

    /// <summary>
    /// Whether to enforce permission ceiling for organizations using this template.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_permission_ceiling")]
    public bool? EnforcePermissionCeiling { get; set; }

    /// <summary>
    /// Whether to enforce self-assignment restrictions for organizations using this template.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_self_assignment_restriction")]
    public bool? EnforceSelfAssignmentRestriction { get; set; }

    /// <summary>
    /// The connection profile to apply to new connections.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("connection_profile_id")]
    public Optional<string?> ConnectionProfileId { get; set; }

    /// <summary>
    /// The user attribute profile to apply to organizations.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public Optional<string?> UserAttributeProfileId { get; set; }

    /// <summary>
    /// List of allowed connection strategies for this template.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("allowed_strategies")]
    public Optional<IEnumerable<OrganizationTemplateAllowedStrategyEnum>?> AllowedStrategies { get; set; }

    /// <summary>
    /// The client ID for the invitation landing page.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("invitation_landing_client_id")]
    public Optional<string?> InvitationLandingClientId { get; set; }

    /// <summary>
    /// Default admin roles to assign to organization creators.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("admin_roles_assignment")]
    public Optional<IEnumerable<string>?> AdminRolesAssignment { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("use_for_organization_discovery")]
    public Optional<OrganizationTemplateUseForOrganizationDiscovery?> UseForOrganizationDiscovery { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("role_visibility_policy")]
    public Optional<OrganizationTemplateRoleVisibilityPolicy?> RoleVisibilityPolicy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
