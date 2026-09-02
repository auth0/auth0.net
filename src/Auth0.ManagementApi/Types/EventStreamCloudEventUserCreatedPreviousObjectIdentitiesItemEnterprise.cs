using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The identity object for enterprise identity providers.
/// </summary>
[Serializable]
public record EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterprise
    : IJsonOnDeserialized
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
    public required EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseUserId UserId { get; set; }

    [Optional]
    [JsonPropertyName("profileData")]
    public EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProfileData? ProfileData { get; set; }

    [JsonPropertyName("provider")]
    public required EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Provider { get; set; }

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
