using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Represents an event that occurs when a role is assigned to a group.
/// </summary>
[Serializable]
public record EventStreamCloudEventGroupRoleAssignedCloudEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The version of the CloudEvents specification which the event uses.
    /// </summary>
    [JsonPropertyName("specversion")]
    public required string Specversion { get; set; }

    [JsonPropertyName("type")]
    public required EventStreamCloudEventGroupRoleAssignedCloudEventTypeEnum Type { get; set; }

    /// <summary>
    /// The source of the event. This will take the form 'urn:auth0:&lt;tenant&gt;.&lt;domain&gt;'.
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// A unique identifier for the event.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// An ISO-8601 timestamp indicating when the event physically occurred.
    /// </summary>
    [JsonPropertyName("time")]
    public required DateTime Time { get; set; }

    [JsonPropertyName("data")]
    public required EventStreamCloudEventGroupRoleAssignedData Data { get; set; }

    /// <summary>
    /// The auth0 tenant ID to which the event is associated.
    /// </summary>
    [JsonPropertyName("a0tenant")]
    public required string A0Tenant { get; set; }

    /// <summary>
    /// The auth0 event stream ID of the stream the event was delivered on.
    /// </summary>
    [JsonPropertyName("a0stream")]
    public required string A0Stream { get; set; }

    [Optional]
    [JsonPropertyName("a0purpose")]
    public EventStreamCloudEventA0PurposeEnum? A0Purpose { get; set; }

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
