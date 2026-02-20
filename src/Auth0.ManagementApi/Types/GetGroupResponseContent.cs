using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Represents the metadata of a group. Member lists are retrieved via a separate endpoint.
/// </summary>
[Serializable]
public record GetGroupResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Unique identifier for the group (service-generated).
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the group. Must be unique within its scope (connection, organization, or tenant). Must contain between 1 and 128 printable ASCII characters.
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
    [JsonPropertyName("tenant_name")]
    public required string TenantName { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    /// <summary>
    /// Timestamp of when the group was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp of when the group was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
