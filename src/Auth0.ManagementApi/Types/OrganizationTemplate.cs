using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record OrganizationTemplate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Organization Template identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
    [Optional]
    [JsonPropertyName("connection_profile_id")]
    public string? ConnectionProfileId { get; set; }

    /// <summary>
    /// The user attribute profile to apply to organizations.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public string? UserAttributeProfileId { get; set; }

    /// <summary>
    /// List of allowed connection strategies for this template.
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_strategies")]
    public IEnumerable<OrganizationTemplateAllowedStrategyEnum>? AllowedStrategies { get; set; }

    /// <summary>
    /// The client ID for the invitation landing page.
    /// </summary>
    [Optional]
    [JsonPropertyName("invitation_landing_client_id")]
    public string? InvitationLandingClientId { get; set; }

    /// <summary>
    /// Default admin roles to assign to organization creators.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_roles_assignment")]
    public IEnumerable<string>? AdminRolesAssignment { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("use_for_organization_discovery")]
    public Optional<OrganizationTemplateUseForOrganizationDiscovery?> UseForOrganizationDiscovery { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("role_visibility_policy")]
    public Optional<OrganizationTemplateRoleVisibilityPolicy?> RoleVisibilityPolicy { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing when the template was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing when the template was last updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
