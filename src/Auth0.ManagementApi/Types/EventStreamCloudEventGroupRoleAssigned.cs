using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// SSE message for group.role.assigned.
/// </summary>
[Serializable]
public record EventStreamCloudEventGroupRoleAssigned : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Opaque cursor representing position in the stream. Pass as the `from` query parameter to resume.
    /// </summary>
    [JsonPropertyName("offset")]
    public required string Offset { get; set; }

    [JsonPropertyName("event")]
    public required EventStreamCloudEventGroupRoleAssignedCloudEvent Event { get; set; }

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
