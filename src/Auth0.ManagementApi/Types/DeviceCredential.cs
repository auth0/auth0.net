using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DeviceCredential : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of this device.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// User agent for this device
    /// </summary>
    [Optional]
    [JsonPropertyName("device_name")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// Unique identifier for the device. NOTE: This field is generally not populated for refresh_tokens and rotating_refresh_tokens
    /// </summary>
    [Optional]
    [JsonPropertyName("device_id")]
    public string? DeviceId { get; set; }

    [Optional]
    [JsonPropertyName("type")]
    public DeviceCredentialTypeEnum? Type { get; set; }

    /// <summary>
    /// user_id this credential is associated with.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// client_id of the client (application) this credential is for.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

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
