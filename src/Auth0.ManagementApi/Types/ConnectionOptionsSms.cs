using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'sms' connection
/// </summary>
[Serializable]
public record ConnectionOptionsSms : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Whether brute force protection is enabled
    /// </summary>
    [Optional]
    [JsonPropertyName("brute_force_protection")]
    public bool? BruteForceProtection { get; set; }

    [Optional]
    [JsonPropertyName("disable_signup")]
    public bool? DisableSignup { get; set; }

    [Optional]
    [JsonPropertyName("forward_req_info")]
    public bool? ForwardReqInfo { get; set; }

    [Optional]
    [JsonPropertyName("from")]
    public string? From { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("gateway_authentication")]
    public Optional<ConnectionGatewayAuthenticationSms?> GatewayAuthentication { get; set; }

    [Optional]
    [JsonPropertyName("gateway_url")]
    public string? GatewayUrl { get; set; }

    [Optional]
    [JsonPropertyName("messaging_service_sid")]
    public string? MessagingServiceSid { get; set; }

    /// <summary>
    /// Connection name
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("provider")]
    public ConnectionProviderEnumSms? Provider { get; set; }

    [Optional]
    [JsonPropertyName("syntax")]
    public ConnectionTemplateSyntaxEnumSms? Syntax { get; set; }

    [Optional]
    [JsonPropertyName("template")]
    public string? Template { get; set; }

    [Optional]
    [JsonPropertyName("totp")]
    public ConnectionTotpSms? Totp { get; set; }

    [Optional]
    [JsonPropertyName("twilio_sid")]
    public string? TwilioSid { get; set; }

    [Optional]
    [JsonPropertyName("twilio_token")]
    public string? TwilioToken { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

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
