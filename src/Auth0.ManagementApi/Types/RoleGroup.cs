using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// A group assigned to a role in the context of an organization.
/// </summary>
[Serializable]
public record RoleGroup : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the group (service-generated).
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the group. Must be unique within its connection. Must contain between 1 and 128 printable ASCII characters.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// External identifier for the group, often used for SCIM synchronization. Max length of 256 characters.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Identifier for the connection this group belongs to (if a connection group).
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// Identifier for the organization this group belongs to (if an organization group).
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("organization_id")]
    public Optional<string?> OrganizationId { get; set; }

    /// <summary>
    /// Identifier for the tenant this group belongs to.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_name")]
    public string? TenantName { get; set; }

    /// <summary>
    /// Description of the group.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    /// <summary>
    /// Timestamp of when the group was created.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp of when the group was last updated.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
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
