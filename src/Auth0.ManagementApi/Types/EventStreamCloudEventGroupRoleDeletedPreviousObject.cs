using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[Serializable]
public record EventStreamCloudEventGroupRoleDeletedPreviousObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("group")]
    public required EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup Group { get; set; }

    [JsonPropertyName("role")]
    public required EventStreamCloudEventGroupRoleDeletedPreviousObjectRole Role { get; set; }

    /// <summary>
    /// The time at which the role was assigned to the group.
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
