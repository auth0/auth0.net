using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The user that is a member of the organization.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgMemberAddedObjectUser
    : IJsonOnDeserialized,
        IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// ID of the user which can be used when interacting with other APIs.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

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
