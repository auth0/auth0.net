using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgMemberRoleAssignedObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("organization")]
    public required EventStreamCloudEventOrgMemberRoleAssignedObjectOrganization Organization { get; set; }

    [JsonPropertyName("user")]
    public required EventStreamCloudEventOrgMemberRoleAssignedObjectUser User { get; set; }

    [JsonPropertyName("role")]
    public required EventStreamCloudEventOrgMemberRoleAssignedObjectRole Role { get; set; }

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
