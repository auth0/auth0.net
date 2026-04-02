using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SetGuardianFactorsProviderSmsTwilioResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// From number
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("from")]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Copilot SID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("messaging_service_sid")]
    public Optional<string?> MessagingServiceSid { get; set; }

    /// <summary>
    /// Twilio Authentication token
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("auth_token")]
    public Optional<string?> AuthToken { get; set; }

    /// <summary>
    /// Twilio SID
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("sid")]
    public Optional<string?> Sid { get; set; }

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
