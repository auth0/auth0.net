using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The identity object for enterprise identity providers.
/// </summary>
[Serializable]
public record EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterprise : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the connection containing this identity.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    [JsonPropertyName("user_id")]
    public required EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseUserId UserId { get; set; }

    [Optional]
    [JsonPropertyName("profileData")]
    public EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProfileData? ProfileData { get; set; }

    [JsonPropertyName("provider")]
    public required EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Provider { get; set; }

    [JsonPropertyName("isSocial")]
    public required bool IsSocial { get; set; }

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
