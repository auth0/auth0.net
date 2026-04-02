using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The user's identity. If you set this value, you must also send the user_id parameter.
/// </summary>
[Serializable]
public record ChangePasswordTicketIdentity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// user_id of the identity.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("provider")]
    public required IdentityProviderOnlyAuth0Enum Provider { get; set; }

    /// <summary>
    /// connection_id of the identity.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

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
