using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgGroupRoleDeletedObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("organization")]
    public required EventStreamCloudEventOrgGroupRoleDeletedObjectOrganization Organization { get; set; }

    [JsonPropertyName("role")]
    public required EventStreamCloudEventOrgGroupRoleDeletedObjectRole Role { get; set; }

    [JsonPropertyName("group")]
    public required EventStreamCloudEventOrgGroupRoleDeletedObjectGroup Group { get; set; }

    /// <summary>
    /// The time at which the role was removed from the group in the organization.
    /// </summary>
    [JsonPropertyName("deleted_at")]
    public required DateTime DeletedAt { get; set; }

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
