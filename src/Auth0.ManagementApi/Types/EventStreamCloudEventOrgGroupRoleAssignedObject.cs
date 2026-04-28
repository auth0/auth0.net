using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgGroupRoleAssignedObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("organization")]
    public required EventStreamCloudEventOrgGroupRoleAssignedObjectOrganization Organization { get; set; }

    [JsonPropertyName("role")]
    public required EventStreamCloudEventOrgGroupRoleAssignedObjectRole Role { get; set; }

    [JsonPropertyName("group")]
    public required EventStreamCloudEventOrgGroupRoleAssignedObjectGroup Group { get; set; }

    /// <summary>
    /// The time at which the role was assigned to the group in the organization.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

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
