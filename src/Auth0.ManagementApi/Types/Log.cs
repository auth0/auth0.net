using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record Log : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("date")]
    public LogDate? Date { get; set; }

    /// <summary>
    /// Type of event.
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Description of this event.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    /// <summary>
    /// Name of the connection the event relates to.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    /// <summary>
    /// ID of the connection the event relates to.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// ID of the client (application).
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Name of the client (application).
    /// </summary>
    [Optional]
    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }

    /// <summary>
    /// IP address of the log event source.
    /// </summary>
    [Optional]
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Hostname the event applies to.
    /// </summary>
    [Optional]
    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    /// <summary>
    /// ID of the user involved in the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// Name of the user involved in the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_name")]
    public string? UserName { get; set; }

    /// <summary>
    /// API audience the event applies to.
    /// </summary>
    [Optional]
    [JsonPropertyName("audience")]
    public string? Audience { get; set; }

    /// <summary>
    /// Scope permissions applied to the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// Name of the strategy involved in the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// Type of strategy involved in the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("strategy_type")]
    public string? StrategyType { get; set; }

    /// <summary>
    /// Unique ID of the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("log_id")]
    public string? LogId { get; set; }

    /// <summary>
    /// Whether the client was a mobile device (true) or desktop/laptop/server (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("isMobile")]
    public bool? IsMobile { get; set; }

    [Optional]
    [JsonPropertyName("details")]
    public Dictionary<string, object?>? Details { get; set; }

    /// <summary>
    /// User agent string from the client device that caused the event.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }

    [Optional]
    [JsonPropertyName("security_context")]
    public LogSecurityContext? SecurityContext { get; set; }

    [Optional]
    [JsonPropertyName("location_info")]
    public LogLocationInfo? LocationInfo { get; set; }

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
